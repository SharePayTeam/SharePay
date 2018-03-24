using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Entities.Data.Base
{
    public interface IEntityEditTrackable
    {
        DateTime? ModifiedDate { get; set; }

        int? ModifiedBy { get; set; }
    }
}
