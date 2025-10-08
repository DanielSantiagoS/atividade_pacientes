using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Atividade_pacientes;

namespace filadeespera
{
    internal class Program
    {
        public paciente[] fila = new paciente[15];
        public int total = 0;


       public static void Main(string[] args)
        {
            Program pac = new Program();

            bool encerrar = false;

            while (!encerrar)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1 - Adicionar paciente");
                Console.WriteLine("2 - Listar pacientes");
                Console.WriteLine("3 - Alterar paciente");
                Console.WriteLine("4 - Atender paciente");
                Console.WriteLine("q - Sair");
                Console.Write("Escolha: ");
                string opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                      pac.add();
                        break;

                    case "2":
                        pac.list();
                        break;

                    case "3":
                        pac.alt();
                        break;

                    case "4":
                        pac.atender();
                        break;

                    case "q":
                        encerrar = true;
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }




        public void add()
        {
            if (total < fila.Length)
            {
                paciente novo = new paciente();
                novo.addD();

                if (novo.preferencial)
                {
                    int pos = 0;
                    while (pos < total && fila[pos].preferencial)
                    {
                        pos++;
                    }
                    for (int i = total; i > pos; i--)
                    {
                        fila[i] = fila[i - 1];
                    }

                    fila[pos] = novo;
                }




                else
                {

                    fila[total] = novo;
                }

                total++;
                Console.WriteLine("Paciente adicionado");
            }
            else
            {
                Console.WriteLine("Fila cheia");
            }
        }




        public void list()
        {
            if (total == 0)
            {
                Console.WriteLine("Nenhum paciente na fila.");
                return;
            }

            for (int i = 0; i < total; i++)
            {
                Console.Write($"{i + 1} - ");
                fila[i].MostrarDados();
            }
        }





        public void alt()
        {
            Console.Write("digite o número do paciente ");
            int indice = int.Parse(Console.ReadLine()) - 1;
            if (indice >= 0 && indice < total)
            {
                fila[indice].alt();
            }
            else
            {
                Console.WriteLine("erro");
            }
        }





        public void atender()
        {
            if (total == 0)
            {
                Console.WriteLine("Nenhum paciente na fila");
                return;
            }




            Console.WriteLine("atendendo");
            fila[0].MostrarDados();

            for (int i = 0; i < total - 1; i++)
            {
                fila[i] = fila[i + 1];
            }
            fila[total - 1] = null;
            total--;

            Console.WriteLine("paciente atendido");
        }
    }
}