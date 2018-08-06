using duca_gateway.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace duca_gateway.Repository
{
    public class ConfiguracaoRepository : IConfiguracaoRepository
    {
        private readonly duca_gtwContext _ctx;
        public ConfiguracaoRepository(duca_gtwContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Configuracao config)
        {
            _ctx.Configuracao.Add(config);
            _ctx.SaveChanges();
        }

        public IEnumerable<Configuracao> GetAll(long id)
        {
            return _ctx.Configuracao.ToList();
        }

        public Configuracao Find(long id)
        {
            return _ctx.Configuracao.FirstOrDefault(c => c.IdConfiguracao == id);
        }

        public Configuracao FindByIdLojista(long id)
        {
            return _ctx.Configuracao.FirstOrDefault(c => c.IdLojista == id);
        }

        public void Remove(long id)
        {
            var conf = _ctx.Configuracao.FirstOrDefault(c => c.IdConfiguracao == id);
            _ctx.Configuracao.Remove(conf);
            _ctx.SaveChanges();
        }

        public void Update(Configuracao conf)
        {
            _ctx.Configuracao.Update(conf);
            _ctx.SaveChanges();
        }

        public IEnumerable<Configuracao> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
