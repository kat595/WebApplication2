using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Entities
{
    public class TiproomDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=TiproomDb;Trusted_Connection=True;";

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Footballer_stat> Footballer_stats { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<League_score> League_scores { get; set; }
        public DbSet<League_founder> League_founders { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<Odd> Odds { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Club>()
                .Property(r => r.Nameclub)
                .IsRequired()
                .HasMaxLength(50);

            modelbuilder.Entity<Footballer>()
                .Property(d => d.Name)
                .IsRequired();

            modelbuilder.Entity<League>()
                .Property(x => x.League_name)
                .IsRequired()
                .HasMaxLength(50);

            modelbuilder.Entity<Match>()
                .Property(y => y.Gameweek)
                .IsRequired();

            modelbuilder.Entity<User>()
                .Property(c => c.Nick)
                .IsRequired()
                .HasMaxLength(20);
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
