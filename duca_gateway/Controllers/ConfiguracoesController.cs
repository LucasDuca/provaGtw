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
    public class ConfiguracoesController : Controller
    {
        private readonly duca_gtwContext _db;
        private readonly IConfiguracaoRepository _configuracao;

        public ConfiguracoesController(duca_gtwContext db)
        {
            _db = db;
            _configuracao = new ConfiguracaoRepository(_db);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Configuracao conf)
        {
            if (conf == null)
            {
                return BadRequest();
            }            
            _configuracao.Add(conf);
            return CreatedAtRoute("GetConfig", new { id = conf.IdConfiguracao }, conf);
        }

        [HttpGet("{id}", Name = "GetConfig")]
        public IActionResult GetById(long id)
        {

            var cnf = _configuracao.Find(id);
            if (cnf == null)
                return BadRequest();
            return new ObjectResult(cnf);
        }
    }
}
