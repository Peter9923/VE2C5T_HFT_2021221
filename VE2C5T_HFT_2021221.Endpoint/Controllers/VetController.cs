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
    public class VetController : ControllerBase
    {
        IVetLogic vetLogic;
        IHubContext<SignalRHub> hub;

        public VetController(IVetLogic vetLogic, IHubContext<SignalRHub> hub)
        {
            this.vetLogic = vetLogic;
            this.hub = hub;
        }

        // GET: /vet
        [HttpGet]
        public IEnumerable<Vet> Get()
        {
            return vetLogic.ReadAll();
        }

        // GET vet/5
        [HttpGet("{id}")]
        public Vet Get(int id)
        {
            return vetLogic.Read(id);
        }

        // POST /vet
        [HttpPost]
        public void Post([FromBody] Vet value)
        {
            vetLogic.Create(value);
            this.hub.Clients.All.SendAsync("VetCreated", value);
        }

        // PUT /vet
        [HttpPut]
        public void Put([FromBody] Vet value)
        {
            vetLogic.Update(value);
            this.hub.Clients.All.SendAsync("VetUpdated", value);
        }

        // DELETE vet/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var vetToDelete = this.vetLogic.Read(id);
            vetLogic.Delete(id);
            this.hub.Clients.All.SendAsync("VetDeleted", vetToDelete);
        }
    }
}
