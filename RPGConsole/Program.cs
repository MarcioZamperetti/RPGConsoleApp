using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace RPGConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            Configuracoes.ConfiguraJanela();
            Lore lore1 = new Lore();
            Personagem jogador1 = new Personagem();

            ////////////////////INICIO DO JOGO//////////////////////////
            lore1.inicio();
            ///////////////////CRIAR PERSONAGEM/////////////////////////
            jogador1.CriarPersonagem(jogador1);
            ////////////////////PARTE 1 DO GAME/////////////////////////
            lore1.parte1(jogador1);

            Console.WriteLine("Voltou pro game");
            Console.ReadKey();
        }
    }
}