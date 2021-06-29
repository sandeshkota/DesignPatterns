using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.SingletonPattern
{
    public class ConfigurationManager
    {

        private readonly Dictionary<String, String> config = new();
        private static ConfigurationManager instance;
        private static object syncLock = new();

        private ConfigurationManager() {
            config.Add("database", "server/instance");
            config.Add("user", "admin");
            config.Add("password", "password");
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ConfigurationManager GetInstance()
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if(instance == null)
                        instance = new ConfigurationManager();
                }
            }
            
            return instance;
        }

        public void Upsert(string key, string value)
        {
            if(config.ContainsKey(key)) 
            {
                config[key] = value;
            } 
            else
            {
                config.Add(key, value);
            }
        }

        public string GetValue(string key)
        {
            if (config.ContainsKey(key))
            {
                return config[key];
            }

            return null;
        }

    }
}
