using duca_gateway.Models;
using duca_gateway.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using duca_gateway.Mocks.StoneDc;
using System.Text;
using duca_gateway.Utility;
using duca_gateway.Mocks.ClearSale;
using System.Net;

namespace duca_gateway.Controllers
{
    [Route("api/[controller]")]
    public class TransacoesController : Controller
    {

        private readonly duca_gtwContext _db;
        private readonly ITransacaoRepository _transacao;
        private readonly IConfiguracaoRepository _config;

        public TransacoesController(duca_gtwContext db)
        {
            _db = db;
            _transacao = new TransacaoRepository(_db);
            _config = new ConfiguracaoRepository(_db);

        }

        [HttpGet("{id}", Name = "GetTransacao")]
        public IActionResult GetById(long id)
        {
            var trans = _transacao.FindByIdLojista(id);
            if (trans == null)
                return BadRequest();
            return new ObjectResult(trans);
        }

        [HttpGet]
        public List<Transacao> Get()
        {
            return _db.Transacao.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]Transacao trans)
        {
            if (trans == null)
            {
                return BadRequest();
            }

            var loja_config = _config.FindByIdLojista(trans.IdLojista);

            if (trans.Visa == "S")
            {
                //valida para qual adquirente encaminhar
                if (loja_config.RuleVisa == "S") //SE STONE
                {
                    trans.Stone = "S"; // SIM

                    if (loja_config.Antifraude == "S")
                    {
                        bool validPay = await ValidPaymentAsync("2018-08-06T22:10:00", trans.CreditCard);

                        if (!validPay)
                            return BadRequest("Pagamento inválido");
                    }

                    Stone adiquirenteStone = await AdiquirenteAsync(loja_config, "visa");
                    if (adiquirenteStone.ErrorReport != null)
                        return BadRequest("Adiquirente Inválido");
                }
                else
                {
                    trans.Cielo = "S"; // SIM
                }

            }
            else //se transação for MASTER
            {
                //MASTER
                if (loja_config.RuleMaster == "S") //SE STONE
                {
                    trans.Stone = "S"; //SIM

                    if (loja_config.Antifraude == "S")
                    {
                        bool validPay = await ValidPaymentAsync("2018-08-06T22:10:00", trans.CreditCard);

                        if (!validPay)
                            return BadRequest("Pagamento inválido");
                    }

                    Stone adiquirenteStone = await AdiquirenteAsync(loja_config, "master");
                    if (adiquirenteStone.MerchantKey == "" || adiquirenteStone.MerchantKey == null)
                        return BadRequest("Adiquirente Inválido");
                        
                }
                else
                {
                    trans.Cielo = "S"; //SIM
                }

            }

            _transacao.Add(trans);

            return CreatedAtRoute("GetTransacao", new { id = trans.IdTransacao }, trans);
        }

        protected async Task<Stone> AdiquirenteAsync(Configuracao loja_config, string bandeira)
        {
            Stone stn = new Stone();
            stn.MerchantKey = loja_config.Stonekey;
            stn.RequestKey = "857a5a07-ff3c-46e3-946e-452e25f149eb";
            CreditCardTransactionResultCollection[] cctri;
            cctri = new CreditCardTransactionResultCollection[1];
            cctri[0] = new CreditCardTransactionResultCollection();
            CreditCard card = new CreditCard();
            card.CreditCardBrand = bandeira;
            card.InstantBuyKey = "3b3b5b62 - 6660 - 428d - 905e-96f49d46ae28";
            card.IsExpiredCreditCard = false;
            card.MaskedCreditCardNumber = "411111****1111";
            cctri[0].CreditCard = card;
            stn.CreditCardTransactionResultCollection = cctri;
            Stone obj = await _transacao.AddTransacaoStone(stn);

            
            return obj;
        }

        protected async Task<bool> ValidPaymentAsync(string dt, string endCardNumber)
        {
            Payment pay = new Payment();
            pay.Date = dt;
            pay.Amount = 1;
            pay.Type = 1; //cartão de crédito
            pay.CardEndNumber = endCardNumber;

            OrderStatus obj = await _transacao.ValidPayment(pay);
            
            return obj.Status != "APA" ? false : true;
        }
        

        
    }
}
