using EFCore.Domain;
using EFCore.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private readonly IRepositoryBatalha batalha;
        private readonly ILogger<BatalhaController> logger;
        public BatalhaController(IRepositoryBatalha batalha, ILogger<BatalhaController> logger)
        {
            this.batalha = batalha;
            this.logger = logger;
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
        public async Task<IActionResult> PostBatalha(Batalha model)
        {
            try
            {
                batalha.Add(model);
                if (await batalha.SaveChangesAsync())
                {
                    return Ok("BAZINGA!!!");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não Salvou");
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
        public async Task<IActionResult> PutBatalha(int Id, Batalha model)
        {
            try
            {
                if (await batalha.GetAsNoTrackingAsync(h => h.Id == Id) != null)
                {
                    batalha.Update(model);
                    if (await batalha.SaveChangesAsync())
                    {
                        return Ok("BAZINGA!!!");
                    }
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
            return BadRequest("Não Salvou");
        }

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
