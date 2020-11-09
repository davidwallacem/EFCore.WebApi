using EFCore.Api.Interface;
using EFCore.Domain;
using EFCore.Domain.ViewModel;
using EFCore.Infra.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.Api.App
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
            logger.LogInformation("ExistHeroi Service - Início");
            var exist = await heroi.ExistAsync(h => h.Id == Id);
            logger.LogInformation("ExistHeroi Service - Fim");
            return exist;
        }

        public async Task<IEnumerable<HeroiViewModel>> ListHeroiAsync()
        {
            logger.LogInformation("GetAllHeroeis Service - Início");
            var lst = await heroi.GetListHeroiAsync();
            logger.LogInformation("GetAllHeroeis Service - Fim");
            return lst;
        }

        public async Task<bool> SalvarHeroi(Heroi model)
        {
            logger.LogInformation("SalvarHeroi Service - Início");
            heroi.Add(model);
            logger.LogInformation("SalvarHeroi Service - Fim");
            return await heroi.SaveChangesAsync();
        }

        public async Task<bool> AtualizarHeroi(Heroi model)
        {
            logger.LogInformation("AtualizarHeroi Service - Início");
            heroi.Update(model);
            logger.LogInformation("AtualizarHeroi Service - Fim");
            return await heroi.SaveChangesAsync();
        }

        public async Task<Heroi> HeroiByIdAsync(int Id)
        {
            logger.LogInformation("HeroiIdentidadeAsync Service - Início");
            var result = await heroi.GetHeroiByIdAsync(Id);
            logger.LogInformation("HeroiIdentidadeAsync Service - Início");
            return result;
        }

        public async Task<HeroiViewModel> CodenomeNomeByIdAsync(int Id)
        {
            logger.LogInformation("HeroiIdentidadeAsync Service - Início");
            var result = await heroi.GetCodenomeNomeByIdAsync(Id);
            logger.LogInformation("HeroiIdentidadeAsync Service - Início");
            return result;
        }

        public async Task<bool> DeletarHeroi(Heroi model)
        {
            logger.LogInformation("DeletarHeroi Service - Início");
            heroi.Remove(model);
            logger.LogInformation("DeletarHeroi Service - Fim");
            return await heroi.SaveChangesAsync();
        }
    }
}
