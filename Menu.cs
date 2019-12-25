using System;
using System.Collections.Generic;
using System.Text;

namespace Principais
{
    class Menu
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" ________________________");
            sb.AppendLine("|                        |");
            sb.AppendLine("|    ESCOLHA A OPÇÃO:    |");
            sb.AppendLine("|________________________|");
            sb.AppendLine("|                        |");
            sb.AppendLine("| 1. Cadastrar           |");
            sb.AppendLine("| 2. Depositar           |");
            sb.AppendLine("| 3. Sacar               |");
            sb.AppendLine("| 4. Mostrar Saldo       |");
            sb.AppendLine("| 5. Sair                |");
            sb.AppendLine("|________________________|");

            return sb.ToString();
        }
    }
}
