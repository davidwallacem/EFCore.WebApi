using EFCore.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.Api.Interface
{
    public interface IAppHeroi
    {

        bool ExistHeroi(int Id);

        Heroi GetHeroiById(int Id);

        IEnumerable<Heroi> GetAllHerois();

        //IQueryable GetHeroisById(int Id);

        Task<bool> SalvarHeroi(Heroi model);

        Task<bool> AtualizarHeroi(Heroi model);

        Task<bool> DeletarHeroi(Heroi model);
    }
}
