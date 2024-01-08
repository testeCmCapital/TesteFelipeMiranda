using CMCapital.Server.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMCapital.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private DataContext _db;

        public PurchasesController(DataContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpPost]
        public IActionResult PurchadesProduct(int idProduct, string purchases, int idClient, string? balance)
        {
            try
            {
                var products = _db.Products.FirstOrDefault(x => x.ID == idProduct);

                if (products != null)
                {
                    if (products.Amount > Convert.ToInt32(purchases))
                    {
                        var client = _db.Clients.FirstOrDefault(x => x.ID == idClient);

                        if (client != null)
                        {
                            //bool makePurchase = client.Balance > 
                        }
                        else
                        {
                            return BadRequest("Client not found");
                        }
                    }
                }
                else
                {
                    return BadRequest("Product not found");
                }

                return Ok();
            }
            catch
            {
                return BadRequest("Internal error...");
            }
            
        }
    }
}
