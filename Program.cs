using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAula09Estacionamento
{
    internal class Program
    {

        static void reiniciarLoop()
        {
            Console.WriteLine("\nENTER para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            List<string> vagas = new List<string> { "[______]", "[______]", "[______]", "[______]", "[______]", "[______]" };

            Console.WriteLine("Bem-vindo ao Estacione Aqui");
            Console.WriteLine("Suportamos 6 veículos!");

            while (true)
            {
                string placaDoCarro;

                Console.WriteLine("1 - Estacionar");
                Console.WriteLine("2 - Retirar veículo");
                Console.WriteLine("3 - Listar veículo\n");
                Console.Write("opção: ");
                string opcao = Console.ReadLine();

                //ESTACIONAR
                if (opcao == "1")
                {
                    Console.Write("Selecione o indice da vaga que você deseja estacionar: ");
                    int vaga = int.Parse(Console.ReadLine());

                    if ((vaga > 6) || (vaga < 1))
                    {
                        Console.WriteLine("\nEssa vaga não existe!");
                        reiniciarLoop();
                    }
                    else
                    {
                        vaga = vaga - 1;

                        if (vagas[vaga] == "[______]")
                        {
                            Console.WriteLine("Vaga disponível!");
                            Console.Write("Agora insira a placa do carro: ");
                            placaDoCarro = Console.ReadLine();

                            if (placaDoCarro.Length != 6)
                            {
                                Console.WriteLine("\nplaca inválida!");
                                reiniciarLoop();
                            }
                            else
                            {
                                placaDoCarro = "[" + placaDoCarro.ToUpper() + "]";
                                vagas[vaga] = placaDoCarro;

                                Console.WriteLine("\nCarro estacionado!");
                                reiniciarLoop();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nVaga indisponível!");
                            reiniciarLoop();
                        }
                    }
                }

                //RETIRAR

                if (opcao == "2")
                {
                    Console.Write("Insira a placa do veículo que deseja retirar: ");
                    placaDoCarro = Console.ReadLine();



                    if (placaDoCarro.Length != 6)
                    {
                        Console.WriteLine("\nplaca inválida!");
                        reiniciarLoop();
                    }
                    else
                    {
                        placaDoCarro = "[" + placaDoCarro.ToUpper() + "]";

                        int cont = 0;
                        while (cont < vagas.Count)
                        {

                            if (vagas[cont] == placaDoCarro)
                            {
                                vagas[cont] = "[______]";
                                Console.WriteLine("\nVeículo removido com sucesso!");
                                reiniciarLoop();
                                break;
                            }
                            cont++;
                        }
                        if (cont + 1 == 7)
                        {
                            Console.WriteLine("\nVeículo não encontrado...");
                            reiniciarLoop();
                        }
                    }
                }

                //LISTAR

                if (opcao == "3")
                {
                    int cont = 0;
                    string listaTratada = "";
                    while (cont < vagas.Count)
                    {


                        listaTratada = listaTratada + " " + vagas[cont];
                        cont++;
                    }

                    Console.Write($"\nLista de vagas: {listaTratada}");
                    reiniciarLoop();
                }
            }
        }
    }
}
