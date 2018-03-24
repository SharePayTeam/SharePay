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
    [Table("dbo.PaymentEntry")]
    public class PaymentEntry : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int PaymentRequestId { get; set; }

        [Required]
        [StringLength(500)]
        public string Comment { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        #region Navigation Properties

        [ForeignKey("PaymentRequestId")]
        public PaymentRequest PaymentRequest { get; set; }

        #endregion
    }
}
