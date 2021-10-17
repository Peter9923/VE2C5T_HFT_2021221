using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<PetOwner> PetOwners { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Vet> Vets { get; set; }

        public PetOwnerPetVetContext()
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
    }
}
