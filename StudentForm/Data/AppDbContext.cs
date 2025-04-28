using Microsoft.EntityFrameworkCore;
using StudentForm.Models;


namespace StudentForm.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Medium> Mediums { get; set; }
        public DbSet<DistrictsMasters> Districts { get; set; }
        public DbSet<TehsilsMasters> Tehsils { get; set; }
        public DbSet<Teachers> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Schools
            modelBuilder.Entity<School>().HasData(
                new School { Id = 1, Name = "Green Valley School" },
                new School { Id = 2, Name = "Riverdale Academy" },
                new School { Id = 3, Name = "Oakwood International" }
            );

            // Seed Centers
            modelBuilder.Entity<Center>().HasData(
                new Center { Id = 1, Name = "Downtown Center" },
                new Center { Id = 2, Name = "Uptown Center" },
                new Center { Id = 3, Name = "West Side Center" }
            );
        }

    }
}
