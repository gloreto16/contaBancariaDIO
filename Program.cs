using System;
using System.Collections.Generic;

namespace DIO.Banco
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarConta();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        TransferirConta();
                        break;
                    case "4":
                        SacarConta();
                        break;
                    case "5":
                        DepositarConta();
                        break;
                    case "6":
                        PagamentoConta();
                        break;
                    case "7":
                        RecargaCelularConta();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void InserirConta()
        {
            Console.WriteLine("Você escolheu inserir uma nova conta");

            Console.Write("Insira o tipo da conta, sendo 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            while(entradaTipoConta > 2 || entradaTipoConta < 1)
            {
                Console.Write("Escolha inválida, favor escolher uma das opções demonstradas.");
                entradaTipoConta = int.Parse(Console.ReadLine());
            }
            Console.Write("Insira o nome do(a) Cliente: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Insira o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write("Insira o crédito da conta: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito, 
                                        nome: entradaNome);
            listaContas.Add(novaConta);
            Console.WriteLine("Conta criada com sucesso!");
        }

        private static void ListarConta()
        {
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void SacarConta()
        {
            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());
            while(numeroConta > listaContas.Count - 1 || numeroConta < 0)
            {
                Console.WriteLine("Número inválido na escolha da conta, por favor escolha um conta que existe no sistema.");
                numeroConta = int.Parse(Console.ReadLine());
            }
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[numeroConta].Sacar(valorSaque);
        }

        private static void DepositarConta()
        {
            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());
            while(numeroConta > listaContas.Count - 1 || numeroConta < 0)
            {
                Console.WriteLine("Número inválido na escolha da conta, por favor escolha um conta que existe no sistema.");
                numeroConta = int.Parse(Console.ReadLine());
            }
            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[numeroConta].Depositar(valorDeposito);
        }

        private static void TransferirConta()
        {
            Console.Write("Digite o número da conta de origem: ");
            int numeroContaOrigem = int.Parse(Console.ReadLine());
            while(numeroContaOrigem > listaContas.Count - 1 || numeroContaOrigem < 0)
            {
                Console.WriteLine("Número inválido na escolha da conta, por favor escolha um conta que existe no sistema.");
                numeroContaOrigem = int.Parse(Console.ReadLine());
            }
            Console.Write("Digite o número da conta de destino: ");
            int numeroContaDestino = int.Parse(Console.ReadLine());
            while(numeroContaDestino > listaContas.Count - 1 || numeroContaDestino < 0)
            {
                Console.WriteLine("Número inválido na escolha da conta, por favor escolha um conta que existe no sistema.");
                numeroContaDestino = int.Parse(Console.ReadLine());
            }
            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[numeroContaOrigem].Transferir(valorTransferencia, listaContas[numeroContaDestino]);
        }

        private static void PagamentoConta()
        {
            Console.WriteLine("Escolha a conta que será efetuado o pagamento: ");
            int numeroConta = int.Parse(Console.ReadLine());
            while(numeroConta > listaContas.Count - 1 || numeroConta < 0)
            {
                Console.WriteLine("Número inválido na escolha da conta, por favor escolha um conta que existe no sistema.");
                numeroConta = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Escolha a conta a ser paga: \n1 - Conta de Água\n2 - Conta de Luz\n3 - Conta de Internet");
            int numeroPagar = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o valor da conta: ");
            double valorConta = double.Parse(Console.ReadLine());

            bool verificacao = listaContas[numeroConta].Sacar(valorConta);
            if(verificacao == true)
            {
                listaContas[numeroConta].Pagar(valorConta, (Pagamentos)numeroPagar);
            }
            else
            {
                Console.WriteLine("Pagamento não efetuado.");
            }
        }

        private static void RecargaCelularConta()
        {
            Console.WriteLine("Escolha com qual conta será feita a recarga: ");
            int numeroConta = int.Parse(Console.ReadLine());
            while(numeroConta > listaContas.Count - 1 || numeroConta < 0)
            {
                Console.WriteLine("Número inválido na escolha da conta, por favor escolha um conta que existe no sistema.");
                numeroConta = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Insira o DDD: ");
            int ddd = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o número de telefone (sem o 9 extra): ");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o valor referente a recarga: ");
            double valorRecarga = double.Parse(Console.ReadLine());

            bool verificacao = listaContas[numeroConta].Sacar(valorRecarga);
            if(verificacao == true)
            {
                listaContas[numeroConta].Recarregar(valorRecarga, ddd, numero);
            }
            else
            {
                Console.WriteLine("Recarga não efetuada.");
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("========================");
            Console.WriteLine("Bem-vindo(a) ao Toreto´s Bank!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir um valor");
            Console.WriteLine("4 - Sacar um valor");
            Console.WriteLine("5 - Depositar um valor");
            Console.WriteLine("6 - Pagar uma conta");
            Console.WriteLine("7 - Recarga de Celular");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("========================");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
