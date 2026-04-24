using System;
using System.Collections.Generic;

namespace RPGConsole
{
    class Lore
    {
        public bool carregarPersonagemSalvo;
        public string saveSelecionado;
        public string selecao;
        public bool selecaoValida;
        static string resposta { get; set; }

        public void inicio()
        {
            try
            {
                selecao = "0";

                while (selecao == "0")
                {
                    carregarPersonagemSalvo = false;
                    saveSelecionado = null;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine(LoreReader.Obter("INICIO_MENU"));
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Digite 1 para iniciar o jogo");
                    Console.WriteLine("Digite 2 para ir para o sobre");
                    Console.WriteLine("Digite 3 para testar o sistema de batalha");
                    Console.WriteLine("Digite 4 para testar o sistema de comprade item");
                    Console.WriteLine("Digite 5 para ver os comandos basicos");
                    Console.WriteLine("Digite 6 para carregar personagem salvo");
                    selecao = Console.ReadLine();
                    selecaoValida = false;

                    if (selecao == "1")
                        selecaoValida = true;

                    if (selecao == "2")
                    {
                        Configuracoes.MontaPainelDialogos(LoreReader.Obter("SOBRE"), "Marcio Zamperetti");
                        Console.ReadKey();
                        selecao = "0";
                        selecaoValida = true;
                    }

                    if (selecao == "3")
                    {
                        selecaoValida = true;
                        Personagem jogador1 = new Personagem();
                        jogador1.CriarPersonagem(jogador1);
                        while (selecao == "3")
                        {
                            Inimigos inimigo = Inimigos.CriaçãoInimigos(Inimigos.TipoEnimigo.Rato);
                            SistemaDeBatalha sistemaDeBatalha = new SistemaDeBatalha();
                            sistemaDeBatalha.InicioBatalha(jogador1, inimigo);
                        }
                    }

                    if (selecao == "4")
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

                    if (selecao == "5")
                    {
                        selecaoValida = true;
                        Console.WriteLine("Lista de comandos basicos:");
                        Console.WriteLine("olhar bag");
                        Console.WriteLine("remover item");
                        Console.WriteLine("beber pocao");
                        Console.WriteLine("Digite algum comando para testar sua acao:");
                        selecao = Console.ReadLine();
                    }

                    if (selecao == "6")
                    {
                        List<SaveInfo> saves = PersonagemStorage.ListarSaves();
                        if (saves.Count > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Escolha um save para carregar:");
                            for (int i = 0; i < saves.Count; i++)
                            {
                                Console.WriteLine($"[{i + 1}] {saves[i].NomePersonagem} ({saves[i].NomeArquivo})");
                            }
                            Console.WriteLine("Digite o numero do save:");
                            string respostaSave = Console.ReadLine();
                            int indiceSelecionado;
                            bool entradaValida = int.TryParse(respostaSave, out indiceSelecionado);
                            if (entradaValida && indiceSelecionado >= 1 && indiceSelecionado <= saves.Count)
                            {
                                saveSelecionado = saves[indiceSelecionado - 1].NomeArquivo;
                                carregarPersonagemSalvo = true;
                                selecaoValida = true;
                                continue;
                            }

                            Console.WriteLine("Opcao invalida.");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                            Console.ReadKey();
                            selecao = "0";
                            selecaoValida = true;
                            continue;
                        }

                        Console.WriteLine("Nenhum personagem salvo foi encontrado.");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                        Console.ReadKey();
                        selecao = "0";
                        selecaoValida = true;
                    }

                    if (selecao == "olhar bag")
                    {
                        selecaoValida = true;
                        Personagem jogador1 = new Personagem();
                        Itens novoItem = new Itens();
                        novoItem.nome = "Espada Longa";
                        jogador1.AdicionarItemNaBag(jogador1, novoItem);
                        jogador1.OlharBag(jogador1);
                        Console.ReadLine();
                    }

                    if (selecao == "remover item")
                    {
                        selecaoValida = true;
                        Console.WriteLine("Qual item voce gostaria de remover da sua bag?");
                        string nomeItem = Console.ReadLine();
                        Itens novoItem = new Itens();
                        novoItem.nome = nomeItem;
                        Personagem jogador1 = new Personagem();
                        jogador1.RemoverItemNaBag(jogador1, novoItem);
                    }

                    if (selecao == "beber pocao")
                    {
                        selecaoValida = true;
                        string nomePocao = "pocao pequena";
                        Personagem jogador1 = new Personagem();
                        Itens novoItem = new Itens();
                        novoItem.nome = nomePocao;
                        jogador1.AdicionarItemNaBag(jogador1, novoItem);
                        Console.WriteLine("primeiro digite 'olhar bag' para ver os seus itens na bag");
                        Console.ReadLine();
                        jogador1.OlharBag(jogador1);
                        Console.WriteLine("Qual pocao voce gostaria de beber?");
                        nomePocao = Console.ReadLine();
                        jogador1.BeberPocao(jogador1, novoItem);
                    }

                    if (selecaoValida == false)
                        inicio();
                }
            }
            catch
            {
                Console.WriteLine("Selecione uma opcao valida");
                inicio();
            }
        }

        public void parte1(Personagem jogador1)
        {
            jogador1.localAtual = "TAVERNA";
            Console.Clear();
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_NARRADOR_1"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_NARRADOR_2"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_NARRADOR_3"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_MULHER_1"), "Mulher");
            Console.Clear();

            List<string> opcoesRespostas = new List<string>();
            opcoesRespostas.Add("[1] - Gostaria sim, mas nao tenho toda essa quantia de dinheiro.");
            opcoesRespostas.Add("[2] - Nao tenho interesse nenhum nisso.");
            opcoesRespostas.Add("[3] - Ei este pergaminho me pertence (roubar pergaminho)");
            Configuracoes.MontaPainelDialogosComOpeçoesRespostas(opcoesRespostas, jogador1.nome, out string valorSelecionado);
            resposta = valorSelecionado;
            VarificaResposta(resposta, jogador1);

            if (resposta == "1")
            {
                Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_RESP1_MULHER"), "Mulher");
                Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_RESP1_JOGADOR"), jogador1.nome);
            }

            if (resposta == "2")
            {
                Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_RESP2_MULHER_1"), "Mulher");
                Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_RESP2_JOGADOR_1"), jogador1.nome);
                Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_RESP2_MULHER_2"), "Mulher");
                Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_RESP2_JOGADOR_2"), jogador1.nome);
            }

            if (resposta == "3")
            {
                Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_RESP3_MULHER"), "Mulher");
                Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE1_RESP3_NARRADOR"), "Narrador");
                Inimigos inimigo = Inimigos.CriaçãoInimigos(Inimigos.TipoEnimigo.Mulher);
                SistemaDeBatalha sistemaDeBatalha = new SistemaDeBatalha();
                sistemaDeBatalha.InicioBatalha(jogador1, inimigo);
            }

            jogador1.parteAtual = 2;
            jogador1.localAtual = "FLORESTA";
            PersonagemStorage.Salvar(jogador1);
        }

        public void parte2(Personagem jogador1)
        {
            jogador1.localAtual = "FLORESTA";
            Console.Clear();
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE2_NARRADOR_1"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE2_NARRADOR_2"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE2_NARRADOR_3"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE2_NARRADOR_4"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE2_NARRADOR_5"), "Narrador");

            Inimigos inimigo = Inimigos.CriaçãoInimigos(Inimigos.TipoEnimigo.Rato);
            SistemaDeBatalha sistemaDeBatalha = new SistemaDeBatalha();
            sistemaDeBatalha.InicioBatalha(jogador1, inimigo);

            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE2_NARRADOR_6"), "Narrador");
            jogador1.parteAtual = 3;
            jogador1.localAtual = "RUINAS";
            PersonagemStorage.Salvar(jogador1);
        }

        public void parte3(Personagem jogador1)
        {
            jogador1.localAtual = "RUINAS";
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE3_NARRADOR_1"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE3_NARRADOR_2"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE3_NARRADOR_3"), "Narrador");

            Inimigos esqueleto = Inimigos.CriaçãoInimigos(Inimigos.TipoEnimigo.Esqueleto);
            SistemaDeBatalha sistemaDeBatalha = new SistemaDeBatalha();
            sistemaDeBatalha.InicioBatalha(jogador1, esqueleto);

            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE3_NARRADOR_4"), "Narrador");
            jogador1.parteAtual = 4;
            jogador1.localAtual = "CATACUMBAS";
            PersonagemStorage.Salvar(jogador1);
        }

        public void parte4(Personagem jogador1)
        {
            jogador1.localAtual = "CATACUMBAS";
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE4_NARRADOR_1"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE4_NARRADOR_2"), "Narrador");

            SistemaDeBatalha sistemaDeBatalha = new SistemaDeBatalha();
            Inimigos rato1 = Inimigos.CriaçãoInimigos(Inimigos.TipoEnimigo.Rato);
            sistemaDeBatalha.InicioBatalha(jogador1, rato1);
            Inimigos rato2 = Inimigos.CriaçãoInimigos(Inimigos.TipoEnimigo.Rato);
            sistemaDeBatalha.InicioBatalha(jogador1, rato2);

            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE4_NARRADOR_3"), "Narrador");
            jogador1.parteAtual = 5;
            jogador1.localAtual = "TORRE";
            PersonagemStorage.Salvar(jogador1);
        }

        public void parte5(Personagem jogador1)
        {
            jogador1.localAtual = "TORRE";
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE5_NARRADOR_1"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE5_NARRADOR_2"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE5_NARRADOR_3"), "Narrador");

            SistemaDeBatalha sistemaDeBatalha = new SistemaDeBatalha();
            Inimigos esqueleto = Inimigos.CriaçãoInimigos(Inimigos.TipoEnimigo.Esqueleto);
            sistemaDeBatalha.InicioBatalha(jogador1, esqueleto);

            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE5_NARRADOR_4"), "Narrador");
            jogador1.parteAtual = 6;
            jogador1.localAtual = "PORTO";
            PersonagemStorage.Salvar(jogador1);
        }

        public void parte6(Personagem jogador1)
        {
            jogador1.localAtual = "PORTO";
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE6_NARRADOR_1"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE6_NARRADOR_2"), "Narrador");

            SistemaDeBatalha sistemaDeBatalha = new SistemaDeBatalha();
            Inimigos rato = Inimigos.CriaçãoInimigos(Inimigos.TipoEnimigo.Rato);
            sistemaDeBatalha.InicioBatalha(jogador1, rato);
            Inimigos esqueleto = Inimigos.CriaçãoInimigos(Inimigos.TipoEnimigo.Esqueleto);
            sistemaDeBatalha.InicioBatalha(jogador1, esqueleto);

            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE6_NARRADOR_3"), "Narrador");
            jogador1.parteAtual = 7;
            jogador1.localAtual = "CIDADELA";
            PersonagemStorage.Salvar(jogador1);
        }

        public void parte7(Personagem jogador1)
        {
            jogador1.localAtual = "CIDADELA";
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE7_NARRADOR_1"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE7_NARRADOR_2"), "Narrador");
            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE7_NARRADOR_3"), "Narrador");

            SistemaDeBatalha sistemaDeBatalha = new SistemaDeBatalha();
            Inimigos esqueletoFinal = Inimigos.CriaçãoInimigos(Inimigos.TipoEnimigo.Esqueleto);
            sistemaDeBatalha.InicioBatalha(jogador1, esqueletoFinal);

            Configuracoes.MontaPainelDialogos(LoreReader.Obter("PARTE7_NARRADOR_4"), "Narrador");
            jogador1.parteAtual = 8;
            PersonagemStorage.Salvar(jogador1);
        }

        public void ExecutarHistoria(Personagem jogador1)
        {
            if (jogador1.parteAtual <= 1) parte1(jogador1);
            if (jogador1.parteAtual <= 2) parte2(jogador1);
            if (jogador1.parteAtual <= 3) parte3(jogador1);
            if (jogador1.parteAtual <= 4) parte4(jogador1);
            if (jogador1.parteAtual <= 5) parte5(jogador1);
            if (jogador1.parteAtual <= 6) parte6(jogador1);
            if (jogador1.parteAtual <= 7) parte7(jogador1);
        }

        public void VarificaResposta(string comando, Personagem jogador1)
        {
            bool entrou = false;
            switch (comando)
            {
                case "beber pocao":
                    Console.WriteLine("Qual pocao voce gostaria de beber?");
                    string nomePocao = Console.ReadLine();
                    Itens pocao = new Itens();
                    pocao.nome = nomePocao;
                    if (jogador1.VeificarSeItemExisteNaBag(jogador1, pocao))
                        jogador1.BeberPocao(jogador1, pocao);
                    entrou = true;
                    break;
                case "olhar bag":
                    jogador1.OlharBag(jogador1);
                    entrou = true;
                    break;
                case "remover item":
                    Console.WriteLine("Qual item voce gostaria de remover da sua bag?");
                    string nomeItem = Console.ReadLine();
                    Itens novoItem = new Itens();
                    novoItem.nome = nomeItem;
                    Personagem jogadorNovo = new Personagem();
                    jogadorNovo.RemoverItemNaBag(jogadorNovo, novoItem);
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
