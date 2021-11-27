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
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetLogic petLogic;

        public PetController(IPetLogic petLogic)
        {
            this.petLogic = petLogic;
        }

        // GET: /pet
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return petLogic.ReadAll();
        }

        // GET pet/5
        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            return petLogic.Read(id);
        }

        // POST /pet
        [HttpPost]
        public void Post([FromBody] Pet value)
        {
            petLogic.Create(value);
        }

        // PUT /pet
        [HttpPut]
        public void Put([FromBody] Pet value)
        {
            petLogic.Update(value);
        }

        // DELETE pet/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            petLogic.Delete(id);
        }
    }
}
