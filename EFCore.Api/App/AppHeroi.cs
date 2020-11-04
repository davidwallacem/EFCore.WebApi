using EFCore.Api.Interface;
using EFCore.Domain;
using EFCore.Domain.ViewModel;
using EFCore.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Api.App
{
    public class AppHeroi : IAppHeroi
    {
        public readonly IRepositoryHeroi _heroi;
        public AppHeroi(IRepositoryHeroi heroi)
        {
            _heroi = heroi;
        }

        public bool ExistHeroi(int Id)
        {
            return _heroi.GetBy(h => h.Id == Id).Any();
        }

        public Heroi GetHeroiById(int Id)
        {
            return _heroi.FindById(Id);
        }

        public async Task<bool> SalvarHeroi(Heroi model)
        {
            _heroi.Add(model);
            return await _heroi.SaveChangesAsync();
        }

        public async Task<bool> AtualizarHeroi(Heroi model)
        {
            _heroi.Update(model);
            return await _heroi.SaveChangesAsync();
        }

        public IQueryable GetAllHerois() =>
                _heroi.GetAll()
                      .Include(h => h.IdentidadeSecreta)
                      .Include(h => h.Armas)
                      .Include(h => h.HeroisBatalhas)
                      .ThenInclude(h => h.Batalha)
                      .AsNoTracking().OrderBy(h => h.Id); 

        public IQueryable GetHeroisById(int Id) =>
            _heroi.GetBy(h => h.Id == Id)
                      .Include(h => h.IdentidadeSecreta)
                      .Include(h => h.Armas)
                      .Include(h => h.HeroisBatalhas)
                      .ThenInclude(h => h.Batalha)
                      .AsNoTracking().OrderBy(h => h.Id)
                      .Select(s => new HeroiViewModel { 
                            Nome = s.Nome
                      });

        public async Task<bool> DeletarHeroi(Heroi model)
        {
            _heroi.Delete(model);
            return await _heroi.SaveChangesAsync();
        }
    }
}
