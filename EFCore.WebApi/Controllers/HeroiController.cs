using EFCore.Domain;
using EFCore.Infra.Data.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        public readonly HeroiContext _context;
        private readonly ILogger<ValuesController> _logger;
        public HeroiController(HeroiContext context, ILogger<ValuesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET api/<HeroiController>/5
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // GET api/<HeroiController>/GetHeroi
        [HttpGet("GetHeroi")]
        public IActionResult GetHeroi()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        /// <summary>
        /// Cadastra um Heroi e suas Armas no Banco de Dados específico por ID.
        /// </summary>
        /// <param name="model">Model a ser validada</param>
        /// <response code="200">O usuário foi cadastrado com sucesso.</response>
        /// <response code="400">O servidor não entendeu a requisição pois está com uma sintaxe inválida.</response>
        /// <response code="404">Não foi encontrado o ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar o Heroi.</response>
        // POST api/<HeroiController>/PostHeroi/5
        [HttpPost("PostHeroi")]
        public IActionResult PostHeroi(Heroi model)
        {
            try
            {
                _context.Herois.Add(model);
                _context.SaveChanges();
                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        /// <summary>
        /// Atualiza um Heroi e suas Armas específicando ID do Heroi e os Ids de suas Armas.
        /// </summary>
        /// <param name="Id">Id do Heroi</param>
        /// <param name="Nome">Nome do Heroi</param>
        /// <param name="ArmaId1">Id da 1° Arma</param>
        /// <param name="Arma1">Nome da 1° Arma</param>
        /// <param name="ArmaId2">ID da 2° Arma</param>
        /// <param name="Arma2">Nome da 2° Heroi</param>
        /// <response code="200">O Heroi e suas Armas foram atualizados com sucesso.</response>
        /// <response code="400">O servidor não entendeu a requisição pois está com uma sintaxe inválida.</response>
        /// <response code="404">Não foi encontrado o ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao atualizar o Heroi.</response>
        // PUT api/<HeroiController>/PutHeroi/5
        [HttpPut("PutHeroi/{Id}")]
        public IActionResult PutHeroi(int Id, Heroi model)
        {
            try
            {
                if (_context.Herois.AsNoTracking().FirstOrDefault(h => h.Id == Id) != null)
                {
                    _context.Herois.Update(model);
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

        // DELETE api/<HeroiController>/5
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            // Method intentionally left empty.
        }
    }
}
