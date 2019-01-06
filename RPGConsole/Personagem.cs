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
        public string nome;
        public int idade;
        public string classe;
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
        public int gold;
        public int silver;
        List<Itens> bag = new List<Itens>();
        public Itens itensEquipadoArma;
        public Itens itensEquipadoAmadura;

        public void Atacar(Inimigos inimigo)
        {
            Random rdn = new Random();
            int dano;
            if (classe == "Mago")
            {
                dano = rdn.Next(0, inteligencia) + itensEquipadoArma.dano;
            }
            else
            {
                dano = rdn.Next(0, força) + itensEquipadoArma.dano;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1Seu dano foi: " + dano);
            inimigo.vida = inimigo.vida - dano;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1Vida do Inimigo: " + inimigo.vida);
            Console.ReadKey();
        }
        public void Atacarinimigo(Inimigos inimigo)
        {
            {
                Random rdn = new Random();
                int dano = rdn.Next(0, inimigo.força);
                dano = dano - itensEquipadoAmadura.armadura;
                if (dano < 0)
                    dano = 0;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("O Inimigo Causou: " + dano);
                vidaAtual = vidaAtual - dano;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Sua Vida: " + vidaAtual);
            }
        }
        public void AutoAtacar(Inimigos inimigo)
        {
            Random rdn = new Random();
            int dano;
            if (classe == "Mago")
            {
                dano = rdn.Next(0, inteligencia) + itensEquipadoArma.dano;
            }
            else
            {
                dano = rdn.Next(0, força) + itensEquipadoArma.dano;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Seu dano foi: " + dano);
            inimigo.vida = inimigo.vida - dano;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vida do Inimigo: " + inimigo.vida);
        }
        public void Batalhar(Personagem jogador1, Inimigos inimigo)
        {
            fimdebatalha = "não";
            while (fimdebatalha == "não")
            {
                while (resposta == "3")
                {
                    while (inimigo.vida >= 1)
                    {
                        AutoAtacar(inimigo);
                        Atacarinimigo(inimigo);
                        if (vidaAtual <= 0)
                        {
                            Console.WriteLine("Voce morreu");
                            Thread.Sleep(1500);
                            Console.Clear();

                        }

                    }
                    fimdebatalha = "sim";
                    resposta = "matou";
                    Console.WriteLine("Você Matou o inimigo");
                    Console.WriteLine("XP ganho: " + inimigo.xpGanho);
                    xp = xp + inimigo.xpGanho;
                    Console.WriteLine("XP Total: " + xp);
                    CalcularNivel(jogador1);

                }
                while (resposta == "1")
                {
                    while (inimigo.vida >= 1)
                    {
                        Atacar(inimigo);
                        Atacarinimigo(inimigo);
                        if (vidaAtual <= 0)
                        {
                            Console.WriteLine("Voce morreu");
                            Thread.Sleep(1500);
                            Console.Clear();

                        }

                    }
                    fimdebatalha = "sim";
                    resposta = "matou";
                    Console.WriteLine("Você Matou o Inimigo");
                    Console.WriteLine("XP ganho: " + inimigo.xpGanho);
                    xp = xp + inimigo.xpGanho;
                    Console.WriteLine("XP Total: " + xp);
                    CalcularNivel(jogador1);
                }
                while (resposta == "2")
                {
                    Random rdn = new Random();
                    int correr = rdn.Next(1, 23);
                    if (correr == 1)
                    {
                        Console.WriteLine("Voce correu do inimigo");
                        resposta = "correu";
                    }

                    else
                    {
                        Console.WriteLine("Voce falhou em correr do inimigo");
                        Atacarinimigo(inimigo);
                        Console.WriteLine("1-Atacar 2-Correr 3-Auto Ataque");
                        resposta = Console.ReadLine();
                        fimdebatalha = "não";
                    }

                }
            }
            if (resposta == "matou")
            {
                Console.WriteLine("Boa");
            }
            if (resposta == "correu")
            {
                Console.WriteLine("Boa");
            }
            Console.ReadKey();
        }
        public void CriarPersonagem(Personagem jogador1)
        {
            try
            {
                resposta = "não";
                while (resposta == "não")
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Digite seu nome");
                    jogador1.nome = Console.ReadLine();
                    Console.WriteLine(jogador1.nome + " Qual sua Idade?");
                    jogador1.idade = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(jogador1.nome + " Escolha uma classe: " + "Arqueiro, Mago ou Guerreiro");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Digite 1 para Arquerio: Força 2, Inteligencia 2, Vida 10");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Digite 2 para Mago: Força 1, Inteligencia 4, Vida 5");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite 3 para Guerreiro: Força 4, Inteligencia 0, Vida 15");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Digite o nome da classe que deseja:");
                    jogador1.classe = Console.ReadLine();
                    Itens arma = new Itens();
                    Itens armadura = new Itens();
                    switch (jogador1.classe)
                    {

                        case "1": //Arqueiro
                            jogador1.classe = "Arqueiro";
                            Console.WriteLine("Confirme seus dados, NOME: " + jogador1.nome + " Idade: " + jogador1.idade + " CLasse " + jogador1.classe);
                            jogador1.força = 3;
                            jogador1.inteligencia = 2;
                            jogador1.vidaAtual = 15;
                            jogador1.vidaTotal = 15;
                            jogador1.nivel = 1;
                            jogador1.xp = 0;                         
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
                            Console.WriteLine("Seus dados estão corretos? " + "1-sim ou 2-não");
                            resposta = Console.ReadLine();
                            break;

                        case "2"://MAgo
                            jogador1.classe = "Mago";
                            Console.WriteLine("Confirme seus dados, NOME: " + jogador1.nome + " Idade: " + jogador1.idade + " CLasse " + jogador1.classe);
                            jogador1.força = 2;
                            jogador1.inteligencia = 4;
                            jogador1.vidaAtual = 10;
                            jogador1.vidaTotal = 10;
                            jogador1.nivel = 1;
                            jogador1.xp = 0;
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
                            Console.WriteLine("Seus dados estão corretos? " + "1-sim ou 2-não");
                            resposta = Console.ReadLine();
                            break;
                        case "3"://Guerreiro
                            jogador1.classe = "Guerreiro";
                            Console.WriteLine("Confirme seus dados, NOME: " + jogador1.nome + " Idade: " + jogador1.idade + " CLasse " + jogador1.classe);
                            jogador1.força = 5;
                            jogador1.inteligencia = 1;
                            jogador1.vidaAtual = 20;
                            jogador1.vidaTotal = 20;
                            jogador1.nivel = 1;
                            jogador1.xp = 0;
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
                            Console.WriteLine("Seus dados estão corretos? " + "1-sim ou 2-não");
                            resposta = Console.ReadLine();
                            break;
                    }

                }
                Console.WriteLine("Personagem criado com sucesso.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nome: " + jogador1.nome);
                Console.WriteLine("Idade: " + jogador1.idade);
                Console.WriteLine("Classe: " + jogador1.classe);
                Console.WriteLine("");
                Console.WriteLine("Atributos:");
                Console.WriteLine("Força: " + jogador1.força);
                Console.WriteLine("Inteligencia: " + jogador1.inteligencia);
                Console.WriteLine("Vida: " + jogador1.vidaTotal);
                Console.WriteLine("");
                Console.WriteLine("Itens:");
                Console.WriteLine("Arma " + itensEquipadoArma.nome);
                Console.WriteLine("Armadura " + itensEquipadoAmadura.nome);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.WriteLine("SELEÇÃO INVÁLIDA");
                CriarPersonagem(jogador1);
            }
        }
        public void CalcularNivel(Personagem jogador1)
        {
            if (xp >= xpProxNivel)
            {
                nivel = nivel + 1;
                xpProxNivel = xpProxNivel * 2;
                jogador1.nivel = nivel;
                jogador1.vidaTotal = vidaTotal + vidaTotal;
                jogador1.vidaAtual = jogador1.vidaTotal;
                jogador1.força = força + força;
                jogador1.inteligencia = inteligencia + inteligencia;
                Console.WriteLine("Você subio de Nivel: " + nivel);
                Console.WriteLine("Atributos:");
                Console.WriteLine("Força: " + jogador1.força);
                Console.WriteLine("Inteligencia: " + jogador1.inteligencia);
                Console.WriteLine("Vida: " + jogador1.vidaAtual);
                Console.ForegroundColor = ConsoleColor.White;
            }
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
        }
        public void OlharBag(Personagem jogador1)
        {
            if (bag.Count == 0)
                Console.WriteLine("Não há itens na sua bag");
            else
            {
                Console.WriteLine("Item na sua Bag:");
                bag.ForEach(i => Console.WriteLine(i));
            }
        }
        public void AdicionarItemNaBag(Personagem jogador1, Itens itemAdicionado)
        {
            bag.Add(itemAdicionado);
            Console.WriteLine("O item " + itemAdicionado + "foi adicionado a sua bag");
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
                if (itemASerRemovido == item)
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




