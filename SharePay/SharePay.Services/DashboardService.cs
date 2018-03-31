using SharePay.Data.Interfaces.Repositories;

namespace SharePay.Services
{
   public class DashboardService
    {
        IBalanceRepository balanceRepository;
        IPaymentRequestRepository paymentRequestRepository;
        public DashboardService()
        {
        }
    }
}
