﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_HFT_2021221.Data
{
    public class PetOwnerPetVetContext : DbContext
    {
        public virtual DbSet<PetOwner> PetOwner { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Vet> Vet { get; set; }

        public PetOwnerPetVetContext()
        {
            Database.EnsureCreated();
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
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity
                    .HasOne(pet => pet.Vet)
                    .WithMany(vet => vet.PetPatients)
                    .HasForeignKey(pet => pet.VetId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            PetOwner owner1 = new PetOwner() { Id = 1, Name = "Szilágyi Péter", PhoneNumber = "+36204516718" };
            PetOwner owner2 = new PetOwner() { Id = 2, Name = "Neumann Norbert", PhoneNumber = "+36301234567" };
            PetOwner owner3 = new PetOwner() { Id = 3, Name = "Triff Ádám", PhoneNumber = "+36207654321" };

            Vet vet1 = new Vet() { Id = 1, Name = "Dr. Soós Ferenc", PhoneNumber = "+36309513506" };
            Vet vet2 = new Vet() { Id = 2, Name = "Dr. Gipsz Jakab", PhoneNumber = "+36209874562" };
            Vet vet3 = new Vet() { Id = 3, Name = "Dr. Bubó", PhoneNumber = "+36998887766" };

            Pet pet1 = new Pet() { Id = 1, Name = "Fibi" , Species = "Kutya" , PetOwnerId = owner1.Id, VetId = vet1.Id };
            Pet pet2 = new Pet() { Id = 2, Name = "Max" , Species = "Kutya" , PetOwnerId = owner1.Id, VetId = vet3.Id };
            Pet pet3 = new Pet() { Id = 3, Name = "Gábor" , Species = "Macska" , PetOwnerId = owner2.Id, VetId = vet2.Id };
            Pet pet4 = new Pet() { Id = 4, Name = "Némó" , Species = "Hal" , PetOwnerId = owner3.Id, VetId = vet3.Id };
            Pet pet5 = new Pet() { Id = 5, Name = "Charlie" , Species = "Majom" , PetOwnerId = owner1.Id, VetId = vet2.Id };
            Pet pet6 = new Pet() { Id = 6, Name = "Kis Krampusz" , Species = "Kutya" , PetOwnerId = owner2.Id, VetId = vet1.Id };
            Pet pet7 = new Pet() { Id = 7, Name = "Julien Király" , Species = "Gyűrűsfarkú maki", PetOwnerId = owner1.Id, VetId = vet1.Id };

            modelBuilder.Entity<PetOwner>().HasData(owner1, owner2, owner3);
            modelBuilder.Entity<Vet>().HasData(vet1, vet2, vet3);
            modelBuilder.Entity<Pet>().HasData(pet1, pet2, pet3, pet4, pet5, pet6, pet7);

        }

    }
}
