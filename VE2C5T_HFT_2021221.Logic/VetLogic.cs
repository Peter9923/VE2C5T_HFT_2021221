using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Models;
using VE2C5T_HFT_2021221.Repository;

namespace VE2C5T_HFT_2021221.Logic
{
    public class VetLogic : IVetLogic
    {
        IVetRepository vetRepo;

        public VetLogic(IVetRepository vetRepository)
        {
            this.vetRepo = vetRepository;
        }

        //CRUD

        public void Create(Vet vet)
        {
            this.vetRepo.Create(vet);
        }

        public void Delete(int id)
        {
            this.vetRepo.Delete(id);
        }

        public Vet Read(int id)
        {
            return this.vetRepo.Read(id);
        }

        public IEnumerable<Vet> ReadAll()
        {
            return this.vetRepo.ReadAll();
        }

        public void Update(Vet vet)
        {
            this.vetRepo.Update(vet);
        }

        //NON-CRUD

        public IEnumerable<Vet> WhoHasMoreThanOnePetPatient()
        {
            var q = vetRepo.
                ReadAll().
                Where(x => x.PetPatients.Count() > 1).
                Select(x => x).ToList();
            return q;
        }

        public IEnumerable<Vet> WhichVetTreatsTheMostExpensivePet()
        {
            var q = vetRepo.ReadAll().
                SelectMany(x => x.PetPatients).
                OrderByDescending(x => x.MonthlyCostInHUF).
                Take(1).
                Select(x => x.Vet).ToList();
            return q;
        }

    }
}
