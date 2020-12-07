using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPGConsole
{
    public class SistemaDeBatalha
    {
        private static bool fimDaBatalha;
        public void Atacar(Personagem jogador1, Inimigos inimigo)
        {
            Random rdn = new Random();
            int dano;
            if (jogador1.classe == "Mago")
                dano = rdn.Next(0, jogador1.inteligencia) + jogador1.itensEquipadoArma.dano;
            else
                dano = rdn.Next(0, jogador1.força) + jogador1.itensEquipadoArma.dano;
            inimigo.vida = (inimigo.vida - dano < 0 ? 0 : inimigo.vida - dano);
            AtualizaBatalhaConsole(jogador1, inimigo, dano, "jogador");
        }
        public void Atacarinimigo(Personagem jogador1, Inimigos inimigo)
        {
            Random rdn = new Random();
            int dano = rdn.Next(0, inimigo.força);
            dano = (dano - jogador1.itensEquipadoAmadura.armadura < 0 ? 0 : dano - jogador1.itensEquipadoAmadura.armadura);
            jogador1.vidaAtual = (jogador1.vidaAtual - dano < 0 ? 0 : jogador1.vidaAtual - dano);
            AtualizaBatalhaConsole(jogador1, inimigo, dano, "inimigo");
        }

        public void AutoAtacarinimigo(Personagem jogador1, Inimigos inimigo)
        {
            Random rdn = new Random();
            int dano = rdn.Next(0, inimigo.força);
            dano = (dano - jogador1.itensEquipadoAmadura.armadura < 0 ? 0 : dano - jogador1.itensEquipadoAmadura.armadura);
            jogador1.vidaAtual = (jogador1.vidaAtual - dano < 0 ? 0 : jogador1.vidaAtual - dano);
            AtualizaBatalhaConsole(jogador1, inimigo, dano, "inimigo", true);
        }
        public void AutoAtacar(Personagem jogador1, Inimigos inimigo)
        {
            Random rdn = new Random();
            int dano;
            if (jogador1.classe == "Mago")
                dano = rdn.Next(0, jogador1.inteligencia) + jogador1.itensEquipadoArma.dano;
            else
                dano = rdn.Next(0, jogador1.força) + jogador1.itensEquipadoArma.dano;

            inimigo.vida = (inimigo.vida - dano < 0 ? 0 : inimigo.vida - dano);

            AtualizaBatalhaConsole(jogador1, inimigo, dano, "jogador", true);

        }
        public void Batalhar(Personagem jogador1, Inimigos inimigo, string resposta)
        {
            if (!Configuracoes.ComandosValidosCombate().Any(l => l == resposta))
                return;
            MontaStatusVIdaInicial(jogador1, inimigo);
            fimDaBatalha = false;
            while (!fimDaBatalha)
            {
                while (resposta == "3")
                {
                    while (inimigo.vida >= 1)
                    {
                        AutoAtacar(jogador1, inimigo);
                        AutoAtacarinimigo(jogador1, inimigo);
                        if (jogador1.vidaAtual <= 0)
                        {
                            MorteDoJogador(jogador1);
                        }
                    }
                    fimDaBatalha = true;
                    resposta = "matou";
                    jogador1.xp = jogador1.xp + inimigo.xpGanho;  
                }
                while (resposta == "1")
                {
                    while (inimigo.vida >= 1)
                    {
                        Atacar(jogador1, inimigo);
                        Atacarinimigo(jogador1, inimigo);
                        if (jogador1.vidaAtual <= 0)
                        {
                            MorteDoJogador(jogador1);
                        }
                    }
                    fimDaBatalha = true;
                    resposta = "matou";
                    jogador1.xp += inimigo.xpGanho;
                }
                while (resposta == "2")
                {
                    Random rdn = new Random();
                    int correr = rdn.Next(1, 23);
                    if (correr == 1)
                    {
                        Console.WriteLine("Voce correu do inimigo");
                        resposta = "correu";
                        fimDaBatalha = true;
                    }

                    else
                    {
                        Console.WriteLine("Voce falhou em correr do inimigo");
                        Atacarinimigo(jogador1, inimigo);
                        InicioBatalha(jogador1, inimigo);
                        fimDaBatalha = false;
                    }
                }
            }
            if (resposta == "matou")
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Você Derrotou o [{inimigo.nome}] Parabéns =)");
                Console.WriteLine("XP ganho: " + inimigo.xpGanho);
                Console.WriteLine("XP Total: " + jogador1.xp);
                Console.WriteLine("Pressione qualquer tecla para continuar ");

                CalcularNivel(jogador1);
            }
            if (resposta == "correu")
            {
                Console.WriteLine("Boa");
            }
            Console.ReadKey();
        }
        public void CalcularNivel(Personagem jogador1)
        {
            if (jogador1.xp >= jogador1.xpProxNivel)
            {
                jogador1.nivel = jogador1.nivel + 1;
                jogador1.xpProxNivel = jogador1.xpProxNivel * 2;
                jogador1.vidaTotal = jogador1.vidaTotal + jogador1.vidaTotal;
                jogador1.vidaAtual = jogador1.vidaTotal;
                jogador1.força = jogador1.força + jogador1.força;
                jogador1.inteligencia = jogador1.inteligencia + jogador1.inteligencia;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    Parabéns                             ");
                Console.WriteLine("                [       LEVEL UP         ");
                Console.WriteLine("          @xxxxx[{:::::::::::::::::::::> ");
                Console.WriteLine("                [                        ");
                Console.WriteLine("                                         ");
                Console.WriteLine($"Você subio para o Nivel: [{jogador1.nivel}]");
                Console.WriteLine("Atributos:");
                Console.WriteLine($"Força: [{jogador1.força}]");
                Console.WriteLine($"Inteligencia: [{jogador1.inteligencia}]");
                Console.WriteLine($"Vida: [{jogador1.vidaAtual}]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Pressione qualquer tecla para continuar ");
            }
        }

        public void AtualizaBatalhaConsole(Personagem jogador1, Inimigos inimigo, int dano, string turno, bool autoAtaque = false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"               [{jogador1.nome}] Nivel: [{jogador1.nivel}]  -  EXP: [{jogador1.xp}]                        ");
            Console.WriteLine();
            Console.WriteLine($"║    Vida do {inimigo.nome}: [{inimigo.vida}]  [{atualizaBarraVida(inimigo.vidaTotal, inimigo.vida)}]  ║  Sua Vida: [{jogador1.vidaAtual}]  [{atualizaBarraVida(jogador1.vidaTotal, jogador1.vidaAtual)}] ");
            Console.WriteLine();
            if (turno == "jogador")
            {
                Console.ForegroundColor = ConsoleColor.Green;                
                Console.WriteLine($"║ Seu Turno:           ");
                Console.WriteLine($"║    Seu dano foi: [{dano}]      ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"║ Turno do seu Inimigo:           ");
                Console.WriteLine($"║    Dano do seu Inimigo: [{dano}]      ");
            }

            if (!autoAtaque)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar ");
                Console.ReadKey();
            }                
            else
                Thread.Sleep(300);
        }

        public string atualizaBarraVida(int vidaTotal, int vida)
        {
            string quadrado = "█";
            string espaco = "░";
            string campoVida = "";
            int totalQuadrados = 20;
            int quadradosFaltantes = totalQuadrados - Convert.ToInt32((vidaTotal - vida) / (vidaTotal / (decimal)totalQuadrados));

            for (int i = 0; i < totalQuadrados; i++)
            {
                if (i < quadradosFaltantes)
                    campoVida += quadrado;
                else
                    campoVida += espaco;
            }

            return campoVida;
        }

        public void InicioBatalha(Personagem jogador1, Inimigos inimigo)
        {
            Console.Clear();
            MontaStatusBatalha(jogador1, inimigo);
            string resposta = Console.ReadLine();
            if (!Configuracoes.ComandosValidosCombate().Any(l => l == resposta))
            {
                InicioBatalha(jogador1, inimigo);
            }
            Batalhar(jogador1, inimigo, resposta);
        }

        public void MontaStatusVIdaInicial(Personagem jogador1, Inimigos inimigo)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"               [{jogador1.nome}] Nivel: [{jogador1.nivel}]  -  EXP: [{jogador1.xp}]                        ");
            Console.WriteLine();
            Console.WriteLine($"║    Vida do {inimigo.nome}: [{inimigo.vida}]  [{atualizaBarraVida(inimigo.vidaTotal, inimigo.vida)}]  ║  Sua Vida: [{jogador1.vidaAtual}]  [{atualizaBarraVida(jogador1.vidaTotal, jogador1.vidaAtual)}] ");
            Console.WriteLine();
            Thread.Sleep(800);
        }

        public void MontaStatusBatalha(Personagem jogador1, Inimigos inimigo)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"               [{jogador1.nome}] Nivel: [{jogador1.nivel}]  -  EXP: [{jogador1.xp}]   ║  Sua Vida: [{jogador1.vidaAtual}]  [{atualizaBarraVida(jogador1.vidaTotal, jogador1.vidaAtual)}] ");
            Console.WriteLine();
            Console.WriteLine($"               Você encontrou um [{inimigo.nome}]                       ");
            Console.WriteLine();
            Console.WriteLine($"╔════════════════════════════════╗           ║Sua Vida: [{jogador1.vidaAtual}]      ");
            Console.WriteLine($"║  #=# Escolha sua Ação: #=#     ║           ║Sua Defesa: [{jogador1.itensEquipadoAmadura.armadura}]   ");
            Console.WriteLine($"║════════════════════════════════║           ║Sua Dano: [{jogador1.força}]      ");
            Console.WriteLine($"║  [1]-Lutar contra o monstro.   ║           ║Sua Dinheiro: [{jogador1.gold}g {jogador1.silver}s]        ");
            Console.WriteLine($"║  [2]-Correr para longe.        ║           ║Monstro Nome : [{inimigo.nome}]        ");
            Console.WriteLine($"║  [3]-Auto-Ataque.              ║           ║Monstro Vida: [{inimigo.vida}]      ");
            Console.WriteLine($"╚════════════════════════════════╝           ║Monstro Ataque: [{inimigo.força}]     ");
        }

        public static void MorteDoJogador(Personagem jogador1)
        {
            Console.Clear();
            TimeSpan horaTotal = new TimeSpan(DateTime.Now.Ticks - jogador1.dataCriacao.Ticks);
            string total = horaTotal.ToString(@"hh\:mm\:ss");

            Console.WriteLine($"             {jogador1.nome} VOCÊ MORREU                      ");
            Console.WriteLine($"╔════════════════════════════════╗           ║      SEUS STATUS DA PARTIDA      ");
            Console.WriteLine($"║  #=# Escolha sua Ação: #=#     ║           ║Sua Level: [{jogador1.nivel}]   ");
            Console.WriteLine($"║════════════════════════════════║           ║Sua Dano: [{jogador1.força}]      ");
            Console.WriteLine($"║  [1]-Voltar ao menu.           ║           ║Sua Dinheiro: [{jogador1.gold}g {jogador1.silver}s]        ");
            Console.WriteLine($"║  [2]-Fechar o jogo.            ║           ║Tempo Jogado : [{total}]        ");
            Console.WriteLine($"╚════════════════════════════════╝            ");
            string resposta = Console.ReadLine();
            if (resposta == "2")
            {
                Environment.Exit(0);
            }
            else
            {
                Lore Inicio = new Lore();
                Inicio.inicio();
            }
                

        }
    }
}
