using CMCapital.Server.Data;
using CMCapital.Server.Models;
using CMCapital.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMCapital.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutController : ControllerBase
    {
        private DataContext _db;

        public AutController(DataContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Auth(string login, string password)
        {
            var logins = _db.Logins
                .Where(l => l.LoginUser == login && l.Password == password)
                .FirstOrDefault();

            if (logins != null)
            {
                TokenService tk = new TokenService();

                var token = tk.GenerateToken(logins);
                return Ok(token);
            }

            return BadRequest("login or password invalid");
        }
    }
}
