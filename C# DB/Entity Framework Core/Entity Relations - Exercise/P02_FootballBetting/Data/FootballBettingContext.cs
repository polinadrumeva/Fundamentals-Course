﻿using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayersStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballBookmakerSystem;Integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(e =>
                    {
                        e.HasKey(ps => new { ps.GameId, ps.PlayerId });
                    });

            modelBuilder.Entity<Team>(e =>
                    {
                        e.HasOne(t => t.PrimaryKitColor)
                        .WithMany(c => c.PrimaryKitTeams)
                        .HasForeignKey(t => t.PrimaryKitColorId)
                        .OnDelete(DeleteBehavior.NoAction);

                        e.HasOne(t => t.SecondaryKitColor)
                        .WithMany(c => c.SecondaryKitTeams)
                        .HasForeignKey(t => t.SecondaryKitColorId)
                        .OnDelete(DeleteBehavior.NoAction);
                    });


            modelBuilder.Entity<Game>(e =>
            {
                e.HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.NoAction);

                e.HasOne(g => g.AwayTeam)
               .WithMany(t => t.AwayGames)
               .HasForeignKey(g => g.AwayTeamId)
               .OnDelete(DeleteBehavior.NoAction);
            });
        }

    }
}
