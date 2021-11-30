using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Models;
using VE2C5T_HFT_2021221.Repository;

namespace VE2C5T_HFT_2021221.Logic
{
    public class PetLogic : IPetLogic
    {
        IPetRepository petRepo;

        public PetLogic(IPetRepository petRepository)
        {
            this.petRepo = petRepository;
        }

        //CRUD

        public void Create(Pet pet)
        {
            if (pet == null)
            {
                throw new ArgumentNullException();
            }

            this.petRepo.Create(pet);
        }

        public void Delete(int id)
        {
            this.petRepo.Delete(id);
        }

        public Pet Read(int id)
        {
            return this.petRepo.Read(id);
        }

        public IEnumerable<Pet> ReadAll()
        {
            return this.petRepo.ReadAll();
        }

        public void Update(Pet pet)
        {
            this.petRepo.Update(pet);
        }

        //NON-CRUD

        public int MostExpensivePetCost()
        {
            return petRepo.ReadAll().OrderByDescending(x => x.MonthlyCostInHUF).FirstOrDefault().MonthlyCostInHUF;
        }

        public int OldestPet()
        {
            return petRepo.ReadAll().OrderByDescending(x => x.Age).FirstOrDefault().Age;
        }




    }
}
