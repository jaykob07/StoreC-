using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbkaContext dbContext;

        public ProductController(DbkaContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        [Route("lista")]

        public async Task<IActionResult> GetProducts()
        {
            var listproducts = await dbContext.Productos.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, listproducts);
        }

        [HttpGet]
        [Route("item/{id:int}")]

        public async Task<IActionResult> GetProduct(int id)
        {
            var item = await dbContext.Productos.FirstOrDefaultAsync(i => i.IdProduct == id);
            return StatusCode(StatusCodes.Status200OK, item);
        }

        [HttpPost]
        [Route("nuevo")]

        public async Task<IActionResult> New([FromBody] Producto objeto)
        {
            await dbContext.Productos.AddAsync(objeto);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, new {mensaje = "ok"});

        }

        [HttpPut]
        [Route("editar")]

        public async Task<IActionResult> Edit([FromBody] Producto objeto)
        {
            dbContext.Productos.Update(objeto);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, new { mensaje = "ok" });

        }


        [HttpGet]
        [Route("eliminar/{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var item = await dbContext.Productos.FindAsync(i => i.IdProduct == id);
            dbContext.Productos.Remove(item);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, item);
        }




    }
}
