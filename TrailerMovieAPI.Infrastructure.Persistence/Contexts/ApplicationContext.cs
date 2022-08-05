using TrailerMovieAPI.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Domain.Entities;

namespace TrailerMovieAPI.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.Now;
                        entry.Entity.ModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }



        protected override void OnModelCreating(ModelBuilder builder) {
            //Fluent API

            builder.HasDefaultSchema("TrailerMovieAPI");
            #region Tables

            builder.Entity<Movie>().ToTable("Movies");

            builder.Entity<Actor>().ToTable("Actors");

            builder.Entity<Director>().ToTable("Directors");

            builder.Entity<MovieCategory>().ToTable("Category");

            builder.Entity<MovieDirector>().ToTable("Movie_Director");

            builder.Entity<MovieActor>().ToTable("Movie_Actor");

            #endregion

            #region Primary Key

            builder.Entity<Movie>().HasKey(x => x.Id);
            builder.Entity<Actor>().HasKey(x => x.Id);
            builder.Entity<Director>().HasKey(x => x.Id);
            builder.Entity<MovieCategory>().HasKey(x => x.Id);
            builder.Entity<MovieDirector>().HasKey(x => x.Id);
            builder.Entity<MovieActor>().HasKey(x => x.Id);

            #endregion

            #region RelationShips

            builder.Entity<MovieCategory>()
                .HasMany(x => x.Movies)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            builder.Entity<MovieActor>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Actors)
                .HasForeignKey(x => x.MovieId);

            builder.Entity<MovieActor>()
                .HasOne(x => x.Actor)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.ActorId);

            builder.Entity<MovieDirector>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Directors)
                .HasForeignKey(x => x.MovieId);

            builder.Entity<MovieDirector>()
                .HasOne(x => x.Director)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.DirectorId);

            #endregion

            #region Properties

            #region Movies

            builder.Entity<Movie>()
                .Property(x => x.Image)
                .IsRequired();

            builder.Entity<Movie>()
                .Property(x => x.Title)
                .IsRequired();

            builder.Entity<Movie>()
                .Property(x => x.LaunchedDate)
                .IsRequired();

            builder.Entity<Movie>()
                .Property(x => x.Description)
                .IsRequired();

            builder.Entity<Movie>()
                .Property(x => x.YoutubeVideoURL)
                .IsRequired();

            builder.Entity<Movie>()
                .Property(x => x.CategoryId)
                .IsRequired();

            #endregion
            
            #region Actor

            builder.Entity<Actor>()
                .Property(x => x.Name)
                .IsRequired();

            builder.Entity<Actor>()
                .Property(x => x.LastName)
                .IsRequired();

            builder.Entity<Actor>()
                .Property(x => x.BirthDate)
                .IsRequired();

            builder.Entity<Actor>()
                .Property(x => x.ImageUrl)
                .IsRequired();

            #endregion
            
            #region Director

            builder.Entity<Director>()
                .Property(x => x.Name)
                .IsRequired();

            builder.Entity<Director>()
                .Property(x => x.LastName)
                .IsRequired();

            builder.Entity<Director>()
                .Property(x => x.BirthDate)
                .IsRequired();

            builder.Entity<Director>()
                .Property(x => x.ImageUrl)
                .IsRequired();

            #endregion

            #endregion

        }
    }
}
