using System;
using System.Collections.Generic;

namespace Farmacia
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            List<string> remedios = new List<string>();
            remedios.Add("doril");
            remedios.Add("mioprol");
            remedios.Add("resfenol");
            remedios.Add("acnezil");
            remedios.Add("artrosil");
            remedios.Add("gardenal");
            remedios.Sort();    


            Console.WriteLine("Quantidade de elementos do array: " + remedios.Count);
            

            bool escolheuSair = false;
            while (!escolheuSair)
            {             
                Console.WriteLine("Digite o nome do remédio: ");
                string nome = Console.ReadLine().ToLower();

                string busca = remedios.Find(n => n == nome);
                if (busca != null)
                {
                    for (int i = 0; i < remedios.Count; i++)
                    {
                        if (remedios[i] == nome)
                        {
                            Console.WriteLine("Remedio encontra-se na posição: " + i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Este remédio não existe");
                }

                Console.WriteLine("Digite o nome final do remédio para procurar: ");
                string nomeFinal = Console.ReadLine().ToLower();


                List<string> buscaFinal = remedios.FindAll(n => n.Substring(n.IndexOf('l')-1) == nomeFinal);

                if (buscaFinal.Count > 0)
                {
                    foreach (string remedio in buscaFinal)
                    {
                        Console.WriteLine(remedio);
                    }
                }
                else if(buscaFinal.Count == 0)
                {
                    Console.WriteLine("Não possui remédio com esse final.");
                }

                Console.WriteLine("Digite ENTER para novas buscas...");
                Console.WriteLine("Ou digite a palavra SAIR para sair do sistema.");
                string sair = Console.ReadLine().ToLower();
                Console.Clear();
                if(sair == "sair")
                {
                    escolheuSair = true;
                }

            }

            
            
        }
    }
}
