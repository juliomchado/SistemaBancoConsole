using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    class BankException : Exception
    {
        public BankException(string messege) : base(messege)
        {
        }
    }
}
