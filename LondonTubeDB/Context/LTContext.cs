using System.Data.Entity;
using LondonTubeDB.Model;

namespace LondonTubeDB.Context
{
    public class LTContext : DbContext
    {
        public DbSet<TubeLine> TubeLines { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<UniqueStation> UniqueStations { get; set; }

        public LTContext() { }
        public LTContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //#region User
            //modelBuilder.Entity<User>()
            //    .HasRequired(m => m.Role)
            //    .WithMany()
            //    .HasForeignKey(m => m.RoleId);
        }
    }
}