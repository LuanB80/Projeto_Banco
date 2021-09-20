using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class Cliente
    {
        public Cliente(string nome, string cpf, string rg, Endereco endereco)
        {
            /*if (string.IsNullOrWhiteSpace(nome))//esse metodo, vê se nessa string, só tem espaço em branco ou esta vazia mesmo
            {//aqui se o nome for vazio, eu disparo essa mensagem de excesão 
                throw new Exception("A propriedade deve está prenchida");
            }*/

            Nome = nome.ValidarStringVazia();
            CPF = cpf.ValidarStringVazia();
            RG = rg.ValidarStringVazia();
            Endereco = endereco ?? throw new Exception("Endereço deve ser informado");
        } //Aqui estou atribuindo para o endereço, a minha variavel ou se estiver nulo, a minha exceção                                                   //nulo, atribui oq esta no lado direito



        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }

        public Endereco Endereco { get; private set; }

   
    }
}
