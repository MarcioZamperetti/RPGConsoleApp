using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPGConsole
{
    class Program
    {
        //public string resposta;
        public static void Main(string[] args)
        {
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
            lore1.parte1(nome);


            //LIXO//
            Inimigos Inimigo = new Inimigos();
            jogador1.nomeinimigo = Inimigo.nome = "ratinho";
            jogador1.vidainimigo = Inimigo.força = 2;
            jogador1.vidainimigo = Inimigo.vida = 5;

            Console.WriteLine("Voce viu um " + jogador1.nomeinimigo + " Voce deseja atacalo? 1-Atacar ou 2-Correr 3-Auto-Ataque");
            jogador1.resposta = Console.ReadLine();
            jogador1.Batalhar(jogador1);
  
            Console.WriteLine("Voltou pro game");

            Console.ReadKey();



        }
    }
}