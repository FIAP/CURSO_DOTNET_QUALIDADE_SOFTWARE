using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace API.Tests.Infra
{  

    public class TestConfiguration : IConfiguration
    {
        private readonly Dictionary<string, string> _configValues;

        public TestConfiguration(Dictionary<string, string> configValues)
        {
            _configValues = configValues;
        }

        public string this[string key]
        {
            get => _configValues[key];
            set => _configValues[key] = value;
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new System.NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new System.NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new System.NotImplementedException();
        }
    }

}

