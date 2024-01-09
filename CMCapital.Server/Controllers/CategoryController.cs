using CMCapital.Server.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMCapital.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private DataContext _db;

        public CategoryController(DataContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Category()
        {
            try
            {
                var Categories = _db.Categories.ToList();

                if (Categories.Count > 0)
                    return Ok(Categories);
                else
                    return Ok("No categories found");
            }
            catch
            {
                return BadRequest("Error processing categories");
            }
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
