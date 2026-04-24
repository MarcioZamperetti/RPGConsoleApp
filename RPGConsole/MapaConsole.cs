using System;

namespace RPGConsole
{
    internal static class MapaConsole
    {
        private const int InnerWidth = 85;

        public static void Abrir(Personagem jogador)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            string localAtual = ObterLocalAtual(jogador);
            int parteAtual = ObterParteAtual(jogador);
            string tav = Node("TAVERNA", localAtual);
            string flo = Node("FLORESTA", localAtual);
            string rui = Node("RUINAS", localAtual);
            string cat = Node("CATACUMBAS", localAtual);
            string tor = Node("TORRE", localAtual);
            string vil = Node("VILA", localAtual);
            string cla = Node("CLAREIRA", localAtual);
            string cri = Node("CRIPTA", localAtual);
            string lab = Node("LABORATORIO", localAtual);
            string por = Node("PORTO", localAtual);
            string cid = Node("CIDADELA", localAtual);

            WriteTop(" MAPA DE MYSTARA ");
            WriteRow("");
            WriteRow($"  {tav}----{flo}----{rui}----{cat}----{tor}");
            WriteRow("      |             |                         |               |");
            WriteRow($"   {vil}        {cla}               {cri}        {lab}");
            WriteRow("      |");
            WriteRow($"   {por}----------------------------------------------{cid}");
            WriteRow("");
            WriteMid();
            WriteRow($" LOCAL ATUAL: {localAtual.PadRight(15)} PARTE: {parteAtual}");
            WriteRow(" MARCADOR: {X}  (X vermelho)");
            WriteRow(" DICA: Pressione M durante os dialogos para abrir este mapa.");
            WriteBottom();

            MostrarLegendaLocal(localAtual);

            Console.WriteLine("Pressione qualquer tecla para voltar ao dialogo.");
            Console.ReadKey(true);
        }

        private static void MostrarLegendaLocal(string localAtual)
        {
            Console.WriteLine();
            Console.Write("Voce esta em: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("X");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" {localAtual}");
        }

        private static string ObterLocalAtual(Personagem jogador)
        {
            if (jogador != null && !string.IsNullOrWhiteSpace(jogador.localAtual))
            {
                return jogador.localAtual.ToUpperInvariant();
            }

            int parte = ObterParteAtual(jogador);
            if (parte <= 1)
                return "TAVERNA";
            if (parte == 2)
                return "FLORESTA";
            if (parte == 3)
                return "RUINAS";
            if (parte == 4)
                return "CATACUMBAS";
            if (parte == 5)
                return "TORRE";
            if (parte == 6)
                return "PORTO";
            return "CIDADELA";
        }

        private static string Node(string nome, string localAtual)
        {
            if (string.Equals(nome, localAtual, StringComparison.OrdinalIgnoreCase))
            {
                return $"[{nome}{{X}}]";
            }

            return $"[{nome}]";
        }

        private static int ObterParteAtual(Personagem jogador)
        {
            if (jogador == null || jogador.parteAtual <= 0)
                return 1;
            return jogador.parteAtual;
        }

        private static void WriteTop(string titulo)
        {
            string t = string.IsNullOrWhiteSpace(titulo) ? "" : titulo.Trim();
            if (t.Length + 2 >= InnerWidth)
                t = t.Substring(0, InnerWidth - 4);

            int left = (InnerWidth - t.Length) / 2;
            int right = InnerWidth - t.Length - left;
            Console.WriteLine("+" + new string('-', left) + t + new string('-', right) + "+");
        }

        private static void WriteMid()
        {
            Console.WriteLine("+" + new string('-', InnerWidth) + "+");
        }

        private static void WriteBottom()
        {
            Console.WriteLine("+" + new string('-', InnerWidth) + "+");
        }

        private static void WriteRow(string content)
        {
            string text = content ?? "";
            const string marker = "{X}";
            int markerIndex = text.IndexOf(marker, StringComparison.Ordinal);

            if (markerIndex < 0)
            {
                Console.WriteLine("|" + Fit(text, InnerWidth) + "|");
                return;
            }

            string before = text.Substring(0, markerIndex);
            string after = text.Substring(markerIndex + marker.Length);
            string joined = Fit(before + "X" + after, InnerWidth);
            int xPos = before.Length;

            if (xPos < 0 || xPos >= joined.Length)
            {
                Console.WriteLine("|" + joined + "|");
                return;
            }

            Console.Write("|");
            Console.Write(joined.Substring(0, xPos));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("X");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(joined.Substring(xPos + 1));
            Console.WriteLine("|");
        }

        private static string Fit(string value, int width)
        {
            string v = value ?? "";
            if (v.Length > width)
                return v.Substring(0, width);
            return v.PadRight(width);
        }
    }
}
