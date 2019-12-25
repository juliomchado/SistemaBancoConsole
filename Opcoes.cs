using System;
using System.Collections.Generic;
using System.Text;
using Manipulations;
using Principais;
using Exceptions;

namespace Principais
{
    class Opcoes
    {
        public static void PerguntaOpcao()
        {
            try
            {
                Color.YellowColor(); Console.Write("Opção: "); Color.DefaultColor();
                int opcao = int.Parse(Console.ReadLine());
                ExecOpcao(opcao);
            }
            catch (FormatException)
            {
                Color.RedColor(); Console.WriteLine("ERROR: Valor invalido!! Digite um número inteiro."); Color.DefaultColor();
                PerguntaOpcao();
            }
        }

        public static void ExecOpcao(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    MensagemOpcaoEscolhida(opcao);
                    InfoUsuario.PedirInfo(opcao);
                    break;
                case 2:
                    MensagemOpcaoEscolhida(opcao);
                    InfoUsuario.PedirInfo(opcao);
                    break;
                case 3:
                    MensagemOpcaoEscolhida(opcao);
                    InfoUsuario.PedirInfo(opcao);
                    break;
                case 4:
                    MensagemOpcaoEscolhida(opcao);
                    InfoUsuario.PedirInfo(opcao);
                    break;
                case 5:
                    MensagemOpcaoEscolhida(opcao);
                    Color.YellowColor(); Console.WriteLine("\nObrigado e volte sempre!!!"); Color.DefaultColor();
                    break;
                default:
                    Color.RedColor();  Console.Write("Não existe essa opção, digite outra: "); Color.DefaultColor();
                    PerguntaOpcao();
                    break;
            }
        }

        private static void MensagemOpcaoEscolhida(int opcao)
        {
            string msg = "Opção escolhida: ";
            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    Color.GreenColor(); Console.WriteLine(msg + "[Cadastrar]"); Color.DefaultColor();
                    Console.WriteLine();
                    break;
                case 2:
                    Console.Clear();
                    Color.GreenColor(); Console.WriteLine(msg + "[Depositar]"); Color.DefaultColor();
                    Console.WriteLine();
                    break;
                case 3:
                    Console.Clear();
                    Color.GreenColor(); Console.WriteLine(msg + "[Sacar]"); Color.DefaultColor();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Clear();
                    Color.GreenColor(); Console.WriteLine(msg + "[Mostrar Saldo]"); Color.DefaultColor();
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Clear();
                    Color.RedColor(); Console.WriteLine(msg + "[Sair]"); Color.DefaultColor();
                    Console.WriteLine();
                    break;
            }
        }

        public static void OutraOpcao()
        {
            Menu menu = new Menu();
            try
            {
                Console.WriteLine();
                Color.YellowColor(); Console.Write("Deseja escolher outra opção ? (S/N): "); Color.DefaultColor();
                char opcao = char.Parse(Console.ReadLine());

                if (opcao == 'S' || opcao == 's')
                {
                    Console.Clear();
                    Console.WriteLine(menu);
                    PerguntaOpcao();
                }
                else if(opcao == 'N' || opcao == 'n')
                {
                    Console.Clear();
                    Console.WriteLine("Obrigado, volte sempre!!"); 
                    ExecOpcao(5);
                }
                else
                {
                    Color.RedColor(); Console.WriteLine("Comando inválido, escreva S ou N"); Color.DefaultColor();
                    OutraOpcao();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
