using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ZSPA.Db.Models;

namespace ZSPA.Db
{
    public class ZSPADbContext : DbContext
    {
        public ZSPADbContext([NotNullAttribute]DbContextOptions options) : base(options)
        {
        }

        protected ZSPADbContext()
        {
        }

        public virtual DbSet<Enterprise> Enterprises { get; set; }
        public virtual DbSet<EmailLog> EmailLogs { get; set; }
    }
}