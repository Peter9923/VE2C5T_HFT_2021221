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
            if (vet == null)
            {
                throw new ArgumentNullException();
            }
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

        public IEnumerable<KeyValuePair<string, int>> WhichVetTreatsMoreThanOnePetAndHowMany()
        {
            var q = vetRepo.
                ReadAll().
                Where(x => x.PetPatients.Count() > 1).
                Select(x => new KeyValuePair<string,int>(x.Name, x.PetPatients.Count())).ToList();
            return q;
        }



    }
}
