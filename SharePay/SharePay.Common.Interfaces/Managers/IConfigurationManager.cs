using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Common.Interfaces.Managers
{
    public interface IConfigurationManager
    {
        //Links Links { get; }

        //CacheManager CacheManager { get; }

        //EncryptionManager EncryptionManager { get; }

        //MailManager MailManager { get; }

        //ReCaptcha ReCaptcha { get; }

        //ServiceFabric ServiceFabric { get; }

        TResult GetAppSetting<TResult>(string key);

        //Hashtable GetSection(string name);

        //string GetCrmCountryId(CountryCodeEnum country);
    }
}
