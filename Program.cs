using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() !="X")
            {
                switch (opcaoUsuario)
                {
                case "1":
                   ListarContas();
                    break;
                case "2":
                    InserirConta();
                    break;
                case "3":
                    Transferir();
                    break;
                case "4":
                    Sacar();
                    break;
                case "5":
                    Depositar();
                    break;
                case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar nossos serviços");
            Console.WriteLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da Conta Origem: ");
             int indiceContaOrigem = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite o numero da Conta Destino: ");
             int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
             double valorTransferencia = double.Parse(Console.ReadLine());

             listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da Conta: ");
             int indiceConta = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite o valor depositado: ");
             double valorDeposito = double.Parse(Console.ReadLine());

             listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
             Console.WriteLine("Digite o numero da Conta: ");
             int indiceConta = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite o valor do saque: ");
             double valorSaque = double.Parse(Console.ReadLine());
             listContas[indiceConta].Sacar(valorSaque);
             
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");
                        
            Console.WriteLine("Digite 1 para Conta Fisica e 2 para Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta) entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for (int i =0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao Banco Kalango");
            Console.WriteLine("Digite a opção desejada");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;                        
        }
    }
}
