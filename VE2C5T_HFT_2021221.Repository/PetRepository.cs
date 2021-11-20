using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Data;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_HFT_2021221.Repository
{
    public class PetRepository : IPetRepository
    {
        MyDbContext context;

        public PetRepository(MyDbContext context)
        {
            this.context = context;
        }

        public void Create(Pet pet)
        {
            context.Pets.Add(pet);
            context.SaveChanges();
        }

        public Pet Read(int id)
        {
            return context
                .Pets
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Pet pet)
        {
            // regi objektum lekerdezese
            Pet oldPet = Read(pet.Id);

            // TODO: null check

            if (oldPet == null)
            {
                throw new ArgumentNullException();
            }

            // tulajdonsagok felulirasa

            oldPet.Name = pet.Name;
            oldPet.Species = pet.Species;
            oldPet.Weight = pet.Weight;
            oldPet.Age = pet.Age;
            oldPet.MonthlyCostInHUF = pet.MonthlyCostInHUF;
            oldPet.PetOwnerId = pet.PetOwnerId;
            oldPet.VetId = pet.VetId;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Pet pet = context
                .Pets
                .FirstOrDefault(x => x.Id == id);

            context.Pets.Remove(pet);
            context.SaveChanges();
        }

        public IQueryable<Pet> ReadAll()
        {
            return context.Pets;
        }

        
    }
}
