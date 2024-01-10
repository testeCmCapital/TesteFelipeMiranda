using CMCapital.Server.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMCapital.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private DataContext _db;

        public ClientController(DataContext db)
        {
            _db = db;
        }

        [Authorize]
        [Route("Client/{id}")]
        [HttpGet]
        public IActionResult Client(int id)
        {
            try
            {
                var client = _db.Clients.FirstOrDefault(p => p.ID == id && p.Active == 1);

                if (client == null)
                    return BadRequest("client not found");
                
                return Ok(client);
            }
            catch
            {
                return BadRequest("error when searching for client");
            }
        }
    }
}
