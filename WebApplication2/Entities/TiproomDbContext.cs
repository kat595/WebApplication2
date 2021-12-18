using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Entities
{
    public class TiproomDbContext : DbContext
    {
        private string _connectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=TiproomDb;Trusted_Connection=True;";

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
            

            modelbuilder.Entity<League_founder>().HasKey(sc => new { sc.LeagueId, sc.FounderId });

            modelbuilder.Entity<League_score>().HasKey(sd => new { sd.LeagueId, sd.UserId });

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

            modelbuilder.Entity<Match>()
                .HasOne(z => z.Home)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Match>()
                .HasOne(z => z.Away)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Tip>()
                .HasOne(a => a.Tip_goal_forward)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Tip>()
                .HasOne(a => a.Tip_goal_midfielder)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Tip>()
                .HasOne(a => a.Tip_goal_defender)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

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
