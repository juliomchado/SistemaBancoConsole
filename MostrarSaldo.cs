using System;
using System.Collections.Generic;
using System.Text;
using Manipulations;

namespace Principais
{
    class MostrarSaldo
    {
        public static void Saldo(string nome, double saldo)
        {
            Console.Clear();
            Color.GreenColor(); Console.WriteLine($"{nome}, O seu saldo é de R${saldo.ToString("F2")}"); Color.RedColor();
        }
    }
}
