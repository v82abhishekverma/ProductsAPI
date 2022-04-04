using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Data;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repository;

        public ProductsController(IProductRepo repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult <IEnumerable<Product>> GetAllProducts()
        { 
            return Ok(_repository.GetProducts());
        }

      
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult <Product> GetProductById(int id)
        {
            var productItem = _repository.GetProductById(id);
            return productItem != null? Ok(productItem) : NotFound();
        }
     
        [HttpGet("search")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> GetProductsByColour([FromQuery]string colour = "all")
        {
            return colour == null ? BadRequest("Provide value for colour") : Ok(_repository.GetProductsByColour(colour));
        }
    }
}
