using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Atividade_pacientes;

namespace filadeespera
{
    internal class Program
    {
        static paciente[] fila = new paciente[15];
        static int total = 0;

        static void Main(string[] args)
        {
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
                        AdicionarNaFila();
                        break;

                    case "2":
                        ListarFila();
                        break;

                    case "3":
                        AlterarPaciente();
                        break;

                    case "4":
                        AtenderPaciente();
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

        static void AdicionarNaFila()
        {
            if (total < fila.Length)
            {
                paciente novo = new paciente();
                novo.AdicionarDados();

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
                Console.WriteLine("Paciente adicionado!");
            }
            else
            {
                Console.WriteLine("Fila cheia!");
            }
        }


        static void ListarFila()
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

        static void AlterarPaciente()
        {
            Console.Write("Digite o número do paciente para alterar: ");
            int indice = int.Parse(Console.ReadLine()) - 1;
            if (indice >= 0 && indice < total)
            {
                fila[indice].AlterarDados();
            }
            else
            {
                Console.WriteLine("Número inválido!");
            }
        }

        static void AtenderPaciente()
        {
            if (total == 0)
            {
                Console.WriteLine("Nenhum paciente na fila!");
                return;
            }

            Console.WriteLine("Atendendo paciente:");
            fila[0].MostrarDados();

            for (int i = 0; i < total - 1; i++)
            {
                fila[i] = fila[i + 1];
            }
            fila[total - 1] = null;
            total--;

            Console.WriteLine("Paciente atendido com sucesso!");
        }
    }
}