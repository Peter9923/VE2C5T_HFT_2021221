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
        public IEnumerable<KeyValuePair<Pet, PetOwner>> MostExperiencePetAndHisOwner()
        {
            return petLogic.MostExperiencePetAndHisOwner();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GrupPetsBySpeciesAndTheirAVGage()
        {
            return petLogic.GrupPetsBySpeciesAndTheirAVGage();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GrupPetsBySpeciesAndTheirAVGcost()
        {
            return petLogic.GrupPetsBySpeciesAndTheirAVGcost();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GrupPetsBySpeciesAndTheirAVGweight()
        {
            return petLogic.GrupPetsBySpeciesAndTheirAVGweight();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<Vet, Pet>> WhichVetHasTheMostFattestPet()
        {
            return petLogic.WhichVetHasTheMostFattestPet();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> WhichVetTreatsMoreThanOnePetAndHowMany()
        {
            return vetLogic.WhichVetTreatsMoreThanOnePetAndHowMany();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> WhoHasTheMostPetsAndHowMany()
        {
            return petOwnerLogic.WhoHasTheMostPetsAndHowMany();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> WhoSpendsTheMostOnAnimalsHowMany()
        {
            return petOwnerLogic.WhoSpendsTheMostOnAnimalsHowMany();
        }




    }
}
