﻿using System;
using System.Collections.Generic;

namespace EFCore.WebApi.Models
{
    public class Batalha
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public ICollection<HeroiBatalha> HeroisBatalhas { get; set; }
    }
}
