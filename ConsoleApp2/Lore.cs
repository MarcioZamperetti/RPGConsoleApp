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
        //public string texto;

        public void inicio()
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
                seleção = Console.ReadLine();

                if (seleção == "2")
                {
                    Console.WriteLine("Este jogo foi desenvolvido para aprender sobre c#, de uma forma não maçante, encorajo todos que querem aprender a programar a criar um jogo seu.");
                    Console.WriteLine("Aperte alguma tecla para voltar para o menu");
                    Console.ReadKey();
                    seleção = "0";
                }
                else
                {
                    Console.WriteLine("Bom Jogo...");
                }
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
