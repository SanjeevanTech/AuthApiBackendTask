using MongoDB.Driver;
using _.Models;  
using Microsoft.AspNetCore.Mvc;  

using _.DTOS;
using _.util;



namespace _.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMongoDatabase database) : ControllerBase
    {
        private readonly IMongoCollection<Product> _userCollection = database.GetCollection<Product>("Product");

        [HttpPost("create")]
        [AuthorizeRole("Admin")] 
        public async Task<IActionResult> CreateProduct([FromBody] ProductRegistrationRequest request)
        {
            // Validate input (you can enhance validation based on your needs)
            if (string.IsNullOrWhiteSpace(request.Productname) ||
                string.IsNullOrWhiteSpace(request.Price) ||
                string.IsNullOrWhiteSpace(request.ProductDescription))
            {
                return BadRequest("Invalid input. Please provide Productname, Price, and ProductDescription.");
            }


            // Create a new user object
            var newProduct = new Product
            {
                Productname = request.Productname,
                Price = request.Price,
                ProductDescription = request.ProductDescription,
            };

            // Insert the new user into MongoDB
            await _userCollection.InsertOneAsync(newProduct);
        

            return CreatedAtAction(nameof(CreateProduct), new { id = newProduct.Productname }, new
            {
                Message = "Product is successfully created!",
                Product = newProduct
            });
        }

        //read
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _userCollection.Find(_ => true).ToListAsync();
            return Ok(products);
        }

        //update
        [HttpPost("update/{id}")]
        [AuthorizeRole("Admin")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] ProductUpdateRequest request)
        {
            if (string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(request.Productname) ||
                string.IsNullOrWhiteSpace(request.Price) ||
                string.IsNullOrWhiteSpace(request.ProductDescription))
            {
                return BadRequest("Invalid input.");
            }

            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            var update = Builders<Product>.Update
                .Set(p => p.Productname, request.Productname)
                .Set(p => p.Price, request.Price)
                .Set(p => p.ProductDescription, request.ProductDescription);

            var result = await _userCollection.UpdateOneAsync(filter, update);

            if (result.MatchedCount == 0)
            {
                return NotFound("Product not found.");
            }

            return Ok(new
            {
                Message = "Product updated successfully",
                UpdatedProduct = request
            });
        }

        [HttpDelete("delete/{id}")]
        [AuthorizeRole("Admin")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Invalid ID.");
            }

            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            
            var result = await _userCollection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                return NotFound("Product not found.");
            }

            return Ok(new
            {
                Message = "Product deleted successfully"
            });
        }



    }

    
}
