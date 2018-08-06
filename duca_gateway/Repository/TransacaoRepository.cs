using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using duca_gateway.Models;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using duca_gateway.Mocks.StoneDc;
using duca_gateway.Utility;
using System.Text;
using duca_gateway.Mocks.ClearSale;
using System.Web;

namespace duca_gateway.Repository
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly duca_gtwContext _ctx;
        HttpClient client = new HttpClient();
        public TransacaoRepository(duca_gtwContext ctx)
        {
            _ctx = ctx;
            client.BaseAddress = new Uri(@"http://localhost:4540/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Stone> AddTransacaoStone(Stone stn)
        {
            await Task.Delay(3000);
            //JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            StringContent httpConent = new StringContent(JsonConverter.Serialize<Stone>(stn), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/mockStone", httpConent);

            if (response.IsSuccessStatusCode)
            {
                var obj =  await response.Content.ReadAsStringAsync();
                Stone stn_new = new Stone();
                //JsonConverter.Serialize()
                obj = obj.Replace(@"\", " ");
                stn_new = JsonConverter.Deserialize<Stone>(obj);
                return stn_new;
            }
            else
            {
                return null;
            }
        }

        public async Task<OrderStatus> ValidPayment(Payment pay)
        {
            await Task.Delay(3000);
            //JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            StringContent httpConent = new StringContent(JsonConverter.Serialize<Payment>(pay), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/clearSale", httpConent);

            if (response.IsSuccessStatusCode)
            {
                var obj = await response.Content.ReadAsStringAsync();
                OrderStatus os = new OrderStatus();
                obj = obj.ToString();
                obj = obj.Replace(@"\", "");
                os = JsonConverter.Deserialize<OrderStatus>(obj);
                
                return os;
            }
            else
            {
                return null;
            }
        }
        public void Add(Transacao trans)
        {           
            _ctx.Transacao.Add(trans);
            _ctx.SaveChanges();
        }

        public Transacao Find(long id)
        {
            return _ctx.Transacao.FirstOrDefault(t => t.IdTransacao == id);
        }

        public IEnumerable<Transacao> GetAll()
        {
            return _ctx.Transacao.ToList();
        }

        public void Remove(long id)
        {
            var trans = _ctx.Transacao.FirstOrDefault(t => t.IdTransacao == id);
            _ctx.Transacao.Remove(trans);
            _ctx.SaveChanges();
        }

        public void Update(Transacao trans)
        {
            _ctx.Transacao.Update(trans);
            _ctx.SaveChanges();
        }

        public IEnumerable<Transacao> FindByIdLojista(long id)
        {
            return _ctx.Transacao.Where(c => c.IdLojista == id).ToList<Transacao>();
        }
    }
}
