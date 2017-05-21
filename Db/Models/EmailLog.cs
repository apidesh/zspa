using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZSPA.Db.Models
{
    [Table("EmailLog")]
    public class EmailLog : BaseModel
    {
        [Column("EnterpriseFK")]
        [ForeignKey("Enterprise")]
        public Guid EnterpriseFK { get; set; }

        public virtual Enterprise Enterprise { get; set; }

        [Column("Subject")]
        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        [Column("FromEmail")]
        [Required]
        [StringLength(250)]
        public string FromEmail { get; set; }

        [Column("ToEmail")]
        [Required]
        public string ToEmail { get; set; }

        [Column("CcEmail")]
        public string CcEmail { get; set; }

        [Column("BccEmail")]
        public string BccEmail { get; set; }

        [Column("FileAttachment")]
        public string FileAttachment { get; set; }

        [Column("SendStatus")]
        public bool SendStatus { get; set; }

        [Column("ExceptionText")]
        public string ExceptionText { get; set; }
    }
}