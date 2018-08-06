using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using duca_gateway.Mocks.StoneDc;
using duca_gateway.Mocks.ClearSale;
using duca_gateway.Models;
namespace duca_gateway.Repository
{
    interface ITransacaoRepository
    {
        void Add(Transacao trans);

        IEnumerable<Transacao> FindByIdLojista(long id);
        Transacao Find(long id);

        IEnumerable<Transacao> GetAll();

        void Remove(long id);

        void Update(Transacao trans);

        Task<Stone> AddTransacaoStone(Stone stn);
        Task<OrderStatus> ValidPayment(Payment pay);
    }
}
