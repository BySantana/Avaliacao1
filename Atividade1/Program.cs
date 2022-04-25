using System;
using System.Collections.Generic;

namespace VendasComissoes
{
    internal class Program
    {
        public class Vendedor
        {
            public int IdVendedor { get; set; }
            public int QtdeVendas { get; set; }
            public double ValorTotalVendas { get; set; }
            public double Comissao { get; set; }

            public Vendedor()
            {
            }

            public Vendedor(int idVendedor, int qtdeVendas, double valorTotalVendas)
            {
                IdVendedor = idVendedor;
                QtdeVendas = qtdeVendas;
                ValorTotalVendas = valorTotalVendas;
            }
            public override string ToString()
            {
                return $"ID: {IdVendedor}, Vendas: {QtdeVendas}, Comissao: R${Comissao}";
            }

            public static List<Vendedor> VendedoresRepository()
            {
                List<Vendedor> vendedores = new List<Vendedor>();
                vendedores.Add(new Vendedor(1, 0, 0));
                vendedores.Add(new Vendedor(2, 0, 0));
                vendedores.Add(new Vendedor(3, 0, 0));
                return vendedores;
            }
            public void CalcularComissao()
            {
                if(QtdeVendas > 0 && QtdeVendas <= 5)
                {
                    Comissao += ValorTotalVendas * 0.004; 
                }else if(QtdeVendas > 5 && QtdeVendas <= 10)
                {
                    Comissao += ValorTotalVendas * 0.013;
                }
                else if (QtdeVendas > 10 && QtdeVendas <= 15)
                {
                    Comissao += ValorTotalVendas * 0.03;
                }
                else if (QtdeVendas > 15)
                {
                    Comissao += ValorTotalVendas * 0.05;
                }

            }
        }
        public class Produto
        {
            public string nome { get; set; }
            public int qtde { get; set; }

            public Produto(string nome, int qtde)
            {
                this.nome = nome;
                this.qtde = qtde;
            }

            public override string ToString()
            {
                return $"Produto: {nome} => Quantidade em estoque: {qtde}\n";
            }

            public static List<Produto> ProdutosRepository()
            {
                List<Produto> produtos = new List<Produto>();
                produtos.Add(new Produto("agua", 30));
                produtos.Add(new Produto("caneta", 35));
                produtos.Add(new Produto("chocolate", 38));
                produtos.Add(new Produto("livro", 5));
                produtos.Add(new Produto("roupa", 20));
                return produtos;
            }
        }
        static void Main(string[] args)
        {
            List<Produto> produtos = Produto.ProdutosRepository();
            List<Vendedor> vendedores = Vendedor.VendedoresRepository();
            
            Console.WriteLine("Digite a quantidade de vendas: ");
            int qtdeVendas = int.Parse(Console.ReadLine());
            int qtdeProdutos = 0;
            Vendedor resu2 = new Vendedor();

            for (int i = 0; i < qtdeVendas; i++)
            {
                Console.WriteLine("Digite qual será o produto: ");
                string produto = Console.ReadLine().ToLower();
                Produto resu = produtos.Find(p => p.nome == produto);
                if (resu != null)
                {
                    Console.WriteLine("Digite a quantidade que será comprada: ");
                    int qtdeProduto = int.Parse(Console.ReadLine());
                    if (qtdeProduto <= resu.qtde)
                    {
                        Console.WriteLine("Compra efetuada com sucesso.");
                        resu.qtde -= qtdeProduto;
                        qtdeProdutos = qtdeProduto;
                    }
                    else if (qtdeProduto > resu.qtde)
                    {
                        Console.WriteLine($"Quantidade acima do estoque. Só serão vendidos {resu.qtde}");
                        qtdeProdutos = resu.qtde;
                        resu.qtde = 0;
                        
                    }
                }
                else
                {
                    Console.WriteLine("Este produto não existe.");
                    i--;
                }
                Console.WriteLine("Digite o id do vendedor: ");
                int idVendedor = int.Parse(Console.ReadLine());
                resu2 = vendedores.Find(v => v.IdVendedor == idVendedor);
                if (resu2 != null)
                {
                    resu2.QtdeVendas = qtdeProdutos;
                    Console.WriteLine("Qual foi o valor total da venda: ");
                    double valorVenda = double.Parse(Console.ReadLine());
                    resu2.ValorTotalVendas += valorVenda; 
                    resu2.CalcularComissao();
                }
                else
                {
                    Console.WriteLine("Id inválido");
                }

                if(resu.qtde <= 3)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("AVISO! Um dos produtos do estoque não está de acordo com a quantidade mínima.\n");
                    foreach (Produto p in produtos)
                    {
                        Console.WriteLine(p);
                    }
                    Console.WriteLine("---------------------------------------------------");
                }
                
                Console.WriteLine("ENTER para continuar...");
                Console.ReadLine();
                Console.Clear();
            }

            
            foreach(Vendedor c in vendedores)
            {
                Console.WriteLine(c);
            }
        }
    }
}
