﻿namespace CarDealer.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class CarDealerContext : DbContext
    {
        public CarDealerContext(DbContextOptions options)
            : base(options)
        {
        }

        public CarDealerContext()
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartCar> PartCars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-OSIHADJ\SQLEXPRESS;Database=CarDealer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartCar>(e =>
            {
                e.HasKey(k => new { k.CarId, k.PartId });
            });

            modelBuilder.Entity<Part>(e =>
            {
                e.HasMany(p => p.PartCars)
                .WithOne(pc => pc.Part)
                .HasForeignKey(p => p.PartId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Car>(e =>
            {
                e.HasMany(c => c.PartCars)
                .WithOne(pc => pc.Car)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Part>(e =>
            {
                e.HasOne(p => p.Supplier)
                .WithMany(s => s.Parts)
                .HasForeignKey(p => p.SupplierId);
            });

            
        }
    }
}
