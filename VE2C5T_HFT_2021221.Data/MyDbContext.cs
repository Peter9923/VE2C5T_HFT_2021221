using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_HFT_2021221.Data
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<PetOwner> PetOwners { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Vet> Vets { get; set; }

        public MyDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyDb.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>(entity =>
            {
                entity
                    .HasOne(pet => pet.PetOwner)
                    .WithMany(petownver => petownver.Pets)
                    .HasForeignKey(pet => pet.PetOwnerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(pet => pet.Vet)
                    .WithMany(vet => vet.PetPatients)
                    .HasForeignKey(pet => pet.VetId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            /*
            modelBuilder.Entity<Pet>(entity =>
            {
                entity
                    .HasOne(pet => pet.Vet)
                    .WithMany(vet => vet.PetPatients)
                    .HasForeignKey(pet => pet.VetId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            */

            PetOwner owner1 = new PetOwner() { Id = 1, Name = "Szilágyi Péter", PhoneNumber = "+36204516718", Age = 22, SalaryInHUF = 220000 };
            PetOwner owner2 = new PetOwner() { Id = 2, Name = "Neumann Norbert", PhoneNumber = "+36301234567", Age = 23, SalaryInHUF = 10000 };
            PetOwner owner3 = new PetOwner() { Id = 3, Name = "Triff Ádám", PhoneNumber = "+36207654321", Age = 22, SalaryInHUF = 20000 };

            Vet vet1 = new Vet() { Id = 1, Name = "Dr. Soós Ferenc", PhoneNumber = "+36309513506", SalaryInHUF = 300000, Age = 30 };
            Vet vet2 = new Vet() { Id = 2, Name = "Dr. Gipsz Jakab", PhoneNumber = "+36209874562", SalaryInHUF = 10, Age = 50 };
            Vet vet3 = new Vet() { Id = 3, Name = "Dr. Bubó", PhoneNumber = "+36998887766", SalaryInHUF = 10000000, Age = 999 };

            Pet pet1 = new Pet() { Id = 1, Name = "Fibi", Weight = 15, Age = 2, MonthlyCostInHUF = 10000, Species = "Kutya", PetOwnerId = owner1.Id, VetId = vet1.Id };
            Pet pet2 = new Pet() { Id = 2, Name = "Max", Weight = 20, Age = 10, MonthlyCostInHUF = 12500, Species = "Kutya", PetOwnerId = owner1.Id, VetId = vet3.Id };
            Pet pet3 = new Pet() { Id = 3, Name = "Gábor", Species = "Macska", Weight = 5, Age = 8, MonthlyCostInHUF = 3500, PetOwnerId = owner2.Id, VetId = vet2.Id };
            Pet pet4 = new Pet() { Id = 4, Name = "Némó", Species = "Hal", Weight = 0.2, Age = 1, MonthlyCostInHUF = 2000 , PetOwnerId = owner3.Id, VetId = vet3.Id };
            Pet pet5 = new Pet() { Id = 5, Name = "Charlie", Species = "Csimpánz", Weight = 50, Age = 25, MonthlyCostInHUF = 40000, PetOwnerId = owner1.Id, VetId = vet2.Id };
            Pet pet6 = new Pet() { Id = 6, Name = "Kis Krampusz", Species = "Kutya",Weight = 20, Age = 15, MonthlyCostInHUF=10000, PetOwnerId = owner2.Id, VetId = vet1.Id };
            Pet pet7 = new Pet() { Id = 7, Name = "Julien Király", Species = "Gyűrűsfarkú maki", Weight = 2.2 , Age = 18, MonthlyCostInHUF = 30000, PetOwnerId = owner1.Id, VetId = vet1.Id };

            modelBuilder.Entity<PetOwner>().HasData(owner1, owner2, owner3);
            modelBuilder.Entity<Vet>().HasData(vet1, vet2, vet3);
            modelBuilder.Entity<Pet>().HasData(pet1, pet2, pet3, pet4, pet5, pet6, pet7);

        }
    }
}
