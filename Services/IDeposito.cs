using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    interface IDeposito
    {
          void Deposito(string nome, string cpf, double saldo,string senha, DateTime date, double valor); 
    }
}
