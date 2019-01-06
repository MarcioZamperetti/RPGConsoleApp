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
            Lore lore1;
            lore1 = new Lore();
            string resposta = "não";
            Personagem jogador1;
            jogador1 = new Personagem();
            //public string resposta = "não";

            ////////////////////INICIO DO JOGO//////////////////////////
            lore1.inicio();
            ///////////////////CRIAR PERSONAGEM/////////////////////////
            jogador1.CriarPersonagem(jogador1);
            string nome = jogador1.nome;
            ////////////////////PARTE 1 DO GAME/////////////////////////
            lore1.parte1(nome, jogador1);


            //LIXO//

            Console.WriteLine("Voltou pro game");

            Console.ReadKey();



        }
    }
}