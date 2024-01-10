using CMCapital.Server.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMCapital.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private DataContext _db;

        public ProductController(DataContext db)
        {
            _db = db;
        }

        [Authorize]
        [Route("PurchaseHistory")]
        [HttpGet]
        public IActionResult Product()
        {
            try
            {
                var product = _db.Products.ToList();

                if (product.Count > 0)
                {
                    return Ok(product);
                }
                else
                {
                    return Ok("No product found");
                }
            }
            catch
            {
                return BadRequest("Error when processing products");
            }
        }
    }
}
