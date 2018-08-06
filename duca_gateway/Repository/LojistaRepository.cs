using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using duca_gateway.Models;

namespace duca_gateway.Repository
{
    public class LojistaRepository : ILojistaRepository
    {
        private readonly duca_gtwContext _ctx;
        public LojistaRepository(duca_gtwContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Lojista lojista)
        {
            _ctx.Lojista.Add(lojista);
            _ctx.SaveChanges();
        }

        public Lojista Find(long id)
        {
            return _ctx.Lojista.FirstOrDefault(l => l.IdLojista == id);
        }

        public IEnumerable<Lojista> GetAll()
        {
           return _ctx.Lojista.ToList();
        }

        public void Remove(long id)
        {
            var loj =_ctx.Lojista.FirstOrDefault(l => l.IdLojista == id);
            _ctx.Lojista.Remove(loj);
            _ctx.SaveChanges();
        }

        public void Update(Lojista lojista)
        {
            _ctx.Update(lojista);
            _ctx.SaveChanges();
        }
    }
}
