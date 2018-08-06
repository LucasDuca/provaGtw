using duca_gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace duca_gateway.Repository
{
    interface ILojistaRepository
    {
        void Add(Lojista lojista);

        Lojista Find(long id);

        IEnumerable<Lojista> GetAll();

        void Remove(long id);

        void Update(Lojista lojista);


    }
}
