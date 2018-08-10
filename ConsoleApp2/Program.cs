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
            /////////////////CRIAÇÂO DE PERSONAGEM///////////////////////
            #region Criação de perssonagem
            while (resposta == "não")
            {
                Console.ForegroundColor = ConsoleColor.White;
                
                Console.WriteLine("Digite seu nome");
                jogador1.nome = Console.ReadLine();
                Console.WriteLine(jogador1.nome + " Qual sua Idade?");
                jogador1.idade = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(jogador1.nome + " Escolha uma classe: " + "Arqueiro, Mago ou Guerreiro");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Digite 1 para Arquerio: Força 2, Inteligencia 2, Vida 10");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Digite 2 para Mago: Força 1, Inteligencia 4, Vida 5");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite 3 para Guerreiro: Força 4, Inteligencia 0, Vida 15");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Digite o nome da classe que deseja:");
                jogador1.classe = Console.ReadLine();

                switch (jogador1.classe)
                {
                    case "1": //Arqueiro
                        jogador1.classe = "Arqueiro";
                        Console.WriteLine("Confirme seus dados, NOME: " + jogador1.nome + " Idade: " + jogador1.idade + " CLasse " + jogador1.classe);
                        jogador1.força = 3;
                        jogador1.inteligencia = 2;
                        jogador1.vida = 15;
                        Console.WriteLine("Seus dados estão corretos? " + "1-sim ou 2-não");
                        resposta = Console.ReadLine();
                        break;

                    case "2"://MAgo
                        jogador1.classe = "Mago";
                        Console.WriteLine("Confirme seus dados, NOME: " + jogador1.nome + " Idade: " + jogador1.idade + " CLasse " + jogador1.classe);
                        jogador1.força = 2;
                        jogador1.inteligencia = 4;
                        jogador1.vida = 10;
                        Console.WriteLine("Seus dados estão corretos? " + "1-sim ou 2-não");
                        resposta = Console.ReadLine();
                        break;
                    case "3"://Guerreiro
                        jogador1.classe = "Guerreiro";
                        Console.WriteLine("Confirme seus dados, NOME: " + jogador1.nome + " Idade: " + jogador1.idade + " CLasse " + jogador1.classe);
                        jogador1.força = 5;
                        jogador1.inteligencia = 1;
                        jogador1.vida = 20;
                        Console.WriteLine("Seus dados estão corretos? " + "1-sim ou 2-não");
                        resposta = Console.ReadLine();
                        break;
                }
                
            }
            Console.WriteLine("Personagem criado com sucesso.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nome: " + jogador1.nome);
            Console.WriteLine("Idade: " + jogador1.idade);
            Console.WriteLine("Classe: " + jogador1.classe);
            Console.WriteLine("");
            Console.WriteLine("Atributos:");
            Console.WriteLine("Força: " + jogador1.força);
            Console.WriteLine("Inteligencia: " + jogador1.inteligencia);
            Console.WriteLine("Vida: " + jogador1.vida);
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
            string nome = jogador1.nome;

            lore1.parte1(nome);

            Inimigos Inimigo = new Inimigos();
            jogador1.nomeinimigo = Inimigo.nome = "ratinho";
            jogador1.vidainimigo = Inimigo.força = 2;
            jogador1.vidainimigo = Inimigo.vida = 5;

            Console.WriteLine("Voce viu um " + jogador1.nomeinimigo + " Voce deseja atacalo? 1-Atacar ou 2-Correr 3-Auto-Ataque");
            jogador1.resposta = Console.ReadLine();
            
            lore1.parte1(nome);
            jogador1.Batalhar();
  
            Console.WriteLine("Voltou pro game");

            Console.ReadKey();



        }
    }
}
//Marcio Zamperetti