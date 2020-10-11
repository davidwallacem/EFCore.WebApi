using System.Collections.Generic;

namespace EFCore.WebApi.Models
{
    public class Heroi
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IdentidadeSecreta IdentidadeSecreta { get; set; }
        public ICollection<Arma> Armas { get; set; }
        public ICollection<HeroiBatalha> HeroisBatalhas { get; set; }
    }
}
