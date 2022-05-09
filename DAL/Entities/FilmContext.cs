//using System;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL.Entities
{
    public partial class FilmContext : IdentityDbContext<Viewer>
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        { }
        public FilmContext()
        {}
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Hall> Hall { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //подключение к базе данных
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Kinoteatr6;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Timing).IsRequired();
                entity.HasOne(d => d.Genre)
                .WithMany(p => p.Film)
                .HasForeignKey(d => d.GenreId);
                entity.HasOne(d => d.Country)
                .WithMany(p => p.Film)
                .HasForeignKey(d => d.CountryId);
            });
            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.FilmId).IsRequired();
                entity.Property(e => e.Time).IsRequired();
                entity.HasOne(d => d.Film)
                .WithMany(p => p.Session)
                .HasForeignKey(d => d.FilmId);
                entity.HasOne(d => d.Hall)
                .WithMany(p => p.Session)
                .HasForeignKey(d => d.HallId);
            });
            modelBuilder.Entity<Hall>(entity =>
            {
                entity.Property(e => e.Number).IsRequired();
            });
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Row).IsRequired();
                entity.Property(e => e.Place).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.HasOne(d => d.Session)
                .WithMany(p => p.Ticket)
                .HasForeignKey(d => d.SessionId);
            });
        }
    }
}
