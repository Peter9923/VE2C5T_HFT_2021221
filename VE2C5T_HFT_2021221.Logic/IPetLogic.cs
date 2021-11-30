using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_HFT_2021221.Logic
{
    public interface IPetLogic
    {
        void Create(Pet pet);
        Pet Read(int id);
        IEnumerable<Pet> ReadAll();
        void Update(Pet pet);
        void Delete(int id);


        public int MostExpensivePetCost();
        public int OldestPet();
    }
}
