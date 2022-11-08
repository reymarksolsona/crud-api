using CRUDApi.Models.Domain;
using System.Data.Entity;

namespace CRUDApi.Context
{
    public partial class CRUDDBContext : DbContext
    {
        public CRUDDBContext()
            : base("name=CRUDConnectionString")
        { }
        public virtual DbSet<Profile> Profiles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}