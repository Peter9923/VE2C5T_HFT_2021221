using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Data;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_HFT_2021221.Repository
{
    class PetOwnerRepository : IPetOwnerRepository
    {
        MyDbContext context;

        public PetOwnerRepository(MyDbContext context)
        {
            this.context = context;
        }

        public void Create(PetOwner petOwner)
        {
            context.PetOwners.Add(petOwner);
            context.SaveChanges();
        }

        public PetOwner Read(int id)
        {
            return context
                .PetOwners
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(PetOwner petOwner)
        {
            // regi objektum lekerdezese
            PetOwner oldPetOwner = Read(petOwner.Id);

            // TODO: null check

            if (oldPetOwner == null)
            {
                throw new ArgumentNullException();
            }

            // tulajdonsagok felulirasa

            oldPetOwner.Name = petOwner.Name;
            oldPetOwner.PhoneNumber = petOwner.PhoneNumber;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            PetOwner petOwner = context
                .PetOwners
                .FirstOrDefault(x => x.Id == id);

            context.PetOwners.Remove(petOwner);
            context.SaveChanges();
        }

        public IQueryable<PetOwner> ReadAll()
        {
            return context.PetOwners;
        }

        
    }
}
