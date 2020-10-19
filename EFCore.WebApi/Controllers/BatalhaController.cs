using EFCore.Domain;
using EFCore.Infra.Data.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        public readonly HeroiContext _context;
        private readonly ILogger<ValuesController> _logger;
        public BatalhaController(HeroiContext context, ILogger<ValuesController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET: api/<BatalhaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Cadastra uma batalha no Banco de Dados.
        /// </summary>
        /// <param name="model">Model a ser validada</param>
        /// <response code="200">O usuário foi cadastrado com sucesso.</response>
        /// <response code="400">O servidor não entendeu a requisição pois está com uma sintaxe inválida.</response>
        /// <response code="404">Não foi encontrado o ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar o Heroi.</response>
        // POST api/<BatalhaController>
        [HttpPost("PostBatalha")]
        public IActionResult PostBatalha(Batalha model)
        {
            try
            {
                _context.Batalhas.Add(model);
                _context.SaveChanges();
                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        /// <summary>
        /// Atualiza uma batalha no Banco de Dados específico por ID.
        /// </summary>
        /// <param name="Id">Id da Batalha</param>
        /// <param name="model">Model a ser validada</param>
        /// <response code="200">O usuário foi cadastrado com sucesso.</response>
        /// <response code="400">O servidor não entendeu a requisição pois está com uma sintaxe inválida.</response>
        /// <response code="404">Não foi encontrado o ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar o Heroi.</response>
        // PUT api/<BatalhaController>/5
        [HttpPut("PutBatalha/{id}")]
        public IActionResult PutBatalha(int Id, Batalha model)
        {
            try
            {
                if (_context.Batalhas.AsNoTracking().FirstOrDefault(h => h.Id == Id) != null)
                {
                    _context.Batalhas.Update(model);
                    _context.SaveChanges();
                    return Ok("BAZINGA!!!");
                }
                else
                {
                    return Ok("Não encontrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
