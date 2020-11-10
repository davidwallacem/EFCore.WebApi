using EFCore.Api.Interface;
using EFCore.Domain;
using EFCore.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroiController : ControllerBase
    {
        private readonly IServiceHeroi heroi;
        private readonly ILogger<HeroiController> logger;
        public HeroiController(IServiceHeroi heroi, ILogger<HeroiController> logger)
        {
            this.heroi = heroi;
            this.logger = logger;
        }

        // GET api/<HeroiController>/5
        [HttpGet("Personagem/{Id}")]
        [ProducesResponseType(typeof(HeroiViewModel), 200)]
        //[ProducesResponseType(500)]
        public async Task<IActionResult> Personagem(int Id)
        {
            try
            {
                logger.LogInformation("Pesquisando Heroi pelo Id: {Id}.", Id);
                var result = await heroi.CodenomeNomeByIdAsync(Id);
                if (result != null)
                {
                    logger.LogInformation("O Heroi {nome} foi retornado.", result.Nome);
                    return Ok(result);
                }
                if (true)
                {
                    logger.LogWarning("Esse personagem não existe.");
                    return NotFound("Esse personagem não existe.");
                }
                
            }
            catch (Exception ex)
            {
                logger.LogError("Personagem HeroiController - " + ex, ex.Message);
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<HeroiController>/GetHeroi
        [HttpGet()]
        public async Task<IActionResult> Listar()
        {
            try
            {
                logger.LogInformation("Listando os Herois.");
                var herois = await heroi.ListHeroiAsync();
                logger.LogInformation("Herois Listados.");
                return Ok(herois);
            }
            catch (Exception ex)
            {
                logger.LogError("Listar HeroiController - " + ex, ex.Message);
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
        [HttpPost()]
        public async Task<IActionResult> Inserir(Heroi model)
        {
            try
            {
                logger.LogInformation("Inserindo um novo Heroi");
                if (await heroi.SalvarHeroi(model))
                {
                    logger.LogInformation("Heroi Inserido.");
                    return Ok("BAZINGA!!!");
                }
                else
                {
                    logger.LogWarning("Os dados não foram salvos.");
                    return BadRequest("Os dados não foram salvos.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Inserir HeroiController - " + ex, ex.Message);
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
        [HttpPut()]
        public async Task<IActionResult> Atualizar(int Id, Heroi model)
        {
            try
            {
                logger.LogInformation("Verificando se existe o Heroi.");
                if (await heroi.ExistHeroiById(Id))
                {
                    logger.LogInformation("Atualizando o Heroi.");
                    if (await heroi.AtualizarHeroi(model))
                    {
                        logger.LogInformation("Heroi Atualizado.");
                        return Ok("BAZINGA!!!");
                    }
                    else
                    {
                        logger.LogWarning("Os dados não foram atualizados.");
                        return BadRequest("Os dados não foram atualizados.");
                    }
                }
                else
                {
                    logger.LogError("Não encontrado!!!");
                    return Ok("Não encontrado!!!");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Atualizar HeroiController - " + ex, ex.Message);
                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete()]
        public async Task<IActionResult> Deletar(int Id)
        {
            try
            {
                logger.LogInformation("Buscando Heroi do Id:{Id}.");
                var result = await heroi.HeroiByIdAsync(Id);
                if (result != null)
                {
                    logger.LogInformation("Deletando o Heroi do Id:{Id}.");
                    if (await heroi.DeletarHeroi(result))
                    {
                        logger.LogInformation("Heroi Deletado.");
                        return Ok("BAZINGA!!!");
                    }
                    else
                    {
                        logger.LogWarning("Os dados não foram deletados.");
                        return BadRequest("Os dados não foram deletados.");
                    }
                }
                else
                {
                    return Ok("Não encontrado!!!");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Deletar HeroiController - " + ex, ex.Message);
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}
