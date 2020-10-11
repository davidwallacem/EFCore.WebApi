using EFCore.Domain;
using EFCore.Infra.Data.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroiContext _context;
        public ValuesController(HeroiContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet("filtro/{nome}")]
        public IActionResult GetFiltro(string nome)
        {
            //Lambda
            var listHeroi = _context.Herois
                .Where(h => h.Nome.Contains(nome)).ToList();

            //LINQ
            //var listHeroi = (from heroi in _context.Herois
            //                 where heroi.Nome.Contains(nome)
            //                 select heroi).ToList();

            return Ok(listHeroi);
        }

        // GET api/<ValuesController>/5
        [HttpGet("inserir/{nameHero}")]
        public IActionResult GetInserir(string nameHero)
        {
            var heroi = new Heroi() { Nome = nameHero };
            _context.Herois.Add(heroi);
            _context.SaveChanges();

            return Ok();
        }

        // GET api/<ValuesController>/5
        [HttpGet("atualizar/{nameHero}")]
        public IActionResult GetAtualizar(int Id)
        {
            var heroi = _context.Herois
                .Where(h => h.Id == Id)
                .FirstOrDefault();

            heroi.Nome = "Homem Aranha";
            _context.SaveChanges();

            return Ok();
        }

        // POST api/<ValuesController>
        [HttpGet("AddRange")]
        public IActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi { Nome = "Capitão América" },
                new Heroi { Nome = "Doutor Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arqueiro" },
                new Heroi { Nome = "Capitã Marvel" }
                );
            _context.SaveChanges();
            return Ok();
        }


        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // Method intentionally left empty.
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // Method intentionally left empty.
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("deletar/{Id}")]
        public void Delete(int Id)
        {
            //Lambda
            var heroi = _context.Herois
                .Where(h => h.Id == Id)
                .Single();

            _context.Herois.Remove(heroi);
            _context.SaveChanges();

        }
    }
}
