using System;

namespace CryptoSdk.Features
{
    public class Currency : IEquatable<Currency>
    {
        public Currency(string name)
        {
            Name = name;
        }

        public Currency(string name, string longName) : this(name)
        {
            LongName = longName;
        }

        public string Name { get; }
        public string LongName { get; }
        public double TxFee { get; set; }
        public bool IsActive { get; set; }
        public string BaseAddress { get; set; }

        public bool Equals(Currency other)
        {
            return other != null && string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return LongName;
        }
    }
}