using System.Collections.Generic;

namespace DomainModel.Strategies
{
    public class StrategySettings
    {
        private readonly Dictionary<string, object> _settings = new Dictionary<string, object>();

        public void Add(string name, object value)
        {
            _settings.Add(name, value);
        }

        public object Get(string name)
        {
            object result;
            return _settings.TryGetValue(name, out result) ? result : null;
        }
    }
}