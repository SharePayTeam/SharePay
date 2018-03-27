using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Common.Interfaces.Services
{
    public interface ICryptographicService
    {
        string GetHashValue(string source);

        string GetEncryptedValue(string source);

        string GetDecryptedValue(string source);

        string GeneratePassword(int length);
    }
}
