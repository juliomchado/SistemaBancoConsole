using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    interface ISaque
    {
         void Saque(string nome, string cpf, double saldo, string senha, DateTime date, double valor);
    }
}
