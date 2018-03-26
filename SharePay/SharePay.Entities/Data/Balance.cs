using SharePay.Entities.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Entities.Data
{
    [Table("dbo.Balance")]
    public class Balance : IEntity, IEntityCreateTrackable, IEntityEditTrackable
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        #region Navigation Properties

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

        public ICollection<BalanceEntry> BalanceEntries { get; set; }

        #endregion
    }
}
