using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharePay.Entities.Data
{
    [Table("dbo.ExternalProviderLogin")]
    public class ExternalProviderLogin
    {
        [Key, Column(Order = 0)]
        [StringLength(20)]
        public string ProviderType { get; set; }

        [Key, Column(Order = 1)]
        [StringLength(100)]
        public string ProviderKey { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        #region Navigation Properties

        public User User { get; set; }

        #endregion
    }
}
