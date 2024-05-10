using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDYDLS_CineClubDAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DDYDLS_CineClubDAL.Repository
{
    public class CineclubContext : DbContext
    {
            public DbSet<Cineclub> T_Cineclub { get; set; }
            public DbSet<Movie> T_Movie { get; set; }
            public DbSet<CineclubMovie> CineclubMovies { get; set; }
            public DbSet<Ratings> T_Rating { get; set; }
            public DbSet<User> T_User { get; set; }

            private readonly IConfiguration _configuration;

            public CineclubContext(IConfiguration configuration)
            {
                _configuration = configuration;
            }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {

                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
                    //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Data Source=localhost;Initial Catalog=CodeFirstTest;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));
                }
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Configuration des clés primaires composées pour CineclubMovie
                modelBuilder.Entity<CineclubMovie>()
                    .HasKey(cm => new { cm.CineclubId, cm.MovieId });
                modelBuilder.Entity<Cineclub>()
                    .HasKey(c => c.Id_Cineclub);
                modelBuilder.Entity<Movie>()
                    .HasKey(m => m.Id_Movie);
                modelBuilder.Entity<Ratings>()
                    .HasKey(r => r.Id_Rating);
                modelBuilder.Entity<User>()
                    .HasKey(u => u.ID_User);
            // Configuration des relations
                modelBuilder.Entity<Cineclub>()
                        .HasMany(c => c.CineclubMovies)
                        .WithOne(cm => cm.Cineclub)
                        .HasForeignKey(cm => cm.CineclubId);

                modelBuilder.Entity<Movie>()
                .HasOne(m => m.Rating)
                .WithOne(r => r.Movie)
                .HasForeignKey<Ratings>(r => r.Id_Movie);
        }

    }
}
