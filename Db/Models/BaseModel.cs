using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZSPA.Db.Models
{
    public class BaseModel
    {
        [Column("ID")]
        [Key]
        public System.Guid ID { get; set; }

        [Column("IsActive")]
        public bool IsActive { get; set; }

        [Column("CreateDate")]
        public System.DateTime CreateDate { get; set; }

        [Column("CreateBy")]
        public System.String CreateBy { get; set; }

        [Column("ModifyDate")]
        public System.DateTime ModifyDate { get; set; }

        [Column("ModifyBy")]
        public System.String ModifyBy { get; set; }
    }
}