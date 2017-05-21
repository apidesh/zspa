using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZSPA.Db.Models
{
    [Table("Enterprise")]
    public class Enterprise : BaseModel
    {
        [Column("EnterpriseID")]
        [Required]
        [StringLength(10)]
        public string EnterpriseID { get; set; }

        [Column("EnterpriseName")]
        [Required]
        [StringLength(50)]
        public string EnterpriseName { get; set; }

        public virtual ICollection<EmailLog> EmailLogs { get; set; }
    }
}