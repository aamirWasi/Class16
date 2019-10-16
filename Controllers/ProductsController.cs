using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IService _service;

        public ProductsController(IService service)
        {
            _service = service;
        }
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _service.Get();
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var book =  _service.GetId(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();
            var createdBook = _service.AddProduct(product);
            return CreatedAtRoute("GetBook", new { id = createdBook.Id }, createdBook);
        }

        // POST: api/Products
        //[HttpPost]
        //public Product GetProduct([FromBody] Product product)
        //{
        //    return _service.Add(product);
        //}

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,Product product)
        {
            if (product == null)
                return BadRequest();
            var note = _service.GetId(product.Id);


            if (note == null)
            {
                return NotFound();
            }


            product.Id = id; 
            _service.Update(product);


            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete = _service.GetId(id);
            _service.Delete(id);
            if (delete == null)
                return NotFound();
            return NoContent();
        }
    }
}
