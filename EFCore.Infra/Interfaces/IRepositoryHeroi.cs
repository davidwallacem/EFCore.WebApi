using EFCore.Domain;
using System.Collections.Generic;

namespace EFCore.Infra.Interfaces
{
    public interface IRepositoryHeroi : IRepository<Heroi>
    {
        IEnumerable<Heroi> SelectHeroiAll();
    }
}
