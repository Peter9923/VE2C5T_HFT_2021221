using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_HFT_2021221.Repository
{
    interface IVetRepository
    {
        void Create(Vet vet);
        Vet Read(int id);
        IQueryable<Vet> ReadAll();
        void Update(Vet vet);
        void Delete(int id);
    }
}
