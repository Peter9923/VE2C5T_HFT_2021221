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
            if (petOwner == null)
            {
                throw new ArgumentNullException();
            }

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

        public IEnumerable<KeyValuePair<string, int>> WhoHasMoreThanOnePet()
        {
            var q = petOwnerRepo.
                ReadAll().
                Where(x => x.Pets.Count() > 1).
                Select(x => new KeyValuePair<string, int>(x.Name, x.Pets.Count())).ToList();

            return q;
        }

        
        public IEnumerable<KeyValuePair<PetOwner, Pet>> WhoHasTheMostExpensivePetAndWhichPet()
        {
            return petOwnerRepo.ReadAll().
                SelectMany(x => x.Pets).
                Where(y => y.MonthlyCostInHUF == (petOwnerRepo.ReadAll().SelectMany(x=>x.Pets).OrderByDescending(x => x.MonthlyCostInHUF).FirstOrDefault().MonthlyCostInHUF) ).
                Select(r => new KeyValuePair<PetOwner, Pet>(r.PetOwner, r)).ToList();
        }
    }
}
