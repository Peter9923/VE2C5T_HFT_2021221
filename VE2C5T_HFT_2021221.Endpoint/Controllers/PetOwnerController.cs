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
    public class PetOwnerController : ControllerBase
    {
        IPetOwnerLogic petOwnerLogic;
        IHubContext<SignalRHub> hub;

        public PetOwnerController(IPetOwnerLogic petOwnerLogic, IHubContext<SignalRHub> hub)
        {
            this.petOwnerLogic = petOwnerLogic;
            this.hub = hub;
        }

        // GET: /petowner
        [HttpGet]
        public IEnumerable<PetOwner> Get()
        {
            return petOwnerLogic.ReadAll();
        }

        // GET petowner/5
        [HttpGet("{id}")]
        public PetOwner Get(int id)
        {
            return petOwnerLogic.Read(id);
        }

        // POST /petowner
        [HttpPost]
        public void Post([FromBody] PetOwner value)
        {
            petOwnerLogic.Create(value);
            this.hub.Clients.All.SendAsync("PetOwnerCreated", value);
        }

        // PUT api/<PetOwnerController>/5
        [HttpPut]
        public void Put([FromBody] PetOwner value)
        {
            petOwnerLogic.Update(value);
            this.hub.Clients.All.SendAsync("PetOwnerUpdated", value);
        }

        // DELETE api/<PetOwnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ownerToDelete = this.petOwnerLogic.Read(id);
            petOwnerLogic.Delete(id);
            this.hub.Clients.All.SendAsync("PetOwnerDeleted", ownerToDelete);
        }
    }
}
