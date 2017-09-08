using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models
{
    public partial class BasketballstatsContext : DbContext
    {
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlaysFor> PlaysFor { get; set; }
        public virtual DbSet<Stats> Stats { get; set; }
        public virtual DbSet<StatsItem> StatsItems { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\v11.0;Initial Catalog=basketballStats;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(200)");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.GuestTeamId).HasColumnName("GuestTeamID");

                entity.Property(e => e.HomeTeamId).HasColumnName("HomeTeamID");

                entity.HasOne(d => d.GuestTeam)
                    .WithMany(p => p.GameGuestTeam)
                    .HasForeignKey(d => d.GuestTeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_game_guest_team");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.GameHomeTeam)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_game_home_team");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CountyId).HasColumnName("CountyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(200)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.CountyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_player_country");
            });

            modelBuilder.Entity<PlaysFor>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.PlayerId })
                    .HasName("PK_playsFor");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlaysFor)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_playsFor_player");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PlaysFor)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_playsFor_team");
            });

            modelBuilder.Entity<Stats>(entity =>
            {
                entity.Property(e => e.StatsId).HasColumnName("StatsID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Stats)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_stats_game");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Stats)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_stats_player");
            });

            modelBuilder.Entity<StatsItem>(entity =>
            {
                entity.Property(e => e.StatsItemId).HasColumnName("StatsItemID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.StatsId).HasColumnName("StatsID");

                entity.HasOne(d => d.Stats)
                    .WithMany(p => p.StatsItem)
                    .HasForeignKey(d => d.StatsId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatsItem_Stats");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.Arena)
                    .IsRequired()
                    .HasColumnType("nchar(200)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }
    }
}