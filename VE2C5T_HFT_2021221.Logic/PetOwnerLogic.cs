using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Models;
using VE2C5T_HFT_2021221.Repository;

namespace VE2C5T_HFT_2021221.Logic
{
    public class PetOwnerLogic : IPetOwnerLogic
    {
        IPetOwnerRepository petOwnerRepo;

        public PetOwnerLogic(IPetOwnerRepository petOwnerRepository)
        {
            this.petOwnerRepo = petOwnerRepository;
        }

        //CRUD

        public void Create(PetOwner petOwner)
        {
            this.petOwnerRepo.Create(petOwner);
        }

        public void Delete(int id)
        {
            this.petOwnerRepo.Delete(id);
        }

        public PetOwner Read(int id)
        {
            return this.petOwnerRepo.Read(id);
        }

        public IEnumerable<PetOwner> ReadAll()
        {
            return this.petOwnerRepo.ReadAll();
        }

        public void Update(PetOwner petOwner)
        {
            this.petOwnerRepo.Update(petOwner);
        }

        //NON-CRUD

        public IEnumerable<PetOwner> WhoHasMoreThanOnePet()
        {
            var q = petOwnerRepo.
                ReadAll().
                Where(x => x.Pets.Count() > 1).
                Select(x => x).ToList();
            return q;
        }

        
        public IEnumerable<KeyValuePair<PetOwner, Pet>> WhoHasTheMostExpensivePetAndWhichPet()
        {
            return petOwnerRepo.ReadAll().
                SelectMany(x => x.Pets).
                Where(y => y.MonthlyCostInHUF == this.MostExpensivePetPrice()).
                Select(r => new KeyValuePair<PetOwner, Pet>(r.PetOwner, r)).ToList();
        }

        public int MostExpensivePetPrice()
        {
            var q = ((int)petOwnerRepo.ReadAll().SelectMany(x => x.Pets).OrderByDescending(x => x.MonthlyCostInHUF).Take(1).Select(x =>  (int)x.MonthlyCostInHUF).Average());
            return q;
        }

        public IEnumerable<PetOwner> WhichPetOwnerHasAbove_AveragePet()
        { 
            var average = petOwnerRepo.ReadAll().SelectMany(x => x.Pets).Average(x => x.Weight);
            var q = petOwnerRepo.ReadAll().SelectMany(x => x.Pets).Where(x => x.Weight >= average).Select(o => o.PetOwner).Distinct().ToList();
            return q;
        }


    }
}
