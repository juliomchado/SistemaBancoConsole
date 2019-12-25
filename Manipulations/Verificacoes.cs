using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Principais;
using Services;
using System.Globalization;

namespace Manipulations
{
    class Verificacoes
    {
        public static string Path = @"C:\Bank\", Files = @"Dados.txt";
        public static bool controller;
        public static int controlerVerifyAcc;
        public static int controlerVerifyEx;
        public static bool controlerOutraOpcao;
        public static bool controlerProcSaldo;
        public static bool controlerVerifyBalance;

        private static DateTime Data;
        private static double Saldo;
        private static string Nome;
        public static void VerificarSeArquivoExiste()
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
                using (StreamWriter sr = File.CreateText(Path + Files))
                {

                }
            }

        }

        public static void VerificarSeContaExiste(int opcao, string name, string cpf, string senha)
        {

            switch (opcao)
            {
                case 1:

                    using (StreamReader sr = File.OpenText(Path + Files))
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] text = sr.ReadLine().Split(';');
                            if (text[0] != null)
                            {

                                if (text[0].ToLower() == name.ToLower() || text[1] == cpf)
                                {
                                    Color.RedColor(); Console.WriteLine("Desculpe, sua conta já existe"); Color.DefaultColor();
                                    controlerOutraOpcao = true;
                                    break;
                                }
                                else if (sr.EndOfStream)
                                {
                                    controlerVerifyEx = 1;
                                    break;
                                }

                            }
                            else
                            {
                                controlerVerifyEx = 1;
                                break;
                            }


                        }
                    }

                    if (controlerVerifyEx == 1 || controlerOutraOpcao == false)
                        EscreverDados.EscreverDadosNoArquivo(opcao, name, 0, cpf, senha);
                    else if (controlerOutraOpcao == true)
                        Opcoes.OutraOpcao();

                    break;
                case 2:
                    using (StreamReader sr = File.OpenText(Path + Files))
                    {


                        while (!sr.EndOfStream)
                        {
                            controller = true;
                            string[] text = sr.ReadLine().Split(';');
                            if (text[1] == cpf && text[3] == senha)
                            {
                                Nome = text[0];
                                Data = DateTime.Parse(text[4]);
                                Saldo = double.Parse(text[2], CultureInfo.InvariantCulture);
                                controlerVerifyAcc = 1;
                                break;
                            }
                            else if (text[1] == cpf && text[3] != senha)
                                controlerVerifyAcc = 2;
                            else if (sr.EndOfStream)
                                controlerVerifyAcc = 3;

                        }
                    }

                    if (controlerVerifyAcc == 1)
                    {
                        try
                        {
                            ServicosBanco ServicoBanco = new ServicosBanco();
                            Console.WriteLine();
                            Color.GreenColor(); Console.WriteLine("Seu ultimo acesso foi: " + Data); Color.DefaultColor();
                            Console.WriteLine();
                            Console.Write("Digite quantos você quer depositar: R$");
                            double deposito = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            VerificarSeuSaldoEDepositaOuSaca(opcao, name, cpf, Saldo, senha, Data, deposito);
                        }
                        catch (FormatException)
                        {
                            Color.RedColor(); Console.WriteLine("ERROR: Formato errado, por favor escreva novamente o valor que deseja depositar: "); Color.DefaultColor();
                            Console.Write("Valor desejado: ");
                            double deposito2 = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            VerificarSeuSaldoEDepositaOuSaca(opcao, name, cpf, Saldo, senha, Data, deposito2);
                        }
                    }
                    else if (controlerVerifyAcc == 2)
                    {
                        Color.RedColor(); Console.Write("Senha Errada! Digite novamente: "); Color.DefaultColor();
                        string senha2 = Console.ReadLine();
                        VerificarSeContaExiste(opcao, name, cpf, senha2);
                    }
                    else if (controlerVerifyAcc == 3)
                        DesejaVerificarNovamente(opcao);

                    break;

                case 3:
                    using (StreamReader sr = File.OpenText(Path + Files))
                    {


                        while (!sr.EndOfStream)
                        {
                            controller = true;
                            string[] text = sr.ReadLine().Split(';');
                            if (text[1] == cpf && text[3] == senha)
                            {
                                Nome = text[0];
                                Data = DateTime.Parse(text[4]);
                                Saldo = double.Parse(text[2], CultureInfo.InvariantCulture);
                                controlerVerifyAcc = 1;
                                break;
                            }
                            else if (text[1] == cpf && text[3] != senha)
                                controlerVerifyAcc = 2;
                            else if (sr.EndOfStream)
                                controlerVerifyAcc = 3;

                        }
                    }

                    if (controlerVerifyAcc == 1)
                    {
                        try
                        {
                            Console.WriteLine();
                            Color.GreenColor(); Console.WriteLine("Seu ultimo acesso foi: " + Data); Color.DefaultColor();
                            Console.WriteLine();
                            Console.Write("Digite quantos você quer sacar: R$");
                            double saque = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            VerificarSeuSaldoEDepositaOuSaca(opcao, name, cpf, Saldo, senha, Data, saque);
                        }
                        catch (FormatException)
                        {
                            Color.RedColor(); Console.WriteLine("ERROR: Formato errado, por favor escreva novamente o valor que quer depositar: "); Color.DefaultColor();
                            Console.Write("Valor desejado: ");
                            double deposito2 = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            VerificarSeuSaldoEDepositaOuSaca(opcao, name, cpf, Saldo, senha, Data, deposito2);
                        }
                    }
                    else if (controlerVerifyAcc == 2)
                    {
                        Color.RedColor(); Console.Write("Senha Errada! Digite novamente: "); Color.DefaultColor();
                        string senha2 = Console.ReadLine();
                        VerificarSeContaExiste(opcao, name, cpf, senha2);
                    }
                    else if (controlerVerifyAcc == 3)
                    {
                        DesejaVerificarNovamente(opcao);
                        break;
                    }
                    break;
                case 4:
                    using (StreamReader sr = File.OpenText(Path + Files))
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] text = sr.ReadLine().Split(';');
                            if (text[1] == cpf && text[3] == senha)
                            {
                                MostrarSaldo.Saldo(text[0], double.Parse(text[2], CultureInfo.InvariantCulture));
                                controlerProcSaldo = false;
                                break;
                            }
                            else if (sr.EndOfStream)
                            {
                                controlerProcSaldo = true;
                            }


                        }
                    }

                    if (controlerProcSaldo != false)
                    {
                        Color.RedColor(); Console.WriteLine($"Essa conta não existe !!"); Color.DefaultColor();
                        Opcoes.OutraOpcao();
                    }
                    else
                        Opcoes.OutraOpcao();

                    break;
            }
        }

        public static void VerificarSeFoiSalvo(int opcao, string name, string cpf, double saldo, string senha)
        {
            if (controller == true)
            {
                using (StreamReader sr = File.OpenText(Path + Files))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] text = sr.ReadLine().Split(';');
                        if (text[0].ToLower() == name.ToLower() || text[1] == cpf || text[3] == senha)
                        {
                            Console.Clear();
                            Color.GreenColor(); Console.WriteLine($"Sua conta foi salva com sucesso!!! Nome: {name}, cpf: {cpf}"); Color.DefaultColor();
                            controlerOutraOpcao = true;
                            break;
                        }
                        else if (!sr.EndOfStream && text[0] == null)
                            continue;
                        else if (sr.EndOfStream && text[0] == null)
                        {
                            Console.WriteLine();
                            Color.RedColor(); Console.WriteLine($"Desculpe, aconteceu algum erro e sua conta não foi cadastrada "); Color.RedColor();
                            controlerOutraOpcao = true;
                            break;
                        }
                    }
                }

                if (controlerOutraOpcao != false)
                    Opcoes.OutraOpcao();
            }
        }


        public static void DesejaVerificarNovamente(int opcao)
        {
            Menu menu = new Menu();
            try
            {
                Color.RedColor(); Console.Write("Essa conta não existe, deseja tentar novamente? (S/N):   "); Color.DefaultColor();
                char resp = char.Parse(Console.ReadLine());

                if (resp == 'S' || resp == 's')
                {
                    Opcoes.ExecOpcao(opcao);
                }
                else if (resp == 'N' || resp == 'n')
                {
                    Console.Clear();
                    Console.WriteLine("Obrigado, volte sempre!!");
                    Opcoes.ExecOpcao(5);
                }
                else
                {
                    Color.RedColor(); Console.WriteLine("Comando inválido, escreva S ou N"); Color.DefaultColor();
                    DesejaVerificarNovamente(opcao);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public static void VerificarSeuSaldoEDepositaOuSaca(int opcao, string name, string cpf, double saldo, string senha, DateTime data, double quantia)
        {
            ServicosBanco ServicoBanco = new ServicosBanco();
            int quantia2;
            switch (opcao)
            {

                case 2:

                    if (quantia <= 0)
                    {
                        Color.RedColor(); Console.WriteLine("O Não é permitido deposito de valores menores ou iguais a 0. "); Color.DefaultColor();
                        Console.Write("Digite outro valor: ");
                        quantia2 = int.Parse(Console.ReadLine());
                        VerificarSeuSaldoEDepositaOuSaca(opcao, name, cpf, saldo, senha, data, quantia2);
                    }
                    else
                        ServicoBanco.Deposito(name, cpf, saldo, senha, data, quantia);

                    break;
                case 3:

                    if (quantia <= 0)
                    {
                        Color.RedColor(); Console.WriteLine("O Não é permitido deposito de valores menores ou iguais a 0. "); Color.DefaultColor();
                        Console.Write("Digite outro valor: ");
                        quantia2 = int.Parse(Console.ReadLine());
                        VerificarSeuSaldoEDepositaOuSaca(opcao, name, cpf, saldo, senha, data, quantia2);

                    }
                    else if (quantia > saldo)
                    {
                        Color.RedColor(); Console.WriteLine($"O Não é permitido saque de valores maior que o seu saldo, seu saldo é de: {saldo}"); Color.DefaultColor();
                        Console.Write("Digite outro valor: ");
                        quantia2 = int.Parse(Console.ReadLine());
                        VerificarSeuSaldoEDepositaOuSaca(opcao, name, cpf, saldo, senha, data, quantia2);
                        break;

                    }
                    else
                    {
                        ServicoBanco.Saque(name, cpf, saldo, senha, data, quantia);
                    }
                    break;
            }


        }
    }
}

