using EFCore.Domain;
using EFCore.Domain.ViewModel;
using EFCore.Infra.Data.Configuration;
using EFCore.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Infra.Repositorys
{
    public class RepositoryHeroi : Repository<Heroi>, IRepositoryHeroi
    {
        private readonly ILogger<RepositoryHeroi> logger;
        public RepositoryHeroi(ILogger<RepositoryHeroi> logger, HeroiContext context) : base(context)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<HeroiViewModel>> GetListHeroiAsync()
        {
            try
            {
                logger.LogInformation("GetListHeroiAsync Repository - Início");
                var lst = await Query.Include(h => h.IdentidadeSecreta)
                           .AsNoTracking().OrderBy(h => h.Id)
                           .Select(s => new HeroiViewModel
                           {
                               Nome = s.Nome,
                               NomeReal = s.IdentidadeSecreta.NomeReal

                           }).ToListAsync();

                logger.LogInformation("GetListHeroiAsync Repository - Fim");
                return lst;
            }
            catch (Exception ex)
            {

                logger.LogError("GetListHeroiAsync Repository: {erro}" + ex, ex.InnerException.Message);
                throw new Exception($"GetListHeroiAsync Repository: {ex.InnerException.Message}");
            }
        }

        public async Task<Heroi> GetHeroiByIdAsync(int Id)
        {
            try
            {
                logger.LogInformation("GetHeroiByIdAsync Repository - Início");

                var lst = await Query.Include(h => h.IdentidadeSecreta)
                          .Where(h => h.Id == Id)
                          .AsNoTracking()
                          .FirstOrDefaultAsync();

                logger.LogInformation("GetHeroiByIdAsync Repository - Fim");
                return lst;
            }
            catch (Exception ex)
            {

                logger.LogError("GetHeroiByIdAsync Repository: {erro}" + ex, ex.InnerException.Message);
                throw new Exception($"GetHeroiByIdAsync Repository: {ex.InnerException.Message}");
            }
        }

        public async Task<HeroiViewModel> GetCodenomeNomeByIdAsync(int Id)
        {
            try
            {
                logger.LogInformation("GetCodenomeNomeByIdAsync Repository - Início");

                var lst = await Query.Include(h => h.IdentidadeSecreta)
                          .Where(h => h.Id == Id)
                          .AsNoTracking()
                          .Select(s => new HeroiViewModel
                          {
                              Nome = s.Nome,
                              NomeReal = s.IdentidadeSecreta.NomeReal

                          }).FirstOrDefaultAsync();

                logger.LogInformation("GetCodenomeNomeByIdAsync Repository - Fim");
                return lst;
            }
            catch (Exception ex)
            {

                logger.LogError("GetCodenomeNomeByIdAsync Repository: {erro}" + ex, ex.InnerException.Message);
                throw new Exception($"GetCodenomeNomeByIdAsync Repository: {ex.InnerException.Message}");
            }

        }
    }
}
