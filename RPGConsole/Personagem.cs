﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace RPGConsole
{
    public class Personagem
    {
        public string nome;
        public int idade;
        public string classe;
        public int força;
        public int inteligencia;
        public int vida;
        public int vidainimigo;
        public int ataquainimigo;
        public string resposta;
        public string nomeinimigo;
        public string fimdebatalha;
        public int xp;
        public int xpProxNivel = 100;
        public int xpGanho;
        public int nivel;
        public int gold;
        public int silver;


        public void Atacar()
        {
            Random rdn = new Random();
            int dano = rdn.Next(0, força);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1Seu dano foi: " + dano);
            vidainimigo = vidainimigo - dano;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1Vida do Inimigo: " + vidainimigo);
            Console.ReadKey();
        }
        public void Atacarinimigo()
        {
            {
                Random rdn = new Random();
                int dano = rdn.Next(0, ataquainimigo);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("O Inimigo Causou: " + dano);
                vida = vida - dano;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Sua Vida: " + vida);
            }
        }
        public void AutoAtacar()
        {
            Random rdn = new Random();
            int dano = rdn.Next(0, força);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Seu dano foi: " + dano);
            vidainimigo = vidainimigo - dano;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vida do Inimigo: " + vidainimigo);
        }
        public void Atacarm()
        {
            Random rdn = new Random();
            int dano = rdn.Next(0, inteligencia);
        }
        public void Batalhar(Personagem jogador1)
        {
            fimdebatalha = "não";
            while (fimdebatalha == "não")
            {
                while (resposta == "3")
                {
                    while (vidainimigo >= 1)
                    {
                        AutoAtacar();
                        Atacarinimigo();
                        if (vida <= 0)
                        {
                            Console.WriteLine("Voce morreu");
                            Thread.Sleep(1500);
                            Console.Clear();

                        }

                    }
                    fimdebatalha = "sim";
                    resposta = "matou";
                    Console.WriteLine("Você Matou o inimigo");
                    Console.WriteLine("XP ganho: " + xpGanho);
                    xp = xp + xpGanho;
                    Console.WriteLine("XP Total: " + xp);
                    CalcularNivel(jogador1);

                }
                while (resposta == "1")
                {
                    while (vidainimigo >= 1)
                    {
                        Atacar();
                        Atacarinimigo();
                        if (vida <= 0)
                        {
                            Console.WriteLine("Voce morreu");
                            Thread.Sleep(1500);
                            Console.Clear();

                        }

                    }
                    fimdebatalha = "sim";
                    resposta = "matou";
                    Console.WriteLine("Você Matou o Inimigo");
                    Console.WriteLine("XP ganho: " + xpGanho);
                    xp = xp + xpGanho;
                    Console.WriteLine("XP Total: " + xp);
                    CalcularNivel(jogador1);
                }
                while (resposta == "2")
                {
                    Random rdn = new Random();
                    int correr = rdn.Next(1, 23);
                    if (correr == 1)
                    {
                        Console.WriteLine("Voce correu do inimigo");
                        resposta = "correu";
                    }

                    else
                    {
                        Console.WriteLine("Voce falhou em correr do inimigo");
                        Atacarinimigo();
                        Console.WriteLine("1-Atacar 2-Correr 3-Auto Ataque");
                        resposta = Console.ReadLine();
                        fimdebatalha = "não";
                    }

                }
            }
            if (resposta == "matou")
            {
                Console.WriteLine("Boa");
            }
            if (resposta == "correu")
            {
                Console.WriteLine("Boa");
            }
            Console.ReadKey();
        }
        public void CriarPersonagem(Personagem jogador1)
        {
            resposta = "não";
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
                        jogador1.nivel = 1;
                        jogador1.xp = 0;
                        Console.WriteLine("Seus dados estão corretos? " + "1-sim ou 2-não");
                        resposta = Console.ReadLine();
                        break;

                    case "2"://MAgo
                        jogador1.classe = "Mago";
                        Console.WriteLine("Confirme seus dados, NOME: " + jogador1.nome + " Idade: " + jogador1.idade + " CLasse " + jogador1.classe);
                        jogador1.força = 2;
                        jogador1.inteligencia = 4;
                        jogador1.vida = 10;
                        jogador1.nivel = 1;
                        jogador1.xp = 0;
                        Console.WriteLine("Seus dados estão corretos? " + "1-sim ou 2-não");
                        resposta = Console.ReadLine();
                        break;
                    case "3"://Guerreiro
                        jogador1.classe = "Guerreiro";
                        Console.WriteLine("Confirme seus dados, NOME: " + jogador1.nome + " Idade: " + jogador1.idade + " CLasse " + jogador1.classe);
                        jogador1.força = 5;
                        jogador1.inteligencia = 1;
                        jogador1.vida = 20;
                        jogador1.nivel = 1;
                        jogador1.xp = 0;
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
        }
        public void CalcularNivel(Personagem jogador1)
        {
            if (xp >= xpProxNivel)
            {
                nivel = nivel + 1;
                xpProxNivel = xpProxNivel * 2;
                jogador1.nivel = nivel;
                jogador1.vida = vida + vida;
                jogador1.força = força + força;
                jogador1.inteligencia = inteligencia + inteligencia;
                Console.WriteLine("Você subio de Nivel: " + nivel);
                Console.WriteLine("Atributos:");
                Console.WriteLine("Força: " + jogador1.força);
                Console.WriteLine("Inteligencia: " + jogador1.inteligencia);
                Console.WriteLine("Vida: " + jogador1.vida);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void ComprarItem(Personagem jogador1, int valorDoItem, string ItemComprado)
        {
            double totalSilver = (gold * 100) + silver;
            if (valorDoItem > totalSilver)
            {
                Console.WriteLine("Você não possui dinheiro necessario");
            }
            if(valorDoItem <= totalSilver)
            {
                totalSilver = totalSilver - valorDoItem;
                Console.WriteLine("Você comprou um " + ItemComprado + " por: " + valorDoItem + " silvers ");
                if (totalSilver > 100)
                {
                    totalSilver = totalSilver / 100;
                    gold = Convert.ToInt32(Math.Floor(totalSilver));
                    totalSilver = totalSilver - gold;
                    totalSilver = totalSilver * 100;
                    silver = Convert.ToInt32(totalSilver);
                    Console.WriteLine("Troco Gold: " + gold + " Silver: " + silver);

                }
                else
                {
                    silver = Convert.ToInt32(totalSilver);
                    Console.WriteLine("Silver: " + silver);
                }
           
            }

        }
    }
}




