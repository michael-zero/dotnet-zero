using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers {
  [Route("products")]
  public class ProductController : ControllerBase {

    [HttpGet]
    [Route("")]
    [AllowAnonymous]
    public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context){
      var products = await context
      .Products
      .Include(x => x.Category) //incluir categoria quando busca produto (Referencia) - Join
      .AsNoTracking()
      .ToListAsync();

      return products;
    }

    [HttpGet]
    [Route("{id:int}")]
    [AllowAnonymous]
    public async Task<ActionResult<Product>> GetById(
    int id,
    [FromServices] DataContext context
    ){
      var product = await context
      .Products
      .Include(x => x.Category)
      .AsNoTracking()
      .FirstOrDefaultAsync(x => x.Id == id);

      return product;
    }

    [HttpGet] //products/categories/1  :  produtos da categoria 1
    [Route("categories/{id:int}")]
    [AllowAnonymous]
    public async Task<ActionResult<List<Product>>> GetByCategory(
    int id,
    [FromServices] DataContext context
    ){

      var products = await context
      .Products
      .Include(x => x.Category)
      .AsNoTracking()
      .Where(x => x.CategoryId == id)
      .ToListAsync();
      
      return products;
    }

  [HttpPost]
  [Route("")]
  [Authorize(Roles = "employee")]
  public async Task<ActionResult<Product>> Post(
  [FromBody]Product model, 
  [FromServices] DataContext context){

    ModelState.Remove("Category");
    if(ModelState.IsValid){
      context.Products.Add(model);
      await context.SaveChangesAsync();
      return Ok(model);
    }else{
      return BadRequest(ModelState);
    }
  }
  }
}