using EFCore.Domain;
using EFCore.Infra.Data.Configuration;
using EFCore.Infra.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace EFCore.Infra.Repositorys
{
    public class RepositoryHeroi : Repository<Heroi>, IRepositoryHeroi
    {
        private readonly ILogger<RepositoryHeroi> logger;
        private readonly HeroiContext context;
        public RepositoryHeroi(ILogger<RepositoryHeroi> logger, HeroiContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public IEnumerable<Heroi> SelectHeroiAll()
        {
            logger.LogInformation("Consulta no banco de dados - Inicio");
            var lst = GetList();
            logger.LogInformation("Consulta no banco de dados - Fim");
            return lst;
        }
    }
}
