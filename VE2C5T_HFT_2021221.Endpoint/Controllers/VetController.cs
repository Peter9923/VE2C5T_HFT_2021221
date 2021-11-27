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
    public class VetController : ControllerBase
    {
        IVetLogic vetLogic;

        public VetController(IVetLogic vetLogic)
        {
            this.vetLogic = vetLogic;
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
        }

        // PUT /vet
        [HttpPut]
        public void Put([FromBody] Vet value)
        {
            vetLogic.Update(value);
        }

        // DELETE vet/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            vetLogic.Delete(id);
        }
    }
}
