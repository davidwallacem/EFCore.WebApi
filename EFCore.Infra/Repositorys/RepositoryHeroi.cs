using EFCore.Domain;
using EFCore.Infra.Data.Configuration;
using EFCore.Infra.Interfaces;

namespace EFCore.Infra.Repositorys
{
    public class RepositoryHeroi : Repository<Heroi>, IRepositoryHeroi
    {
        private readonly HeroiContext context;
        public RepositoryHeroi(HeroiContext context) : base(context)
        {
            this.context = context;
        }
    }
}
