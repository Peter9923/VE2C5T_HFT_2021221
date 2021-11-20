using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_HFT_2021221.Logic
{
    interface IVetLogic
    {
        void Create(Vet vet);
        Vet Read(int id);
        IEnumerable<Vet> ReadAll();
        void Update(Vet vet);
        void Delete(int id);
    }
}
