using System;
using Principais;


namespace Principais
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            

            Console.WriteLine(menu);
            Opcoes.PerguntaOpcao();
           
        }
    }
}
