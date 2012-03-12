using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carubbi.BlackJack
{
    public class RuleInfringedException : Exception
    {
        public RuleInfringedException(string message)
        {
             _message = message;
        }

        private string _message;
        public override string Message
        {
            get
            {
                return _message;
            }

        }
    }
}
