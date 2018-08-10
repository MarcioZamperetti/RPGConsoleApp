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
        public int vida;
        public int vidainimigo;
        public int ataquainimigo;
        public string resposta;
        public string nomeinimigo;
        public string fimdebatalha;

        public void Atacar()
        {
            Random rdn = new Random();
            int dano = rdn.Next(0, força);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1Seu dano foi: " + dano);
            vidainimigo = vidainimigo - dano;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1Vida do Inimigo: " + vidainimigo);
            Console.ReadKey();
        }
        public void Atacarinimigo()
        {
            {
                Random rdn = new Random();
                int dano = rdn.Next(0, ataquainimigo);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("O Inimigo Causou: " + dano);
                vida = vida - dano;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Sua Vida: " + vida);
            }
        }
        public void AutoAtacar()
        {
            Random rdn = new Random();
            int dano = rdn.Next(0, força);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Seu dano foi: " + dano);
            vidainimigo = vidainimigo - dano;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vida do Inimigo: " + vidainimigo);
        }
        public void Atacarm()
        {
            Random rdn = new Random();
            int dano = rdn.Next(0, inteligencia);
        }
        public void Batalhar()
        {
            fimdebatalha = "não";
            while (fimdebatalha == "não")
            {
                while (resposta == "3")
                {
                    while (vidainimigo >= 1)
                    {
                        AutoAtacar();
                        Atacarinimigo();
                        if (vida <= 0)
                        {
                            Console.WriteLine("Voce morreu");
                            Thread.Sleep(1500);
                            Console.Clear();

                        }

                    }
                    fimdebatalha = "sim";
                    resposta = "matou";
                    Console.WriteLine("Você Matou o inimigo");

                }
                while (resposta == "1")
                {
                    while (vidainimigo >= 1)
                    {
                        Atacar();
                        Atacarinimigo();
                        if (vida <= 0)
                        {
                            Console.WriteLine("Voce morreu");
                            Thread.Sleep(1500);
                            Console.Clear();

                        }

                    }
                    fimdebatalha = "sim";
                    resposta = "matou";
                    Console.WriteLine("Você Matou o Inimigo");
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
                        Atacarinimigo();
                        Console.WriteLine("1-Atacar 2-Correr 3-Auto Ataque");
                        resposta = Console.ReadLine();
                        fimdebatalha = "não";

                    }

                }
            }
            if (resposta == "matou")
            {

                Console.WriteLine("Boa");
                Console.ReadKey();
            }
            if (resposta == "correu")
            {

                Console.WriteLine("Boa");
                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}




