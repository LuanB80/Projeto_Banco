using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public abstract class ContaBancaria//abstract significa que ela não pode ser instanciada
    {

        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random();// tô instanciando valores randomicos
            NumeroConta = random.Next(50000, 100000);
            DigitoVerificador = random.Next(1, 9);

            Situacao = SituacaoConta.Criada;

            cliente = cliente ?? throw new Exception("O cliente deve ser informado.");
        }

        public void Abrir(string senha)
        {
            SetaSenha(senha);

            Situacao = SituacaoConta.Aberta;
            DataAbertura = DateTime.Now;
        }

        private void SetaSenha(string senha)
        {
            senha = senha.ValidarStringVazia();

            if (!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))//aqui está validando, se minha senha atende essa expressão regular
            {
                throw new Exception("Senha inválida");
            }

            Senha = senha;
        }

        public virtual void Sacar(decimal valor, string senha)
        {
            if (Senha != senha)
            {
                throw new Exception("Senha inválida");
            }

            if (Saldo < valor)
            {
                throw new Exception("Saldos insuficiente");
            }

            Saldo -= valor;
        }

        public int NumeroConta { get; init; }//significa que eu só vou mexer no primeiro construtor
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }// protected, significa que a minha classe filha pode mexer n
        public DateTime? DataAbertura { get; private set; }// essa interrogação, significa que pode ser permite ser nulo
        public DateTime? DataEncerramento { get; private set; }
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; init; }
    }
}
