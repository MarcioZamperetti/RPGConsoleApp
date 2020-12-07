using System;
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
        static string resposta { get; set; }
        //public string texto;

        public void inicio()
        {
            try
            {
                seleção = "0";

                while (seleção == "0")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
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
                        Configuracoes.MontaPainelDialogos("Olá pessoas, 0/ Esse projeto teve início em 2017 quando comecei a trabalhar como desenvolvedor, a ideia era aprender c# através do desenvolvimento de um jogo de RPG todo textual. Foi a maneira mais legal que eu encontrei para aplicar os conhecimentos adquiridos nas aulas. Encorajo a todos que “brinquem” de fazer um jogo também, ou se quiser contribuir nesse projeto só dar um pull request =D.", "Marcio Zamperetti");
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
                            SistemaDeBatalha SistemaDeBatalha = new SistemaDeBatalha();
                            SistemaDeBatalha.InicioBatalha(jogador1, inimigo);
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
                        Console.WriteLine("beber poção");
                        Console.WriteLine("Digite algum comando para testar sua ação:");
                        seleção = Console.ReadLine();
                    }
                    if (seleção == "olhar bag")
                    {
                        selecaoValida = true;
                        Personagem jogador1 = new Personagem();
                        Itens novoItem = new Itens();
                        novoItem.nome = "Espada Longa";
                        jogador1.AdicionarItemNaBag(jogador1, novoItem);
                        jogador1.OlharBag(jogador1);
                        Console.ReadLine();
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
        public void parte1(Personagem jogador1)
        {
            Console.Clear();
            Configuracoes.MontaPainelDialogos("Era tarde da noite e você estava em uma taverna bebendo cerveja você acabara de voltar de um trabalho, escoltar Sir Benish até as vilas mais distantes do castelo para recolher os impostos da colheita de verão. Um trabalho relativamente simples e que lhe rendeu um pagamento de 5 moedas de ouro, que você gastara na taverna com cerveja e gorjetas para os bardos e dançarinas.", "Narrador");
            Configuracoes.MontaPainelDialogos("Entre uma cerveja e outra, entra uma mulher na taverna. Ela estava vestindo um gibão de couro fervido, uma roupa nada usual para uma mulher. Ela entra na caverna com um ar de espanto e medo, e se dirige até o balcão, Tira de uma pequena bolsa de couro que carregava consigo um pergaminho coloca na bancada.", "Narrador");
            Configuracoes.MontaPainelDialogos("Mesmo sem ouvir a conversa, você nota que ela está tentando vender o pergaminho ao taverneiro. O taverneiro faz um sinal que não quer comprar nada e a manda embora com um gesto, então a mulher olha em volta e se dirige até sua mesa.", "Narrador");
            Configuracoes.MontaPainelDialogos("Boa noite senhor, notei pelas suas vestimentas que és um aventureiro, estou vendendo este pergaminho que leva a um tesouro a muito esquecido, você gostaria de compra-lo? Estou vendendo por 50 moedas de ouro.", "Mulher");
            Console.Clear();
            Console.WriteLine($"╔═══════════════════════════════════════════════════════════════════╗             ");
            Console.WriteLine($"║  Escolha sua Ação:                                                ║              ");
            Console.WriteLine($"║═══════════════════════════════════════════════════════════════════║                ");
            Console.WriteLine($"║ [1] – Gostaria sim, mas não tenho toda essa quantia de dinheiro.  ║                   ");
            Console.WriteLine($"║ [2] – Não tenho interesse nenhum nisso.                           ║                 ");
            Console.WriteLine($"║ [3] - Ei este pergaminho me pertence (roubar pergaminho)          ║                 ");
            Console.WriteLine($"╚═══════════════════════════════════════════════════════════════════╝              ");
            Console.WriteLine("Precione qualquer tecla para continuar");   
            resposta = Console.ReadLine();
            Console.Clear();
            VarificaResposta(resposta, jogador1);
            if (resposta == "1")
            {
                Console.WriteLine("Mulher: Hmmm, o que podemos fazer é o seguinte, você me leva até lá e dividimos o valor do tesouro");
                Console.ReadKey();
                Console.WriteLine(jogador1.nome + ": Claro vamos nessa.");

                Console.WriteLine($"╔═══════════════════════════════════════════════════════════════════╗             ");
                Console.WriteLine($"║  Mulher:                                                          ║              ");
                Console.WriteLine($"║═══════════════════════════════════════════════════════════════════║                ");
                Console.WriteLine($"║ Hmmm, o que podemos fazer é o seguinte,                           ║                   ");
                Console.WriteLine($"║  você me leva até lá e dividimos o valor do tesouro.              ║                 ");
                Console.WriteLine($"╚═══════════════════════════════════════════════════════════════════╝              ");
                Console.WriteLine("Precione qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();

            }
            if (resposta == "2")
            {
                Console.WriteLine("Mulher: Posso saber o motivo?");

                Console.WriteLine($"╔═══════════════════════════════════════════════════════════════════╗             ");
                Console.WriteLine($"║  Mulher:                                                          ║              ");
                Console.WriteLine($"║═══════════════════════════════════════════════════════════════════║                ");
                Console.WriteLine($"║ Posso saber o motivo?                                             ║                   ");
                Console.WriteLine($"╚═══════════════════════════════════════════════════════════════════╝              ");
                Console.WriteLine("Precione qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.ReadKey();
                Console.WriteLine(jogador1.nome + ": Não tenho dinheiro.");
                Console.WriteLine($"╔═══════════════════════════════════════════════════════════════════╗             ");
                Console.WriteLine($"║  Você:                                                            ║              ");
                Console.WriteLine($"║═══════════════════════════════════════════════════════════════════║                ");
                Console.WriteLine($"║ Não tenho dinheiro.                                               ║                   ");
                Console.WriteLine($"╚═══════════════════════════════════════════════════════════════════╝              ");
                Console.WriteLine("Precione qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"╔═══════════════════════════════════════════════════════════════════╗             ");
                Console.WriteLine($"║  Mulher:                                                          ║              ");
                Console.WriteLine($"║═══════════════════════════════════════════════════════════════════║                ");
                Console.WriteLine($"║ Hmmm, o que podemos fazer é o seguinte,                           ║                   ");
                Console.WriteLine($"║  você me leva até lá e dividimos o valor do tesouro.              ║                 ");
                Console.WriteLine($"╚═══════════════════════════════════════════════════════════════════╝              ");
                Console.WriteLine("Precione qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"╔═══════════════════════════════════════════════════════════════════╗             ");
                Console.WriteLine($"║  Você:                                                            ║              ");
                Console.WriteLine($"║═══════════════════════════════════════════════════════════════════║                ");
                Console.WriteLine($"║ Claro, vamos nessa.                                               ║                   ");
                Console.WriteLine($"╚═══════════════════════════════════════════════════════════════════╝              ");
                Console.WriteLine("Precione qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            if (resposta == "3")
            {
                Console.WriteLine($"╔═══════════════════════════════════════════════════════════════════╗             ");
                Console.WriteLine($"║  Mulher:                                                          ║              ");
                Console.WriteLine($"║═══════════════════════════════════════════════════════════════════║                ");
                Console.WriteLine($"║ Ei, Isso é meu. A mulher começa a falar palavras incompreensíveis,║                   ");
                Console.WriteLine($"║  seus olhos ficam escuros, e uma aura negra fica em sua volta     ║                 ");
                Console.WriteLine($"╚═══════════════════════════════════════════════════════════════════╝              ");
                Console.WriteLine("Precione qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Inimigos inimigo = Inimigos.CriaçãoInimigos("mulher");
                SistemaDeBatalha SistemaDeBatalha = new SistemaDeBatalha();
                SistemaDeBatalha.InicioBatalha(jogador1, inimigo);
            }
            Console.WriteLine("ccccccccccccccccccccccccccc");
            resposta = Console.ReadLine();

        }
        public void VarificaResposta(string comando, Personagem Jogador1)
        {
            bool entrou = false;
            switch (comando)
            {
                case "beber pocao":
                    Console.WriteLine("Qual poção você gostaria de beber?");
                    string nomePoçao = Console.ReadLine();
                    Itens poçao = new Itens();
                    poçao.nome = nomePoçao;
                    if (Jogador1.VeificarSeItemExisteNaBag(Jogador1, poçao));
                    Jogador1.BeberPocao(Jogador1, poçao);
                    entrou = true;
                    break;
                case "olhar bag":
                    Jogador1.OlharBag(Jogador1);
                    entrou = true;
                    break;
                case "remover item":
                    Console.WriteLine("Qual item você gostaria de remover da sua bag?");
                    string nomeItem = Console.ReadLine();
                    Itens novoItem = new Itens();
                    novoItem.nome = nomeItem;
                    Personagem jogador1 = new Personagem();
                    jogador1.RemoverItemNaBag(jogador1, novoItem);
                    entrou = true;
                    break;
            }
            if (entrou == true)
            {
                Console.WriteLine("Escolha uma Resposta");
                resposta = Console.ReadLine();
                
            }
        }  
    }
}
