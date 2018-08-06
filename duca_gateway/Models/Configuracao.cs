using System;
using System.Collections.Generic;

namespace duca_gateway.Models
{
    public partial class Configuracao
    {
        public int IdConfiguracao { get; set; }
        public int IdLojista { get; set; }
        public string Stone { get; set; }
        public string Cielo { get; set; }
        public string Antifraude { get; set; }
        public string RuleVisa { get; set; }
        public string RuleMaster { get; set; }
        public string Stonekey { get; set; }
        public string Cielokey { get; set; }

        public Lojista IdLojistaNavigation { get; set; }
    }
}
