using Microsoft.AspNet.Identity;
using SharePay.Entities.Data.Base;
using SharePay.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharePay.Entities.Data
{
    [Table("dbo.User")]
    public class User : IEntity, IEntityDeletable, IUser<int>
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        
        [StringLength(68)]
        public string Password { get; set; }

        [Required]
        public UserTypeEnum Type { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        #region Navigation Properties
        
        public ICollection<BankCard> BankCards { get; set; }

        public ICollection<PaymentRequest> PaymentRequests { get; set; }

        public ICollection<Balance> Balances { get; set; }

        #endregion
    }
}
