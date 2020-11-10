using EFCore.Domain;
using EFCore.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.Infra.Interfaces
{
    public interface IRepositoryHeroi : IRepository<Heroi>
    {
        Task<IEnumerable<HeroiViewModel>> GetListHeroiAsync();

        Task<Heroi> GetHeroiByIdAsync(int Id);

        Task<HeroiViewModel> GetCodenomeNomeByIdAsync(int Id);
    }
}
