using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace RPGConsole
{
    public class Personagem
    {
        public enum Classes
        {
            Arqueiro = 1,
            Mago = 2,
            Guerreiro = 3
        }
        public string nome;
        public int idade;
        public Classes classe;
        public int força;
        public int inteligencia;
        public int vidaAtual;
        public int vidaTotal;
        public string resposta;
        public string nomeinimigo;
        public string fimdebatalha;
        public int xp;
        public int xpProxNivel = 100;
        public int nivel;
        public DateTime dataCriacao;
        public int gold;
        public int silver;
        List<Itens> bag = new List<Itens>();
        public Itens itensEquipadoArma;
        public Itens itensEquipadoAmadura;


        public void CriarPersonagem(Personagem jogador1)
        {
            try
            {
                resposta = "não";
                while (resposta == "não")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Digite seu nome");
                    jogador1.nome = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(jogador1.nome + " Qual sua Idade?");
                    jogador1.idade = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"                                   Escolha sua Classe:                           ");
                    Console.WriteLine();
                    Console.WriteLine($"     ╔═══════════════════════╗   ╔═══════════════════════╗    ╔═══════════════════════╗        ");
                    Console.WriteLine($"     ║   [1]   Arqueiro      ║   ║   [2]     Mago        ║    ║   [3]  Guerreiro      ║        ");
                    Console.WriteLine($"     ║═══════════════════════║   ║═══════════════════════║    ║═══════════════════════║        ");
                    Console.WriteLine($"     ║  Força: [2]           ║   ║  Força: [1]           ║    ║  Força: [4]           ║        ");
                    Console.WriteLine($"     ║  inteligência: [2]    ║   ║  inteligência: [4]    ║    ║  inteligência: [0]    ║        ");
                    Console.WriteLine($"     ║  Vida: [10]           ║   ║  Vida: [5]            ║    ║  Vida: [15]           ║        ");
                    Console.WriteLine($"     ╚═══════════════════════╝   ╚═══════════════════════╝    ╚═══════════════════════╝        ");
                    Console.WriteLine($"                                   Digite o Numero da sua Classe:                              ");

                    string selecao = Console.ReadLine();
                    if (!Configuracoes.ComandosValidosSelecaoPersonagem().Any(l => l == selecao))
                        CriarPersonagem(jogador1);
                    jogador1.classe = (Classes)Convert.ToInt32(selecao);
                    Itens arma = new Itens();
                    Itens armadura = new Itens();
                    switch (jogador1.classe)
                    {
                        case Classes.Arqueiro:
                            jogador1.força = 3;
                            jogador1.inteligencia = 2;
                            jogador1.vidaAtual = 15;
                            jogador1.vidaTotal = 15;
                            jogador1.nivel = 1;
                            jogador1.xp = 0;
                            jogador1.dataCriacao = DateTime.Now;
                            arma.nome = "Arco podre";
                            arma.dano = 1;
                            arma.equipado = true;
                            jogador1.itensEquipadoArma = arma;
                            armadura.nome = "Armadura podre";
                            armadura.armadura = 1;
                            armadura.equipado = true;
                            jogador1.itensEquipadoAmadura = armadura;
                            bag.Add(arma);
                            bag.Add(armadura);
                            break;

                        case Classes.Mago:
                            jogador1.força = 2;
                            jogador1.inteligencia = 4;
                            jogador1.vidaAtual = 10;
                            jogador1.vidaTotal = 10;
                            jogador1.nivel = 1;
                            jogador1.xp = 0;
                            jogador1.dataCriacao = DateTime.Now;
                            arma.nome = "varinha podre";
                            arma.dano = 1;
                            arma.equipado = true;
                            jogador1.itensEquipadoArma = arma;
                            armadura.nome = "Armadura podre";
                            armadura.armadura = 1;
                            armadura.equipado = true;
                            jogador1.itensEquipadoAmadura = armadura;
                            bag.Add(arma);
                            bag.Add(armadura);
                            break;
                        case Classes.Guerreiro:
                            jogador1.força = 5;
                            jogador1.inteligencia = 1;
                            jogador1.vidaAtual = 20;
                            jogador1.vidaTotal = 20;
                            jogador1.nivel = 1;
                            jogador1.xp = 0;
                            jogador1.dataCriacao = DateTime.Now;
                            arma.nome = "Espada podre";
                            arma.dano = 1;
                            arma.equipado = true;
                            jogador1.itensEquipadoArma = arma;
                            armadura.nome = "Armadura podre";
                            armadura.armadura = 1;
                            armadura.equipado = true;
                            jogador1.itensEquipadoAmadura = armadura;
                            bag.Add(arma);
                            bag.Add(armadura);
                            break;
                    }
                    MostraDadosdoJogador(jogador1);
                    resposta = "sim";
                }
            }
            catch
            {
                Console.WriteLine("SELEÇÃO INVÁLIDA");
                CriarPersonagem(jogador1);
            }
        }

        public void MostraDadosdoJogador(Personagem jogador1)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"               [{jogador1.nome}] Nivel: [{jogador1.nivel}]  -  Classe: [{jogador1.classe}]              ");
            Console.WriteLine($"   ║Sua Vida: [{jogador1.vidaAtual}]      ");
            Console.WriteLine($"   ║Sua Defesa: [{jogador1.itensEquipadoAmadura.armadura}]   ");
            Console.WriteLine($"   ║Sua Dano: [{jogador1.força}]      ");
            Console.WriteLine($"   ║Sua Dinheiro: [{jogador1.gold}g {jogador1.silver}s]        ");
            Console.WriteLine($"   ║Arma: [{jogador1.itensEquipadoArma.nome}] Dano: [{jogador1.itensEquipadoArma.dano}]       ");
            Console.WriteLine($"   ║Armadura: [{jogador1.itensEquipadoAmadura.nome}] Armadura: [{jogador1.itensEquipadoAmadura.armadura}]        ");
            Console.WriteLine($"   Pressione qualquer tecla para continuar         ");
            Console.ReadLine();
        }
        public void ComprarItem(Personagem jogador1, int valorDoItem, Itens ItemComprado)
        {
            double totalSilver = (gold * 100) + silver;
            if (valorDoItem > totalSilver)
            {
                Console.WriteLine("Você não possui dinheiro necessario");
            }
            if (valorDoItem <= totalSilver)
            {
                totalSilver = totalSilver - valorDoItem;
                Console.WriteLine("Você comprou um " + ItemComprado.nome + " por: " + valorDoItem + " silvers ");
                if (totalSilver > 100)
                {
                    totalSilver = totalSilver / 100;
                    gold = Convert.ToInt32(Math.Floor(totalSilver));
                    totalSilver = totalSilver - gold;
                    totalSilver = totalSilver * 100;
                    silver = Convert.ToInt32(totalSilver);
                    Console.WriteLine("Seu troco Gold: " + gold + " Silver: " + silver);
                    AdicionarItemNaBag(jogador1, ItemComprado);

                }
                else
                {
                    silver = Convert.ToInt32(totalSilver);
                    Console.WriteLine("Seu troco silver: " + silver);
                }
            }
            Console.WriteLine($"   Pressione qualquer tecla para continuar         ");
            Console.ReadLine();
        }
        public void OlharBag(Personagem jogador1)
        {
            if (bag.Count == 0)
                Console.WriteLine("Não há itens na sua bag");
            else
            {
                Console.WriteLine("Item na sua Bag:");
                bag.ForEach(i => Console.WriteLine(i.nome));
            }
        }
        public void AdicionarItemNaBag(Personagem jogador1, Itens itemAdicionado)
        {
            bag.Add(itemAdicionado);
            Console.WriteLine("O item " + itemAdicionado.nome + "foi adicionado a sua bag");
        }
        public void RemoverItemNaBag(Personagem jogador1, Itens itemRemovido)
        {
            bool ItemExistente = false;
            foreach (var nomeItem in bag)
            {
                if (nomeItem == itemRemovido)
                    ItemExistente = true;
            }
            if (ItemExistente)
            {
                bag.Remove(itemRemovido);
                Console.WriteLine("O item " + itemRemovido + " foi removido da sua bag");
            }
            if (!ItemExistente)
                Console.WriteLine("Voce não possui nenhum item com esse nome");
        }
        public bool VeificarSeItemExisteNaBag(Personagem jogador1, Itens itemASerRemovido)
        {
            foreach (var item in bag)
            {
                if (itemASerRemovido.nome == item.nome)
                    return true;
            }
            return false;
        }
        public void BeberPocao(Personagem jogador1, Itens tipoPocao)
        {
            if (!VeificarSeItemExisteNaBag(jogador1, tipoPocao))
            {
                Console.WriteLine("Você não possui esse tipo de poção");
            }
            else
            {
                double recuperacao = 0;
                switch (tipoPocao.nome)
                {
                    case "poção pequena":
                        recuperacao = vidaTotal * 0.25;// 25% da vida total
                        if (recuperacao + vidaAtual >= vidaTotal)
                            jogador1.vidaAtual = vidaTotal;
                        else
                            jogador1.vidaAtual = jogador1.vidaAtual + Convert.ToInt32(recuperacao);
                        break;

                    case "poção media":
                        recuperacao = vidaTotal * 0.50;// 50% da vida total
                        if (recuperacao + vidaAtual >= vidaTotal)
                            jogador1.vidaAtual = vidaTotal;
                        else
                            jogador1.vidaAtual = jogador1.vidaAtual + Convert.ToInt32(recuperacao);
                        break;

                    case "poção grande":
                        recuperacao = vidaTotal;// toda vida
                        jogador1.vidaAtual = jogador1.vidaAtual + Convert.ToInt32(recuperacao);
                        break;
                }
                bag.Remove(tipoPocao);
                Console.WriteLine("Você bebeu a " + tipoPocao.nome);
            }
        }
    }
}




