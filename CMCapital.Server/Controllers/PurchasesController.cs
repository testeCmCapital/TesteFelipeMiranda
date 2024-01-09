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
        private DataContext _dataBase;

        public PurchasesController(DataContext db)
        {
            _dataBase = db;
        }

        [Authorize]
        [HttpPost]
        public IActionResult PurchadesProduct(int idProduct, string purchases, int idClient, string? balance)
        {
            try
            {
                var products = _db.Products.FirstOrDefault(x => x.ID == idProduct);

                if (products != null)
    
                    //é possível melhorar essa validação
                    return BadRequest("All fields must be filled");
                }

                #endregion

                var products = _dataBase.Products.FirstOrDefault(x => x.ID == idProduct && x.Active == 1);
                List<object> resultResponse = new List<object>();

                if (products != null && products.Amount >= Convert.ToInt32(amount))
                {
                    var client = _dataBase.Clients.FirstOrDefault(x => x.ID == idClient && x.Active == 1);

                    balance = (double)client.Balance;
                   
                    if (client != null)
                    {
                        double residualBalance = balance * 0.2;
                        balance -= residualBalance;
                        double purchaseValue = (double)products.Value * amount;
                        double postPurchase = (double)balance - purchaseValue;
                        bool makePurchase = postPurchase > 0 ? true : false;
                        
                        if (makePurchase)
                        {
                            bool purchaseHistory = _dataBase.PurchaseHistories.
                                FirstOrDefault(p => p.IDProduct == idProduct && p.Quantities == amount && p.IDClient == idClient) != null ? true : false;

                            if (!purchaseHistory)
                            {
                                client.Balance = postPurchase;
                                products.Amount -= amount;

                                PurchaseHistory history = new PurchaseHistory
                                {
                                    IDClient = client.ID,
                                    IDProduct = products.ID,
                                    Quantities = amount,
                                    PurchaseValue = purchaseValue,
                                    PurchaseDate = DateTime.UtcNow
                                };

                                _dataBase.PurchaseHistories.Add(history);
                                _dataBase.SaveChanges();

                                var result = new
                                {
                                    Product = products.ProductName,
                                    Quantities = amount,
                                    DueDate = products.DueDate,
                                    Value = purchaseValue,
                                    balancePostPurchase = postPurchase
                                };

                                resultResponse.Add(result);
                            }
                            else
                            {
                                var response = new
                                {
                                    error = @"It is not permitted to make the same purchase with the same quantity. Please change the quantity of the product so that the purchase can be made.",
                                };

                                return UnprocessableEntity(response);
                            }
                        }
                        else
                        {
                            var productCategory = _dataBase.Products.Where(p => p.IDCategory == products.IDCategory
                            && p.Amount >= amount && p.DueDate <= products.DueDate.AddMonths(-4) && p.Value <= balance && p.Active == 1).ToList();

                            if (productCategory.Count == 0)
                            {
                                var response = new
                                {
                                    Error = "Insufficient balance.",
                                    ProductAvailable = "No products available"
                                };

                                return UnprocessableEntity(response);
                            }
                            else
                            {
                                var response = new
                                {
                                    Error = "Insufficient balance.",
                                    YourBalance = balance + residualBalance,
                                    ProductAvailable = productCategory
                                };

                                return UnprocessableEntity(response);
                            }   

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
