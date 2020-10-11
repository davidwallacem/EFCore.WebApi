using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore.Infra.Data.Configuration
{
    public class HeroiContext : DbContext
    {

        /// <summary>
        /// Variavel static criada para utilizar o LoggerFactory
        /// </summary>
        /// <param name="optionsBuilder"></param>
        public static readonly LoggerFactory _myLoggerFactory =
            new LoggerFactory(new[] {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        });

        public HeroiContext()
        {
        }

        /// <summary>
        /// Construtor estruturado para receber "Configuration.GetConnectionString" no Startup
        /// </summary>
        /// <param name="options"></param>
        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options) { }

        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<HeroiBatalha> HeroiBatalha { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadeSecreta { get; set; }

        /// <summary>
        /// Comentar depois quando criar injeção de dependência
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HeroiApp;Data Source=localhost\\SQLEXPRESS");
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        ///// <summary>
        ///// Adicionando o Logger no Builder para retonar os comando enviado para o Banco de Dados.
        ///// </summary>
        ///// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
            });
        }
    }
}
