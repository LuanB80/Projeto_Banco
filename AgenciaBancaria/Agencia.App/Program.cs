using AgenciaBancaria.Dominio;
using System;

namespace Agencia.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Endereco endereco = new Endereco("Rua rosa","1223879", "Igarassu", "Pernambuco");
                Cliente cliente = new Cliente
                    ("Luan", "12345", "789456", endereco);

                ContaCorrente conta = new ContaCorrente(cliente, 100);

                Console.WriteLine("Conta " + conta.Situacao + ": " + "Conta criada: " + conta.NumeroConta + "-" +
                    conta.DigitoVerificador);

                string senha = "abc123456789";
                conta.Abrir(senha);

                Console.WriteLine("Conta " + conta.Situacao + ": " + "Conta criada: " + conta.NumeroConta + "-" +
                    conta.DigitoVerificador);


                conta.Sacar(10, senha);

                Console.WriteLine("Saldo:" + conta.Saldo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
