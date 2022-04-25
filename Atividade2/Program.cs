using System;

namespace Jogo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = new Random().Next(1, 10);
            Console.WriteLine("Estou pensando em um número entre 1 e 10. Tente adivinhar!");

            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine("Digite o seu palpite -> ");
                int numero = int.Parse(Console.ReadLine());
                if (numero == input)
                {
                    Console.WriteLine("Acertouuuuuuuu! Você é brabo");
                    i = 0;
                }
                else if (numero == input - 1 || numero == input + 1)
                {
                    Console.WriteLine($"Errrrrouuu! Mas foi um bom chute, siga por esse caminho...");
                    Console.WriteLine($"As chances estão acabando. Só restam {i - 1} chances");
                }
                else
                {
                    Console.WriteLine("Errrrrrrrouuuuu! Fraco e sem talento...");
                    Console.WriteLine($"As chances estão acabando. Só restam {i - 1} chances");
                }

                
            }
        }
    }
}
