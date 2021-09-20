using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public static class Validacoes//static significa que eu não posso estancia essa classe
    {
        public static string ValidarStringVazia(this string texto)//isso aqui faz a mesma coisa do if, da classe de clientes
        {
            return string.IsNullOrWhiteSpace(texto) ?
                    throw new Exception("A propriedade deve está prenchida")
                    : texto;
        }
    }
}
