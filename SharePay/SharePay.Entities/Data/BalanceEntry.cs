using SharePay.Entities.Data.Base;
using SharePay.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Entities.Data
{
    [Table("dbo.BalanceEntry")]
    public class BalanceEntry : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int BalanceId { get; set; }
        
        public int? ObjectId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public BalanceEntryTypeEnum EntryType { get; set; }
        
        public DateTime CreatedDate { get; set; }

        #region Navigation Properties

        [ForeignKey("BalanceId")]
        public Balance Balance { get; set; }

        #endregion
    }
}
