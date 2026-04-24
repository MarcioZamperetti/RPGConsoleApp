using System;
using System.Collections.Generic;

namespace RPGConsole
{
    internal static class InventarioConsole
    {
        private const int InnerWidth = 85;

        public static void Abrir(Personagem jogador)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;

                string nomeJogador = (jogador == null || string.IsNullOrWhiteSpace(jogador.nome)) ? "Aventureiro" : jogador.nome;
                List<Itens> bag = jogador?.bag ?? new List<Itens>();
                Itens arma = jogador?.itensEquipadoArma;
                Itens armadura = jogador?.itensEquipadoAmadura;

                WriteTop(" INVENTARIO ");
                WriteRow($" PERSONAGEM: {nomeJogador}");
                WriteMid();
                WriteRow(" EQUIPADOS");
                WriteRow(" -----------------------------------------------------------------------------");
                WriteRow($" ARMA:     {TextoItemEquipado(arma, true)}");
                WriteRow($" ARMADURA: {TextoItemEquipado(armadura, false)}");
                WriteMid();
                WriteRow(" BAG");
                WriteRow(" -----------------------------------------------------------------------------");

                if (bag.Count == 0)
                {
                    WriteRow(" (vazia)");
                }
                else
                {
                    int limiteLinhas = Math.Min(12, bag.Count);
                    for (int i = 0; i < limiteLinhas; i++)
                    {
                        WriteRow($"{i + 1}. {TextoItemBag(bag[i])}");
                    }

                    if (bag.Count > limiteLinhas)
                    {
                        WriteRow($"+ {bag.Count - limiteLinhas} itens...");
                    }
                }

                WriteMid();
                WriteRow(" ACOES: [E] Equipar item da bag  |  [ESC] Voltar");
                WriteBottom();

                ConsoleKeyInfo tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.Escape)
                {
                    break;
                }

                if (tecla.Key == ConsoleKey.E)
                {
                    TentarEquiparItem(jogador);
                }
            }
        }

        private static string TextoItemEquipado(Itens item, bool arma)
        {
            if (item == null)
                return "(nenhum)";

            if (arma)
                return $"{item.nome} | dano: {item.dano}";

            return $"{item.nome} | armadura: {item.armadura}";
        }

        private static string TextoItemBag(Itens item)
        {
            if (item == null)
                return "(item invalido)";

            string tipo = "Util";
            int valorAtributo = item.valor;

            if (item.dano > 0)
            {
                tipo = "Arma";
                valorAtributo = item.dano;
            }
            else if (item.armadura > 0)
            {
                tipo = "Armadura";
                valorAtributo = item.armadura;
            }

            return $"{item.nome} [{tipo}] val:{valorAtributo}";
        }

        private static void WriteTop(string titulo)
        {
            string t = string.IsNullOrWhiteSpace(titulo) ? "" : titulo.Trim();
            if (t.Length + 2 >= InnerWidth)
                t = t.Substring(0, InnerWidth - 4);

            int left = (InnerWidth - t.Length) / 2;
            int right = InnerWidth - t.Length - left;
            Console.WriteLine("╔" + new string('═', left) + t + new string('═', right) + "╗");
        }

        private static void WriteMid()
        {
            Console.WriteLine("╠" + new string('═', InnerWidth) + "╣");
        }

        private static void WriteBottom()
        {
            Console.WriteLine("╚" + new string('═', InnerWidth) + "╝");
        }

        private static void WriteRow(string content)
        {
            string text = content ?? "";
            if (text.Length > InnerWidth)
                text = text.Substring(0, InnerWidth);
            Console.WriteLine("║" + text.PadRight(InnerWidth) + "║");
        }

        private static void TentarEquiparItem(Personagem jogador)
        {
            if (jogador == null)
            {
                MostrarMensagem("Nenhum personagem ativo.");
                return;
            }

            if (jogador.bag == null || jogador.bag.Count == 0)
            {
                MostrarMensagem("A bag esta vazia.");
                return;
            }

            Console.WriteLine();
            Console.Write("Digite o numero do item que deseja equipar: ");
            string entrada = Console.ReadLine();
            int indiceSelecionado;
            if (!int.TryParse(entrada, out indiceSelecionado))
            {
                MostrarMensagem("Entrada invalida.");
                return;
            }

            string mensagem;
            bool equipado = jogador.EquiparItemDaBag(jogador, indiceSelecionado - 1, out mensagem);
            if (equipado)
            {
                PersonagemStorage.Salvar(jogador);
            }

            MostrarMensagem(mensagem);
        }

        private static void MostrarMensagem(string mensagem)
        {
            Console.WriteLine();
            Console.WriteLine(string.IsNullOrWhiteSpace(mensagem) ? "Operacao concluida." : mensagem);
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey(true);
        }
    }
}
