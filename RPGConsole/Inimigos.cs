using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsole
{
    public class Inimigos
    {
        public string nome { get; set; }
        public int força { get; set; }
        public int vida { get; set; }
        public int xpGanho { get; set; }

        public static Inimigos CriaçãoInimigos(string nome)
        {
            Inimigos novoInimigo = new Inimigos();
            switch (nome)
            {
                case "rato":
                    novoInimigo.nome = "Rato";
                    novoInimigo.vida = 3;
                    novoInimigo.força = 3;
                    novoInimigo.xpGanho = 10;
                    return novoInimigo;
                case "esqueleto":
                    novoInimigo.nome = "Esqueleto";
                    novoInimigo.vida = 5;
                    novoInimigo.força = 5;
                    novoInimigo.xpGanho = 15;
                    return novoInimigo;
            }
            return novoInimigo;
        }
    }
}
