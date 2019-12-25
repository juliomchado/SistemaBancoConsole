using System;
using System.Collections.Generic;
using System.Text;
using Manipulations;
using System.Globalization;
using System.IO;

namespace Principais
{
    class InfoUsuario
    {
        public static void PedirInfo(int opcao)
        {
            try
            {
                switch (opcao)
                {


                    case 1:

                        Color.YellowColor(); Console.WriteLine("Digite as informações desejadas para podermos prosseguir com o Cadastro: "); Color.DefaultColor();
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("CPF: ");
                        string cpf = Console.ReadLine();
                        Console.Write("Digite uma senha: ");
                        string senha = Console.ReadLine();
                        Verificacoes.VerificarSeArquivoExiste();
                        Verificacoes.VerificarSeContaExiste(opcao, nome, cpf, senha);


                        break;
                    case 2:
                        Color.YellowColor(); Console.WriteLine("Digite suas informações para podermos prosseguir com o Deposito: "); Color.DefaultColor();
                        Console.Write("Nome: ");
                        nome = Console.ReadLine();
                        Console.Write("Digite o CPF da conta: ");
                        cpf = Console.ReadLine();
                        Console.Write("Digite a senha da conta: ");
                        senha = Console.ReadLine();
                        Verificacoes.VerificarSeArquivoExiste();
                        Verificacoes.VerificarSeContaExiste(opcao, nome, cpf, senha);
                        break;
                    case 3:
                        Color.YellowColor(); Console.WriteLine("Digite suas informações para podermos prosseguir com o Saque: "); Color.DefaultColor();
                        Console.Write("Nome: ");
                        nome = Console.ReadLine();
                        Console.Write("Digite o CPF da conta: ");
                        cpf = Console.ReadLine();
                        Console.Write("Digite a senha da conta: ");
                        senha = Console.ReadLine();
                        Verificacoes.VerificarSeArquivoExiste();
                        Verificacoes.VerificarSeContaExiste(opcao, nome, cpf, senha);
                        break;
                    case 4:
                        Color.YellowColor(); Console.WriteLine("Digite suas informações para podermos mostrar seu Saldo: "); Color.DefaultColor();
                        Console.Write("Nome: ");
                        nome = Console.ReadLine();
                        Console.Write("Digite o CPF da conta: ");
                        cpf = Console.ReadLine();
                        Console.Write("Digite a senha da conta: ");
                        senha = Console.ReadLine();
                        Verificacoes.VerificarSeArquivoExiste();
                        Verificacoes.VerificarSeContaExiste(opcao, nome, cpf, senha);
                        break;

                }
            }
            catch (Exception e)
            {
                Color.RedColor(); Console.WriteLine("Desculpa pelo transtorno, aconteceu um erro desconhecidos e nós ja fomos avisados, por favor, volte mais tarde"); Color.DefaultColor();

                using (StreamWriter sw = File.CreateText(@"C:\Bank\ErrorMethodPedirInfo.txt"))
                {
                    using (StreamWriter sw2 = File.AppendText(@"C:\Bank\ErrorMethodPedirInfo.txt"))
                        sw.WriteLine(e.Message);
                }

            }
        }
    }
}

