using System;
using System.Collections.Generic;
using System.Text;
using Services;
using Manipulations;
using System.Globalization;

namespace Services
{
    class ServicosBanco : IDeposito, ISaque
    {
        public void Deposito(string nome, string cpf, double saldo, string senha, DateTime date, double valor)
        {
            Console.Clear();
            double saldo2 = saldo + valor;
            double saldoAntigo = saldo;

            Color.YellowColor(); Console.WriteLine($"Saldo foi de: R${saldoAntigo.ToString("F2", CultureInfo.InvariantCulture)} para: R${saldo2.ToString("F2", CultureInfo.InvariantCulture)}"); Color.DefaultColor();
            
            RemoverLinha.RemoverLinhaSelecionada(nome);
            EscreverDados.EscreverDadosNoArquivo(2, nome, saldo2, cpf, senha);

        }

        public void Saque(string nome, string cpf, double saldo, string senha, DateTime date, double valor)
        {
            Console.Clear();
            double saldo2 = saldo - valor;
            double saldoAntigo = saldo;

            Color.YellowColor();  Console.WriteLine($"Saldo foi de: R${saldoAntigo.ToString("F2", CultureInfo.InvariantCulture)} para: R${saldo2.ToString("F2", CultureInfo.InvariantCulture)}"); Color.DefaultColor();
            
            RemoverLinha.RemoverLinhaSelecionada(nome);
            EscreverDados.EscreverDadosNoArquivo(2, nome, saldo2, cpf, senha);
        }
    }
}
