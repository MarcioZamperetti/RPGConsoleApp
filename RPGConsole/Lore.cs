﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsole
{
    class Lore
    {
        public string seleção;
        public bool selecaoValida;
        //public string texto;

        public void inicio()
        {
            try
            {
                seleção = "0";

                while (seleção == "0")
                {
                    Console.WriteLine("Mundo de Mystara");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Digite 1 para iniciar o jogo");
                    Console.WriteLine("Digite 2 para ir para o sobre");
                    Console.WriteLine("Digite 3 para testar o sistema de batalha");
                    Console.WriteLine("Digite 4 para testar o sistema de comprade item");
                    Console.WriteLine("Digite 5 para ver os comandos basicos");
                    seleção = Console.ReadLine();
                    selecaoValida = false;
                    if (seleção == "1")
                    {
                        selecaoValida = true;
                    }
                    if (seleção == "2")
                    {
                        Console.WriteLine("Este jogo foi desenvolvido para aprender c#, de uma forma não maçante, encorajo todos que querem aprender a programar a criar um jogo.");
                        Console.WriteLine("Aperte alguma tecla para voltar para o menu");
                        Console.ReadKey();
                        seleção = "0";
                            selecaoValida = true;
                    }
                    if (seleção == "3")
                    {
                        selecaoValida = true;
                        Personagem jogador1 = new Personagem();
                        jogador1.CriarPersonagem(jogador1);
                        while (seleção == "3")
                        {
                            Inimigos inimigo = Inimigos.CriaçãoInimigos("rato");
                            Console.WriteLine("Voce viu um " + inimigo.nome + " Voce deseja? 1-Atacar ou 2-Correr 3-Auto-Ataque");
                            jogador1.resposta = Console.ReadLine();
                            jogador1.Batalhar(jogador1, inimigo);
                        }

                    }
                    if (seleção == "4")
                    {
                        selecaoValida = true;
                        Personagem jogador1 = new Personagem();
                        Console.WriteLine("Total de gold do personagem:");
                        jogador1.gold = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Total de silver do personagem:");
                        jogador1.silver = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nome do item a ser comprado:");
                        string nome = Console.ReadLine();
                        Itens item = new Itens();
                        item.nome = nome;
                        Console.WriteLine("Valor do item a ser comprado em silver:");
                        int valor = Convert.ToInt32(Console.ReadLine());
                        jogador1.ComprarItem(jogador1, valor, item);
                    }
                    if (seleção == "5")//Lista de comandos basicos
                    {
                        selecaoValida = true;
                        Console.WriteLine("Lista de comandos basicos:");
                        Console.WriteLine("olhar bag");
                        Console.WriteLine("remover item");
                        Console.WriteLine("beber pocão");
                        Console.WriteLine("Digite algum comando para testar sua ação:");
                        seleção = Console.ReadLine();
                    }
                    if (seleção == "olhar bag")
                    {
                        selecaoValida = true;
                        Personagem jogador1 = new Personagem();
                        jogador1.OlharBag(jogador1);
                    }
                    if (seleção == "remover item")
                    {
                        selecaoValida = true;
                        Console.WriteLine("Qual item você gostaria de remover da sua bag?");
                        string nomeItem = Console.ReadLine();
                        Itens novoItem = new Itens();
                        novoItem.nome = nomeItem;
                        Personagem jogador1 = new Personagem();
                        jogador1.RemoverItemNaBag(jogador1, novoItem);
                    }
                    if (seleção == "beber poção")
                    {
                        selecaoValida = true;
                        string nomePoçao = "poção pequena";
                        Personagem jogador1 = new Personagem();
                        Itens novoItem = new Itens();
                        novoItem.nome = nomePoçao;
                        jogador1.AdicionarItemNaBag(jogador1, novoItem);
                        Console.WriteLine("primeiro didgite 'olhar bag' para ver os seus itens na bag");
                        Console.ReadLine();
                        jogador1.OlharBag(jogador1);
                        Console.WriteLine("Qual poção você gostaria de beber?");
                        nomePoçao = Console.ReadLine();
                        jogador1.BeberPocao(jogador1, novoItem);
                    }
                    if (selecaoValida == false)
                    {
                        inicio();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Selecione uma opção valida");
                inicio();
            }
        }
        public void parte1(string nome)
        {
            string resposta;
            Console.WriteLine("/////////////////////////INICIO///////////////////////////");
            Console.WriteLine("Era tarde da noite e você estava em uma taverna bebendo cerveja, você acabara de voltar de um trabalho, escoltar Sir Benish até as vilas mais distantes do castelo para recolher os impostos da colheita de verão, um trabalho relativamente simples e que lhe rendeu um pagamento de 5 moedas de ouro, que você gastara agora na taverna com cerveja e gorjetas para os bardos e dançarinas.");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("Entre uma cerveja e outra, entra uma mulher na taverna. Ela estava vestindo um gibão de couro fervido, uma roupa nada usual a uma mulher. Ela entra na caverna com um ar de espanto e medo, e se dirige até o balcão, Tira de uma pequena bolsa de couro que carregava consigo um pergaminho coloca na bancada.");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("Mesmo sem ouvir a conversa, você nota que ela está tentando vender o pergaminho ao taverneiro.");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("O taverneiro faz um sinal que não quer comprar nada e a manda embora com um gesto, então a mulher olha em volta e se dirige até sua mesa.");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("Mulher: Boa noite Sir, notei pelas suas vestimentas que és um aventureiro, você ainda vestia sua cota de malha, estou vendendo este pergaminho que leva a um tesouro a muito esquecido, você gostaria de compra-lo? Estou vendendo por 50 moedas de ouro.(você póssuia apenas mais 3 moedas de outro em sua bolsa, já destinadas a mais cervejas.");
            Console.WriteLine("1 – Gostaria sim, mas não tenho toda essa quantia de dinheiro.");
            Console.WriteLine("2 – Não tenho interesse nenhum nisso.");
            Console.WriteLine("3 - Ei este pergaminho me pertence me devolva (roubar pergaminho)");
            Console.WriteLine("Escolha sua resposta: 1, 2 ou 3");
            Console.WriteLine("");
            resposta = Console.ReadLine();
            if (resposta == "1")
            {
                Console.WriteLine("Mulher: Hmmm, o que podemos fazer é o seguinte, você me leva até lá e dividimos o valor do tesouro");
                Console.ReadKey();
                Console.WriteLine(nome + ": Claro vamos nessa.");
            }
            if (resposta == "2")
            {
                Console.WriteLine("Mulher: Posso saber o motivo?");
                Console.ReadKey();
                Console.WriteLine(nome + ": Não tenho dinheiro.");
                Console.ReadKey();
                Console.WriteLine("Mulher: Hmmm, o que podemos fazer é o seguinte, você me leva até lá e dividimos o valor do tesouro");
                Console.ReadKey();
                Console.WriteLine(nome + ": Claro vamos nessa.");
            }
            if (resposta == "3")
            {
                Console.WriteLine("Mulher Ei, Isso é meu.");
                Console.WriteLine("A mulher começa a falar palavras incompreensíveis, sumona uma bola de fogo e a atira contra você");
                Console.WriteLine("Você morreu");
            }
            Console.WriteLine("ccccccccccccccccccccccccccc");
            resposta = Console.ReadLine();

        }
            
    }
}
