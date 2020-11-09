using EFCore.Domain;
using EFCore.Infra.Data.Configuration;
using EFCore.Infra.Interfaces;

namespace EFCore.Infra.Repositorys
{
    public class RepositoryBatalha : Repository<Batalha>, IRepositoryBatalha
    {
        public RepositoryBatalha(HeroiContext context) : base(context)
        {

        }
    }
}
