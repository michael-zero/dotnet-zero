using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Shop.Data;
using Shop.Models;
using Shop.Servies;

[Route("users")]
public class UserController : ControllerBase {


  [HttpGet]
  [Route("")]
  [Authorize(Roles = "manager")]
  public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context){
    var users = await context.Users
    .AsNoTracking()
    .ToListAsync();

    return Ok(users);
  }


  [HttpPost]
  [Route("")]
  [AllowAnonymous]
  // [Authorize(Roles = "manager")]
  public async Task<ActionResult<User>> Post(
  [FromBody]User model, 
  [FromServices] DataContext context){

    if(!ModelState.IsValid){
      return BadRequest(ModelState);
    }
    try{
      model.Role = "employee";
      context.Users.Add(model);
      await context.SaveChangesAsync();
      model.Password = "";
      return Ok(model);
    
    }catch(Exception){
      return BadRequest(new { message = "Não foi possível criar o usuário"});
    }
  }

  [HttpPut]
  [Route("{id:int}")]
  [Authorize(Roles = "manager")]
  public async Task<ActionResult<User>> Put(
  [FromServices] DataContext context,
  int id,
  [FromBody] User model){
    if(!ModelState.IsValid){
      return BadRequest(ModelState);
    }

    if(id != model.Id){
      return NotFound(new { message = "Usuário não encontrado"});
    }

    try{
      context.Entry(model).State = EntityState.Modified;
      await context.SaveChangesAsync();
      return model;
    }catch(Exception){
      return BadRequest(new {message = "Não foi possível atualizar o usuário"});
    }
  }

  [HttpPost]
  [Route("login")]
  public async Task<ActionResult<dynamic>> Authenticate([FromServices] DataContext context, 
    [FromBody] User model){
      var user = await context.Users
      .AsNoTracking()
      .Where(x => x.Username == model.Username && x.Password == model.Password)
      .FirstOrDefaultAsync();

      if(user == null){
        return NotFound(new { message = "Usuário ou senha inválidos"});
      }

      var token = TokenService.GenerateToken(user);
      user.Password = "";
      return new {
        user = user, 
        token = token
      };

    }

}