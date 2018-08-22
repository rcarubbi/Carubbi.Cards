using System;

namespace Carubbi.BlackJack
{
    public class RuleInfringedException : Exception
    {
        public RuleInfringedException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}