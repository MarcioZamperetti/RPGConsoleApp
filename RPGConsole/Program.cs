using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace RPGConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            Configuracoes.ConfiguraJanela();
            LoreReader.Inicializar("lore.txt");
            Lore lore1 = new Lore();
            Personagem jogador1 = new Personagem();

            ////////////////////INICIO DO JOGO//////////////////////////
            lore1.inicio();
            ///////////////////CRIAR PERSONAGEM/////////////////////////
            if (lore1.carregarPersonagemSalvo)
            {
                jogador1 = PersonagemStorage.Carregar(lore1.saveSelecionado);
                jogador1.MostraDadosdoJogador(jogador1);
            }
            else
            {
                jogador1.CriarPersonagem(jogador1);
            }
            SessaoJogo.JogadorAtual = jogador1;
            ////////////////////HISTORIA DO GAME/////////////////////////
            lore1.ExecutarHistoria(jogador1);

            Console.WriteLine("Voltou pro game");
            Console.ReadKey();
        }
    }
}
