using EFCore.Api.Interface;
using EFCore.Domain;
using EFCore.Domain.ViewModel;
using EFCore.Infra.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.Api.Services
{
    public class ServiceHeroi : IServiceHeroi
    {
        private readonly ILogger<ServiceHeroi> logger;
        private readonly IRepositoryHeroi heroi;
        public ServiceHeroi(ILogger<ServiceHeroi> logger, IRepositoryHeroi heroi)
        {
            this.logger = logger;
            this.heroi = heroi;
        }

        public async Task<bool> ExistHeroiById(int Id)
        {
            try
            {
                logger.LogInformation("ExistHeroi Service - Início");
                var exist = await heroi.ExistAsync(h => h.Id == Id);
                logger.LogInformation("ExistHeroi Service - Fim");
                return exist;
            }
            catch (Exception ex)
            {

                logger.LogError("ExistHeroiById Service: {erro}" + ex, ex.InnerException.Message);
                throw new Exception($"ExistHeroiById Service: {ex.InnerException.Message}");
            }
        }

        public async Task<IEnumerable<HeroiViewModel>> ListHeroiAsync()
        {
            try
            {
                logger.LogInformation("ListHeroiAsync Service - Início");
                var lst = await heroi.GetListHeroiAsync();
                logger.LogInformation("ListHeroiAsync Service - Fim");
                return lst;
            }
            catch (Exception ex)
            {
                logger.LogError("ListHeroiAsync Service: {erro} " + ex, ex.InnerException.Message);
                throw new Exception($"ListHeroiAsync Service: {ex.InnerException.Message}");
            }
        }

        public async Task<bool> SalvarHeroi(Heroi model)
        {
            try
            {
                logger.LogInformation("SalvarHeroi Service - Add dados");
                heroi.Add(model);
                logger.LogInformation("SalvarHeroi Service - Salvando os dados na tabela");
                return await heroi.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("SalvarHeroi Service: {erro} " + ex, ex.InnerException.Message);
                throw new Exception($"SalvarHeroi Service: {ex.InnerException.Message}");
            }
        }

        public async Task<bool> AtualizarHeroi(Heroi model)
        {
            try
            {
                logger.LogInformation("AtualizarHeroi Service - Início");
                heroi.Update(model);
                logger.LogInformation("AtualizarHeroi Service - Fim");
                return await heroi.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("AtualizarHeroi Service: {erro} " + ex, ex.InnerException.Message);
                throw new Exception($"AtualizarHeroi Service: {ex.InnerException.Message}");
            }
        }

        public async Task<Heroi> HeroiByIdAsync(int Id)
        {
            try
            {
                logger.LogInformation("HeroiByIdAsync Service - Início");
                var result = await heroi.GetHeroiByIdAsync(Id);
                logger.LogInformation("HeroiByIdAsync Service - Início");
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError("HeroiByIdAsync Service: {erro} " + ex, ex.InnerException.Message);
                throw new Exception($"HeroiByIdAsync Service: {ex.InnerException.Message}");
            }

        }

        public async Task<HeroiViewModel> CodenomeNomeByIdAsync(int Id)
        {
            try
            {
                logger.LogInformation("CodenomeNomeByIdAsync Service - Início");
                var result = await heroi.GetCodenomeNomeByIdAsync(Id);
                logger.LogInformation("CodenomeNomeByIdAsync Service - Início");
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError("CodenomeNomeByIdAsync Service: {erro} " + ex, ex.InnerException.Message);
                throw new Exception($"CodenomeNomeByIdAsync Service: {ex.InnerException.Message}");
            }

        }

        public async Task<bool> DeletarHeroi(Heroi model)
        {
            try
            {
                logger.LogInformation("DeletarHeroi Service - Início");
                heroi.Remove(model);
                logger.LogInformation("DeletarHeroi Service - Fim");
                return await heroi.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("DeletarHeroi Service: {erro} " + ex, ex.InnerException.Message);
                throw new Exception($"DeletarHeroi Service: {ex.InnerException.Message}");
            }
            
        }
    }
}
