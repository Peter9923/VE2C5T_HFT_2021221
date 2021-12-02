using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_HFT_2021221.Logic
{
    public interface IPetOwnerLogic
    {
        void Create(PetOwner petOwner);
        PetOwner Read(int id);
        IEnumerable<PetOwner> ReadAll();
        void Update(PetOwner petOwner);
        void Delete(int id);

        //non crud
        public IEnumerable<KeyValuePair<string, int>> WhoHasTheMostPetsAndHowMany();
    }
}
