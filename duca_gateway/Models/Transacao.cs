using System;
using System.Collections.Generic;

namespace duca_gateway.Models
{
    public partial class Transacao
    {
        public int IdTransacao { get; set; }
        public int IdLojista { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Cielo { get; set; }
        public string Stone { get; set; }
        public string Visa { get; set; }
        public string Master { get; set; }
        public string CreditCard { get; set; }

        public Lojista IdLojistaNavigation { get; set; }
    }
}
