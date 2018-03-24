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
    [Table("dbo.BankCard")]
    public class BankCard : IEntity, IEntityCreateTrackable, IEntityEditTrackable, IEntityDeletable
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        [StringLength(4)]
        public string SecretCode { get; set; }

        [Required]
        [Range(1, 12)]
        public int ExpirationMonth { get; set; }

        [Required]
        public int ExpirationYear { get; set; }

        [Required]
        public CardTypeEnum CardType { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        #region Navigation Properties

        [ForeignKey("UserId")]
        public User User { get; set; }

        #endregion
    }
}
