using System;
using System.Collections.Generic;

namespace BankTransfer
{
    public class Conta
    {
        List<Conta> listContas = new List<Conta>();
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta()
        {

        }
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double saque)
        {
            if (this.Saldo - saque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= saque;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é: {this.Saldo}.");
            return true;

        }
        public void Depositar(double deposito)
        {
            this.Saldo += deposito;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é de: {this.Saldo}.");
        }
        public void Transferir(double transferencia, Conta contaDestino)
        {
            //Reutilizando os métodos anteriores
            if (Sacar(transferencia))
            {
                contaDestino.Depositar(transferencia);
            }
            else
            {
                System.Console.WriteLine("Saldo insuficiente para transferência.");
            }

        }

        public override string ToString()
        {

            return
            "TipoConta: " + this.TipoConta +
            ", Nome: " + this.Nome +
            ", Saldo: " + this.Saldo +
            ", Crédito: " + this.Credito;

        }
        public string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank - Seja Bem Vindo!");
            Console.WriteLine("Informe");
            Console.WriteLine("1 - Listar contas:");
            Console.WriteLine("2 - Inserir nova conta:");
            Console.WriteLine("3 - Transferência:");
            Console.WriteLine("4 - Sacar:");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair ");
            return Console.ReadLine().ToUpper();
        }

        public void Operacao()
        {
            string opcao = ObterOpcaoUsuario().ToUpper();
            while (opcao != "X")
            {

                switch (opcao)
                {

                    case "1":
                        OperacaoListarConta();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        OperacaoTransferir();
                        break;
                    case "4":
                        OperacaoSacar();
                        break;
                    case "5":
                        OperacaoDepositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Opção inválida.");
                }
                opcao = ObterOpcaoUsuario().ToUpper();
            }
            Console.WriteLine("Certo, até a próxima !");
        }

        private void OperacaoDepositar()
        {
            Console.WriteLine("Digite o número da conta:");
            int indice = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do depósito");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indice].Depositar(valorDeposito);
        }

        private void OperacaoSacar()
        {
            Console.WriteLine("Digite o número da conta:");
            int indice = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do saque");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indice].Sacar(valorSaque);
        }

        private void OperacaoTransferir()
        {
            Console.WriteLine("Digite o número da conta remetente:");
            int indiceRemetente = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o número da conta destinatária:");
            int indiceDestinataria = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da transferencia");
            double valorTransferencia = double.Parse(Console.ReadLine());


            listContas[indiceRemetente].Transferir(valorTransferencia, listContas[indiceDestinataria]);
        }

        private void InserirConta()
        {
            Console.WriteLine("Inserção de contas novas:");
            Console.WriteLine("Digite [1] para Conta Fisica e [2] para Conta Jurídica.");
            int tipoContaNova = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente:");
            string nomeContaNova = Console.ReadLine();

            Console.WriteLine("Digite o Saldo Inicial:");
            double saldoContaNova = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito:");
            double creditoContaNova = double.Parse(Console.ReadLine());

            Conta contaNova = new Conta(tipoConta: (TipoConta)tipoContaNova, //conversão para enum do TipoConta
            saldo: saldoContaNova, credito: tipoContaNova, nome: nomeContaNova);

            listContas.Add(contaNova);

        }

        private void OperacaoListarConta()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("Não existem dados a serem consultados");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write($"{i}: ");
                Console.WriteLine(conta);
            }
        }

    }

}