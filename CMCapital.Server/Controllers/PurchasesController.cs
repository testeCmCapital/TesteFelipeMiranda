using CMCapital.Server.Data;
using CMCapital.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;

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
        [Route("PurchaseProduct")]
        [HttpPost]
        public IActionResult PurchaseProduct([FromQuery] int idProduct, [FromQuery] int amount, [FromQuery] int idClient)
        {
            try
            {
                double balance;

                #region validação dos campos

                if (idProduct <= 0 || amount <= 0 || idClient <= 0)
                {
                    //é possível melhorar essa validação
                    return BadRequest("All fields must be filled");
                }

                #endregion

                var products = _db.Products.FirstOrDefault(x => x.ID == idProduct && x.Active == 1);
                List<object> resultResponse = new List<object>();

                if (products != null && products.Amount >= Convert.ToInt32(amount))
                {
                    var client = _db.Clients.FirstOrDefault(x => x.ID == idClient && x.Active == 1);

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
                            bool purchaseHistory = _db.PurchaseHistories.
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

                                _db.PurchaseHistories.Add(history);
                                _db.SaveChanges();

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
                            var productCategory = _db.Products.Where(p => p.IDCategory == products.IDCategory
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
                    else
                    {
                        return BadRequest("Client not found");
                    }
                }
                else
                {
                    return BadRequest("Product not found");
                }

                return Ok(resultResponse);
            }
            catch
            {
                return BadRequest("Internal error...");
            }
        }

        [Authorize]
        [Route("PurchaseHistory")]
        [HttpGet]
        public IActionResult PurchaseHistory()
        {
            try
            {
                var historic = from purchaseHistory in _db.PurchaseHistories
                               join product in _db.Products on purchaseHistory.IDProduct equals product.ID
                               join client in _db.Clients on purchaseHistory.IDClient equals client.ID
                               where purchaseHistory.Active == 1
                               select new
                               {
                                   Id = purchaseHistory.ID,
                                   Client = client.ClientName,
                                   Product = product.ProductName,
                                   Quantities = purchaseHistory.Quantities,
                                   PurchaseValue = purchaseHistory.PurchaseValue,
                                   PurchaseDate = purchaseHistory.PurchaseDate
                               };

                List<Dictionary<string, object>> response = new List<Dictionary<string, object>>();

                if (historic.Count() > 0)
                {
                    foreach (var r in historic)
                    {
                        var dataCliente = new
                        {
                            id = r.Id,
                            client = r.Client,
                            product = r.Product,
                            quantities = r.Quantities,
                            purchaseValue = r.PurchaseValue,
                            purchaseDate = r.PurchaseDate
                        };

                        var result = new Dictionary<string, object>
                        {

                           { dataCliente.client, dataCliente }

                        };

                        response.Add(result);
                    }
                }
                else
                {
                    return Ok("No purchase history found");
                }


                return Ok(response);
            }
            catch
            {
                return BadRequest("Error processing purchase history");
            }
        }

        [Authorize]
        [Route("HistoryPurchaseClientId/{id}")]
        [HttpGet]

        public IActionResult HistoryPurchaseClientId(int id)
        {
            try
            {
                var historic = from purchaseHistory in _db.PurchaseHistories
                               join product in _db.Products on purchaseHistory.IDProduct equals product.ID
                               join client in _db.Clients on purchaseHistory.IDClient equals client.ID
                               where client.ID == id && purchaseHistory.Active == 1
                               select new
                               {
                                   Id = purchaseHistory.ID,
                                   Client = client.ClientName,
                                   Product = product.ProductName,
                                   Quantities = purchaseHistory.Quantities,
                                   PurchaseValue = purchaseHistory.PurchaseValue,
                                   PurchaseDate = purchaseHistory.PurchaseDate
                               };

                List<Dictionary<string, object>> response = new List<Dictionary<string, object>>();

                if (historic.Count() > 0)
                {
                    foreach (var r in historic)
                    {
                        var dataCliente = new
                        {
                            id = r.Id,
                            client = r.Client,
                            product = r.Product,
                            quantities = r.Quantities,
                            purchaseValue = r.PurchaseValue,
                            purchaseDate = r.PurchaseDate
                        };

                        var result = new Dictionary<string, object>
                        {

                            { dataCliente.client, dataCliente }

                        };

                        response.Add(result);
                    }
                }
                else
                {
                    return Ok("No purchase history found");
                }
                return Ok(response);
            }
            catch
            {
                return BadRequest("Error processing purchase history");
            }
        }

        [Authorize]
        [Route("TopSellingProducts")]
        [HttpGet]
        public IActionResult TopSellingProducts()
        {
            try
            {
                var historic = from purchaseHistory in _db.PurchaseHistories
                               join product in _db.Products on purchaseHistory.IDProduct equals product.ID
                               join client in _db.Clients on purchaseHistory.IDClient equals client.ID
                               where purchaseHistory.Active == 1
                               orderby purchaseHistory.Quantities descending
                               select new
                               {
                                   Id = purchaseHistory.ID,
                                   Client = client.ClientName,
                                   Product = product.ProductName,
                                   Quantities = purchaseHistory.Quantities,
                                   PurchaseValue = purchaseHistory.PurchaseValue,
                                   PurchaseDate = purchaseHistory.PurchaseDate
                               };

                List<Dictionary<string, object>> response = new List<Dictionary<string, object>>();

                if (historic.Count() > 0)
                {
                    foreach (var r in historic)
                    {
                        var dataCliente = new
                        {
                            id = r.Id,
                            client = r.Client,
                            product = r.Product,
                            quantities = r.Quantities,
                            purchaseValue = r.PurchaseValue,
                            purchaseDate = r.PurchaseDate
                        };

                        var result = new Dictionary<string, object>
                        {

                            { dataCliente.client, dataCliente }

                        };

                        response.Add(result);
                    }
                }
                else
                {
                    return Ok("No purchase history found");
                }
                return Ok(response);
            }
            catch
            {
                return BadRequest("Error processing top selling products");
            }
        }

        [Authorize]
        [Route("LeastSellingProducts")]
        [HttpGet]
        public IActionResult LeastSellingProducts()
        {
            try
            {
                var historic = from purchaseHistory in _db.PurchaseHistories
                               join product in _db.Products on purchaseHistory.IDProduct equals product.ID
                               join client in _db.Clients on purchaseHistory.IDClient equals client.ID
                               where purchaseHistory.Active == 1
                               orderby purchaseHistory.Quantities ascending
                               select new
                               {
                                   Id = purchaseHistory.ID,
                                   Client = client.ClientName,
                                   Product = product.ProductName,
                                   Quantities = purchaseHistory.Quantities,
                                   PurchaseValue = purchaseHistory.PurchaseValue,
                                   PurchaseDate = purchaseHistory.PurchaseDate
                               };

                List<Dictionary<string, object>> response = new List<Dictionary<string, object>>();

                if (historic.Count() > 0)
                {
                    foreach (var r in historic)
                    {
                        var dataCliente = new
                        {
                            id = r.Id,
                            client = r.Client,
                            product = r.Product,
                            quantities = r.Quantities,
                            purchaseValue = r.PurchaseValue,
                            purchaseDate = r.PurchaseDate
                        };

                        var result = new Dictionary<string, object>
                        {

                            { dataCliente.client, dataCliente }

                        };

                        response.Add(result);
                    }
                }
                else
                {
                    return Ok("No purchase history found");
                }
                return Ok(response);
            }
            catch
            {
                return BadRequest("Error processing top selling products");
            }
        }

        [Authorize]
        [Route("ChargebackCustomer")]
        [HttpPost]
        public IActionResult ChargebackCustomer(int idClient, int idPurchase)
        {
            try
            {
                if (idClient <= 0 || idPurchase <= 0)
                {
                    //é possível melhorar essa validação
                    return BadRequest("All fields must be filled");
                }

                var purchase = _db.PurchaseHistories.FirstOrDefault(p => p.ID == idPurchase && p.IDClient == idClient && p.Active == 1);
                
                if (purchase != null)
                {
                    if (DateTime.Now <= purchase.PurchaseDate.Value.AddDays(7))
                    {
                        var client = _db.Clients.FirstOrDefault(p => p.ID == idClient && p.Active == 1);

                        if (client != null)
                        {

                            client.Balance += purchase.PurchaseValue;
                            purchase.Active = 0;

                            _db.SaveChanges();

                        }
                        else
                        {
                            return BadRequest("Client not found");
                        }
                    }
                    else
                    {
                        return BadRequest("It was not possible to make a refund (It has been 7 days since the purchase)");
                    }
                }
                else
                {
                    return BadRequest("Purchase not found");
                }

                return Ok($"refund in the amount {purchase.PurchaseValue} of was made");
            }
            catch
            {
                return BadRequest("Error when reversing the purchase");
            }
        }
    }
}
