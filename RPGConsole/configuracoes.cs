using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsole
{
    class Configuracoes
    {
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public static void ConfiguraJanela()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }

            Console.SetWindowSize(150, 40);
        }

        public static List<string> ComandosValidosCombate()
        {
            List<string> listaComandosValidosCombate = new List<string>()
            {
                "1",
                "2",
                "3"
            };
            return listaComandosValidosCombate;
        }

        public static List<string> ComandosValidosSelecaoPersonagem()
        {
            List<string> listaComandosValidosCombate = new List<string>()
            {
                "1",
                "2",
                "3"
            };
            return listaComandosValidosCombate;
        }

        public static void MontaPainelDialogos(string dialogo, string nome)
        {
            string[] paravras = dialogo.Split(' ');

            Console.Clear();
            Console.WriteLine($"╔═══════════════════════════════════════════════════════════════════╗");
            MontaNome(nome);
            Console.WriteLine($"║═══════════════════════════════════════════════════════════════════║");
            MostraLinha(paravras);
            Console.WriteLine($"╚═══════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("Precione qualquer tecla para continuar");
            Console.ReadKey();
        }

        public static void MontaPainelDialogosComOpeçoesRespostas(List<string> opcoesRespostas, string nome, out string valorSelecionado)
        {
            string resposta;
            valorSelecionado = string.Empty;
            Console.Clear();
            Console.WriteLine($"╔═══════════════════════════════════════════════════════════════════╗");
            MontaNome("Escolha sua Ação:" + nome);
            Console.WriteLine($"║═══════════════════════════════════════════════════════════════════║");
            foreach (var opcao in opcoesRespostas)
            {
                string[] paravras = opcao.Split(' ');
                MostraLinha(paravras);
            }
            Console.WriteLine($"╚═══════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("Selecione uma das opções acima");
            resposta = Console.ReadLine();
            if (!VerificaOpcaoResposta(resposta, opcoesRespostas.Count))
            {
                MontaPainelDialogosComOpeçoesRespostas(opcoesRespostas, nome, out resposta);
            }
            else
                valorSelecionado = resposta;

            Console.Clear();
        }

        public static bool VerificaOpcaoResposta(string resposta, int totalRespostas)
        {
            try
            {
                if (Convert.ToInt32(resposta) <= totalRespostas)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static void MostraLinha(string[] paravras)
        {
            int contadorPalavras = 0;
            while (paravras.Length > contadorPalavras)
            {
                string espaco = " ";
                string traco = "║";
                string linha = "";

                for (int i = 0; i < 66; i++)
                {
                    if (i == 0)
                        linha += traco;
                    if (i == 1 || i == 2)
                        linha += espaco;

                    if (i >= 3)
                    {
                        if (contadorPalavras < paravras.Length)
                        {
                            linha += $"{paravras[contadorPalavras]} ";
                            i += paravras[contadorPalavras].Length + 1;
                            contadorPalavras++;
                        }
                    }
                }
                for (int h = linha.Length; h <= 67; h++)
                {
                    linha += espaco;
                    if (h == 67)
                        linha += traco;
                }
                Console.WriteLine(linha);
            }
        }

        public static void MontaNome(string nome)
        {
            string espaco = " ";
            string traco = "║";
            string linha = "";

            for (int i = 0; i <= 69; i++)
            {
                if (i == 0)
                    linha += traco;
                if (i == 1 || i == 2)
                    linha += espaco;
                if (i == 3)
                {
                    linha += $"{nome}:";
                    i += nome.Length + 3;
                }
                if (i > 4)
                    linha += espaco;
                if (i == 69)
                    linha += traco;
            }
            Console.WriteLine(linha);
        }

    }
}
