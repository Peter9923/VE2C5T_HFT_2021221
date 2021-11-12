using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_HFT_2021221.Repository
{
    interface IPetOwnerRepository
    {
        void Create(PetOwner petOwner);
        PetOwner Read(int id);
        IQueryable<PetOwner> ReadAll();
        void Update(PetOwner petOwner);
        void Delete(int id);
    }
}
