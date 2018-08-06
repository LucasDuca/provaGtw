using duca_gateway.Models;
using duca_gateway.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace duca_gateway.Controllers
{
    [Route("api/[controller]")]
    public class LojistasController : Controller
    {
        private readonly duca_gtwContext _db;
        private readonly ILojistaRepository _lojista;

        public LojistasController(duca_gtwContext db)
        {
            _db = db;
            _lojista = new LojistaRepository(_db);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Lojista loja)
        {
            if (loja == null)
            {
                return BadRequest();
            }
            _lojista.Add(loja);
            return CreatedAtRoute("GetLojista", new { id = loja.IdLojista }, loja);
        }

        [HttpGet("{id}", Name = "GetLojista")]
        public IActionResult GetById(long id)
        {

            var loja = _lojista.Find(id);
            if (loja == null)
                return BadRequest();
            return new ObjectResult(loja);
        }

        [HttpGet]
        public List<Lojista> Get()
        {
            return _db.Lojista.ToList();
        }

    }
}
