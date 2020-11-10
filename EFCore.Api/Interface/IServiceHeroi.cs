using EFCore.Domain;
using EFCore.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.Api.Interface
{
    public interface IServiceHeroi
    {
        Task<bool> ExistHeroiById(int Id);

        Task<IEnumerable<HeroiViewModel>> ListHeroiAsync();

        Task<bool> SalvarHeroi(Heroi model);

        Task<bool> AtualizarHeroi(Heroi model);

        Task<Heroi> HeroiByIdAsync(int Id);

        Task<HeroiViewModel> CodenomeNomeByIdAsync(int Id);

        Task<bool> DeletarHeroi(Heroi model);
    }
}
