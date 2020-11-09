using EFCore.Domain;
using EFCore.Domain.Model;
using EFCore.Domain.ViewModel;
using EFCore.Infra.Data.Configuration;
using EFCore.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public async Task<bool> ExistHeroi(int Id)
        {
            logger.LogInformation("ExistHeroi Repository - Início");
            var exist = await ExistAsync(h => h.Id == Id);
            logger.LogInformation("ExistHeroi Repository - Fim");
            return exist;
        }

        public async Task<IEnumerable<HeroiViewModel>> GetListHeroiAsync()
        {
            logger.LogInformation("GetListHeroiAsync - Início");
            var lst = await Query.Include(h => h.IdentidadeSecreta)
                       .AsNoTracking().OrderBy(h => h.Id)
                       .Select(s => new HeroiViewModel
                       {
                           Nome = s.Nome,
                           NomeReal = s.IdentidadeSecreta.NomeReal

                       }).ToListAsync();

            logger.LogInformation("GetListHeroiAsync - Fim");
            return lst;
        }

        public async Task<Heroi> GetHeroiByIdAsync(int Id)
        {
            logger.LogInformation("GetHeroiByIdAsync Repository - Início");

            var lst = await Query.Include(h => h.IdentidadeSecreta)
                      .Where(h => h.Id == Id)
                      .AsNoTracking()
                      .FirstOrDefaultAsync();

            logger.LogInformation("GetHeroiByIdAsync Repository - Fim");
            return lst;
        }

        public async Task<HeroiViewModel> GetCodenomeNomeByIdAsync(int Id)
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
    }
}
