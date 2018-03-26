using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Entities.Enums
{
    public enum PaymentStatusEnum
    {
        InProcessing = 0,
        TransactionFailed = 1,
        TransactionCanceled = 2,
        TransactionSuccessful = 3,
    }
}
