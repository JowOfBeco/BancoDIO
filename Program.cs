using System;

namespace BankTransfer
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            Conta inumerasContas = new Conta(TipoConta.PessoaFisica, 0, 0, "Johmself");
            Conta operacao = new Conta();

            operacao.Operacao();

            

        }
    }
}
