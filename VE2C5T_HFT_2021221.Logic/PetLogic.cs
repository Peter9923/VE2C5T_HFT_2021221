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
            if (pet == null || pet.Name == "" || pet.Species == "")
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

        public double FattestPet()
        {
            return petRepo.ReadAll().OrderByDescending(x => x.Weight).FirstOrDefault().Weight;
        }

        public IEnumerable<KeyValuePair<Pet, PetOwner>> MostExperiencePetAndHisOwner()
        {
            return petRepo.ReadAll().
                Where(p => p.MonthlyCostInHUF == this.MostExpensivePetCost()).
                Select(p => new KeyValuePair<Pet,PetOwner>(p, p.PetOwner)).ToList();
        }

        public IEnumerable<KeyValuePair<string, int>> GrupPetsBySpeciesAndTheirAVGage()
        {
            return petRepo.ReadAll()
                .GroupBy(p => p.Species)
                .Select(p => new KeyValuePair<string,int>(p.Key, (int)p.Average(p => p.Age))).ToList();
        }

        public IEnumerable<KeyValuePair<string, int>> GrupPetsBySpeciesAndTheirAVGcost()
        {
            return petRepo.ReadAll()
                 .GroupBy(p => p.Species)
                 .Select(p => new KeyValuePair<string, int>(p.Key, (int)p.Average(p => p.MonthlyCostInHUF))).ToList();
        }

        public IEnumerable<KeyValuePair<string, int>> GrupPetsBySpeciesAndTheirAVGweight()
        {
            return petRepo.ReadAll()
                 .GroupBy(p => p.Species)
                 .Select(p => new KeyValuePair<string, int>(p.Key, (int)p.Average(p => p.Weight))).ToList();
        }

        public IEnumerable<KeyValuePair<Vet, Pet>> WhichVetHasTheMostFattestPet()
        {
            return petRepo.ReadAll().
                Where(p => p.Weight == this.FattestPet()).
                Select(p => new KeyValuePair<Vet, Pet>(p.Vet, p)).ToList();
        }
    }
}
