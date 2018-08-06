using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using duca_gateway.Models;

namespace duca_gateway.Repository
{
    interface IConfiguracaoRepository
    {
        void Add(Configuracao config);

        Configuracao Find(long id);

        Configuracao FindByIdLojista(long id);

        IEnumerable<Configuracao> GetAll();

        void Remove(long id);

        void Update(Configuracao config);
    }
}
