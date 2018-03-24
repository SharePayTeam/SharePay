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
    [Table("dbo.PaymentRequest")]
    public class PaymentRequest : IEntity, IEntityCreateTrackable, IEntityEditTrackable, IEntityDeletable
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public int CurrencyId { get; set; }

        public bool IsRecurringPayment { get; set; }

        public bool IsClosed { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        #region Navigation Properties

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

        public ICollection<PaymentEntry> PaymentEntrys { get; set; }

        #endregion
    }
}
