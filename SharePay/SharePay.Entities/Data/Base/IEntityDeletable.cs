using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Entities.Data.Base
{
    public interface IEntityDeletable
    {
        bool IsDeleted { get; set; }
    }
}
