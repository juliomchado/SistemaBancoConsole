using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using Principais;
using Manipulations;

namespace Manipulations
{
    class EscreverDados
    {
        public static void EscreverDadosNoArquivo(int opcao, string name, double saldo, string cpf, string senha)
        {

            using (StreamWriter sr = File.AppendText(Verificacoes.Path.ToString() + Verificacoes.Files.ToString()))
            {
                sr.WriteLine($"{name};{cpf};{saldo.ToString("F2", CultureInfo.InvariantCulture)};{senha};{DateTime.Now}");
                Verificacoes.controller = true;
            }
            Verificacoes.VerificarSeFoiSalvo(opcao,name, cpf, saldo, senha);




        }
    }
}
