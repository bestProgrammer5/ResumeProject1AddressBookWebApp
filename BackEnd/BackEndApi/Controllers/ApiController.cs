using BackEndApi.Depot;
using BackEndApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly DepotTasks depotTasksPriv;
        public ApiController(DepotTasks depotTasks) 
        { 
            this.depotTasksPriv = depotTasks;
        }


        [HttpGet]
        public async Task<ActionResult> AllContacts()
        {
            var allContacts = await depotTasksPriv.getAllContacts();
            return Ok(allContacts);
        }


        [HttpPost]
        public async Task<ActionResult> saveContact(ContactVariables contact)
        {
            await depotTasksPriv.saveContact(contact);
            return Ok(contact);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> updateContact(int id, [FromBody] ContactVariables contact)
        {
            await depotTasksPriv.updateContact(id, contact);
            return Ok(contact);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteContact(int id)
        {
            await depotTasksPriv.deleteContact(id);
            return Ok();
        }

    }
}
