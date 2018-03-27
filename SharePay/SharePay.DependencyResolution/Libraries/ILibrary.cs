using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.DependencyResolution.Libraries
{
    public interface ILibrary
    {
        bool IsEnabled { get; }

        void Initialize();
    }
}
