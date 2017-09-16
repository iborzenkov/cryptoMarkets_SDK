using System.Collections.Generic;

namespace Models
{
    public static class InfoMessages
    {
        private static readonly Dictionary<string, string> Messages = new Dictionary<string, string>()
        {
            { SuccessfullTrade, "SuccessfullTrade"},
            { SuccessfullCancelLimitOrder, "SuccessfullCancelLimitOrder"},
        };

        public static string AdoptMessage(string message)
        {
            string result;
            return Messages.TryGetValue(message, out result) ? result : message;
        }

        internal static string SuccessfullTrade => "SuccessfullTrade";
        internal static string SuccessfullCancelLimitOrder => "SuccessfullCancelLimitOrder";
        
    }
}