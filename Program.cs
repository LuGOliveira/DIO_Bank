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
            
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
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
            Console.WriteLine("Obrigado por utilizar o DIO Bank!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            try
            {
                listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Conta inválida!");
            }
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            try
            { 
                listContas[indiceConta].Sacar(valorSaque);
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Conta inválida!"); 
            }
        }

        private static void Depositar()
        {
            try
            {
                Console.Write("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser depositado: ");
                double valorDeposito = double.Parse(Console.ReadLine());

                listContas[indiceConta].Depositar(valorDeposito);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Conta inválida!");
            }
        }

        private static void InserirConta()
        {
            try
            { 
                Console.WriteLine("Inserir nova conta");

                Console.Write("Digite 1 para conta de Pessoa Fisica e 2 para conta de Pessoa Juridica:");
                int entradaTipoConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o nome do cliente:");
                string entradaNome = Console.ReadLine();

                Console.Write("Digite o saldo inicial:");
                double entradaSaldo = double.Parse(Console.ReadLine());

                Console.Write("Digite o limite de crédito:");
                double entradaCredito = double.Parse(Console.ReadLine());

                Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                            saldo: entradaSaldo,
                                            credito: entradaCredito,
                                            nome: entradaNome);

                listContas.Add(novaConta);
            }
            catch (FormatException)
            {
                Console.WriteLine("Tipo de pessoa inválido!");
            }
        }

        public static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            if (listContas.Count ==0 )
            {
                Console.WriteLine("Não há contas cadastradas!");
                return;
            }
            for (int i =0; i< listContas.Count;i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }
        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("******** DIO Bank ********");
            Console.WriteLine("Informe a opção desejada :");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Despositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
