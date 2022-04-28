using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Endpoint.Services;
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

        IHubContext<SignalRHub> hub;

        public PetController(IPetLogic petLogic, IHubContext<SignalRHub> hub)
        {
            this.petLogic = petLogic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("PetCreated", value);
        }

        // PUT /pet
        [HttpPut]
        public void Put([FromBody] Pet value)
        {
            petLogic.Update(value);
            this.hub.Clients.All.SendAsync("PetUpdated", value);
        }

        // DELETE pet/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var petToDelete = this.petLogic.Read(id);
            petLogic.Delete(id);
            this.hub.Clients.All.SendAsync("PetDeleted", petToDelete);
        }
    }
}
