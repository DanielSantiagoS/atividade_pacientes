
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_pacientes
{

    internal class paciente
    {
        public string nome;
        public string cpf;
        public int idade;
        public bool preferencial;
        public void alt()
        {
            Console.WriteLine("Alterando dados");
            addD();
        }

        public void list()
        {
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("CPF: " + cpf);
            Console.WriteLine("Idade: " + idade);
            Console.WriteLine("Preferencial: " + (preferencial ? "Sim" : "Não"));
            Console.WriteLine();
        }

        public void adicionarpaciente()
        {
            Console.Write("Digite o nome do paciente: ");
            nome = Console.ReadLine();
            Console.Write("Digite o CPF do paciente: ");
            cpf = Console.ReadLine();
            Console.Write("Digite a idade do paciente: ");
            idade = int.Parse(Console.ReadLine());
            Console.Write("O paciente é preferencial? (s/n): ");
            string resposta = Console.ReadLine();
            switch (resposta.ToLower())
            {
                case "s":
                    preferencial = true;
                    break;
                case "n":
                    preferencial = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    preferencial = false;
                    break;
            }
            Console.WriteLine("Paciente adicionado");
        }

        public void atender()
        {
            Console.WriteLine("Atendendo paciente: " + nome);
            nome = null;
            cpf = null;
            idade = 0;
            preferencial = false;
            Console.WriteLine("Paciente atendido");
        }
        public void addD()
        {
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            Console.Write("CPF: ");
            cpf = Console.ReadLine();
            Console.Write("Idade: ");
            idade = int.Parse(Console.ReadLine());
            Console.Write("Preferencial? (s ou n): ");
            string resposta = Console.ReadLine();
            preferencial = resposta.ToLower() == "s";
        }

        public void MostrarDados()
        {
            Console.WriteLine($"Nome: {nome}\n CPF: {cpf}\n Idade: {idade}\n Preferencial: {(preferencial ? "Sim" : "Não")}");
        }


    }
}
