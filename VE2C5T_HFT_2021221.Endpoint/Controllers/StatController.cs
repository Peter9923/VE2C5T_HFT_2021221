using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Logic;
using VE2C5T_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VE2C5T_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IPetLogic petLogic;
        IVetLogic vetLogic;
        IPetOwnerLogic petOwnerLogic;

        public StatController(IPetLogic petLogic, IVetLogic vetLogic, IPetOwnerLogic petOwnerLogic)
        {
            this.petLogic = petLogic;
            this.vetLogic = vetLogic;
            this.petOwnerLogic = petOwnerLogic;
        }


        [HttpGet]
        public IEnumerable<Vet> WhoHasMoreThanOnePetPatient()
        {
            return vetLogic.WhoHasMoreThanOnePetPatient();
        }

        [HttpGet]
        public IEnumerable<Vet> WhichVetTreatsTheMostExpensivePet()
        {
            return vetLogic.WhichVetTreatsTheMostExpensivePet();
        }

        [HttpGet]
        public IEnumerable<PetOwner> WhoHasMoreThanOnePet()
        {
            return petOwnerLogic.WhoHasMoreThanOnePet();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<PetOwner, Pet>> WhoHasTheMostExpensivePetAndWhichPet()
        {
            return petOwnerLogic.WhoHasTheMostExpensivePetAndWhichPet();
        }

        [HttpGet]
        public int MostExpensivePetPrice()
        {
            return petOwnerLogic.MostExpensivePetPrice();
        }

        [HttpGet]
        public IEnumerable<PetOwner> WhichPetOwnerHasAbove_AveragePet()
        {
            return petOwnerLogic.WhichPetOwnerHasAbove_AveragePet();
        }


    }
}
