using System;
using System.Collections.Generic;

namespace duca_gateway.Models
{
    public partial class Lojista
    {
        public Lojista()
        {
            Configuracao = new HashSet<Configuracao>();
            Transacao = new HashSet<Transacao>();
        }

        public int IdLojista { get; set; }
        public string Razaosocial { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public ICollection<Configuracao> Configuracao { get; set; }
        public ICollection<Transacao> Transacao { get; set; }
    }
}
