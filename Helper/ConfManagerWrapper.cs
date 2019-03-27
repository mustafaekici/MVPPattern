using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public interface IConfigurationManager
    {
        string GetAppConfigConnectionString();
    }
    public class ConfManagerWrapper : IConfigurationManager
    {
      
        public string GetAppConfigConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        }
    }
}
