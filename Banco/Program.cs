using System;
using System.Collections.Generic;

namespace Banco
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args){
            string opcaoUsuario = obterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){

                    case "1":
                        listarContas();
                        break;

                    case "2":
                        inserirConta();
                        break;
                    case "3":
                        transferir();
                        break;
                    case "4":
                        sacar();
                        break;    
                    case "5":
                        depositar();
                        break;
                    case "6":
                        exibirTransacoes();
                        break;    
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();        
                }
                opcaoUsuario = obterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void inserirConta(){
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta física ou 2 para jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);                            
        }

        private static void depositar(){
            Console.Write("Digite o número da conta: ");
            int nConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[nConta].depositar(valorDeposito);
        }

        private static void sacar(){
            Console.Write("Digite o número da conta: ");
            int nConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[nConta].sacar(valorSaque);
        }

        private static void transferir(){
            Console.Write("Digite o número da conta de origem: ");
            int nContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int nContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[nContaOrigem].transferir(valorTransferencia, listContas[nContaDestino]);
        }

        private static void listarContas(){
            Console.WriteLine("Listar contas");

            if(listContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void exibirTransacoes(){
            Console.Write("Digite o número da conta: ");
            int nConta = int.Parse(Console.ReadLine());

            listContas[nConta].exibirTransacoes();
        }

        private static string obterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao banco!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Exibir transações");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
