using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Data;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_HFT_2021221.Repository
{
    public class VetRepository : IVetRepository
    {
        MyDbContext context;

        public VetRepository(MyDbContext context)
        {
            this.context = context;
        }

        public void Create(Vet vet)
        {
            context.Vets.Add(vet);
            context.SaveChanges();
        }

        public Vet Read(int id)
        {
            return context
               .Vets
               .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Vet vet)
        {
            // regi objektum lekerdezese
            Vet oldVet = Read(vet.Id);

            // TODO: null check

            if (oldVet == null)
            {
                throw new ArgumentNullException();
            }

            // tulajdonsagok felulirasa

            oldVet.Name = vet.Name;
            oldVet.PhoneNumber = vet.PhoneNumber;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Vet vet = context
                .Vets
                .FirstOrDefault(x => x.Id == id);

            context.Vets.Remove(vet);
            context.SaveChanges();
        }

        public IQueryable<Vet> ReadAll()
        {
            return context.Vets;
        }

        
    }
}
