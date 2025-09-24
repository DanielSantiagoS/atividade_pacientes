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
        public void AlterarDados()
        {
            Console.WriteLine("Alterando dados do paciente...");
            AdicionarDados();
        }

        public void ListarPaciente()
        {
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("CPF: " + cpf);
            Console.WriteLine("Idade: " + idade);
            Console.WriteLine("Preferencial: " + (preferencial ? "Sim" : "Não"));
            Console.WriteLine();
        }

        public void AdicionarPaciente()
        {
            Console.Write("Digite o nome do paciente: ");
            nome = Console.ReadLine();
            Console.Write("Digite o CPF do paciente: ");
            cpf = Console.ReadLine();
            Console.Write("Digite a idade do paciente: ");
            idade = int.Parse(Console.ReadLine());
            Console.Write("O paciente necessita de atendimento preferencial? (s/n): ");
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
                    Console.WriteLine("Opção inválida! Considerando como não preferencial.");
                    preferencial = false;
                    break;
            }
            Console.WriteLine("Paciente adicionado com sucesso!");
        }

        public void AtenderPaciente()
        {
            Console.WriteLine("Atendendo paciente: " + nome);
            nome = null;
            cpf = null;
            idade = 0;
            preferencial = false;
            Console.WriteLine("Paciente atendido com sucesso!");
        }
        public void AdicionarDados()
        {
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            Console.Write("CPF: ");
            cpf = Console.ReadLine();
            Console.Write("Idade: ");
            idade = int.Parse(Console.ReadLine());
            Console.Write("Preferencial? (s/n): ");
            string resposta = Console.ReadLine();
            preferencial = resposta.ToLower() == "s";
        }

        public void MostrarDados()
        {
            Console.WriteLine($"Nome: {nome}, CPF: {cpf}, Idade: {idade}, Preferencial: {(preferencial ? "Sim" : "Não")}");
        }


    }
}
