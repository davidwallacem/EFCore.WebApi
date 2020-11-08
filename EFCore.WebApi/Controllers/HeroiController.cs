using EFCore.Api.Interface;
using EFCore.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly IAppHeroi _heroi;
        private readonly ILogger<HeroiController> _logger;
        public HeroiController(IAppHeroi heroi, ILogger<HeroiController> logger)
        {
            _heroi = heroi;
            _logger = logger;
        }

        // GET api/<HeroiController>/5
        [HttpGet("Get/{id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                //var herois = _heroi.GetHeroisById(Id);
                //return Ok(herois);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<HeroiController>/GetHeroi
        [HttpGet("GetHeroi")]
        public IActionResult GetHeroi()
        {
            try
            {
                _logger.LogInformation("Metodo GetHeroi - Inicio");
                var herois = _heroi.GetAllHerois();
                _logger.LogInformation("Metodo GetHeroi - Fim");
                return Ok(herois);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
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
        public async Task<IActionResult> PostHeroi(Heroi model)
        {
            try
            {
                if (await _heroi.SalvarHeroi(model))
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
        public async Task<IActionResult> PutHeroi(int Id, Heroi model)
        {
            try
            {
                if (_heroi.ExistHeroi(Id))
                {
                    if (await _heroi.AtualizarHeroi(model))
                    {
                        return Ok("BAZINGA!!!");
                    }
                }
                else
                {
                    return Ok("Não encontrado!!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Salvou");
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var result = _heroi.GetHeroiById(Id);
                if (result != null)
                {
                    if (await _heroi.DeletarHeroi(result))
                    {
                        return Ok("BAZINGA!!!");
                    }
                }
                else
                {
                    return Ok("Não encontrado!!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Deletado");
        }
    }
}
