using EFCore.Api.Interface;
using EFCore.Domain;
using EFCore.Infra.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Api.App
{
    public class AppHeroi : IAppHeroi
    {
        private readonly ILogger<AppHeroi> logger;
        private readonly IRepositoryHeroi heroi;
        public AppHeroi(ILogger<AppHeroi> logger, IRepositoryHeroi heroi)
        {
            this.logger = logger;
            this.heroi = heroi;
        }

        public bool ExistHeroi(int Id)
        {
            return heroi.GetBy(h => h.Id == Id).Any();
        }

        public Heroi GetHeroiById(int Id)
        {
            return heroi.FindById(Id);
        }

        public async Task<bool> SalvarHeroi(Heroi model)
        {
            heroi.Add(model);
            return await heroi.SaveChangesAsync();
        }

        public async Task<bool> AtualizarHeroi(Heroi model)
        {
            heroi.Update(model);
            return await heroi.SaveChangesAsync();
        }

        public IEnumerable<Heroi> GetAllHerois()
        {
            logger.LogInformation("GetAllHeroeis Service - Inicio");
            var lst = heroi.SelectHeroiAll();
            logger.LogInformation("GetAllHeroeis Service - Fim");
            return lst;
        }

        //public IQueryable GetHeroisById(int Id) =>
        //    _heroi.GetBy(h => h.Id == Id)
        //              .Include(h => h.IdentidadeSecreta)
        //              .Include(h => h.Armas)
        //              .Include(h => h.HeroisBatalhas)
        //              .ThenInclude(h => h.Batalha)
        //              .AsNoTracking().OrderBy(h => h.Id)
        //              .Select(s => new HeroiViewModel { 
        //                    Nome = s.Nome
        //              });

        public async Task<bool> DeletarHeroi(Heroi model)
        {
            heroi.Delete(model);
            return await heroi.SaveChangesAsync();
        }
    }
}
