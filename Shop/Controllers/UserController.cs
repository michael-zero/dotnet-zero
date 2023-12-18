using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Shop.Data;
using Shop.Models;
using Shop.Servies;

[Route("users")]
public class UserController : ControllerBase {


  [HttpPost]
  [Route("")]
  [AllowAnonymous]
  public async Task<ActionResult<User>> Post(
  [FromBody]User model, 
  [FromServices] DataContext context){

    if(!ModelState.IsValid){
      return BadRequest(ModelState);
    }
    try{
      context.Users.Add(model);
      await context.SaveChangesAsync();
      return Ok(model);
    
    }catch(Exception){
      return BadRequest(new { message = "Não foi possível criar o usuário"});
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
      return new {
        user = user, 
        token = token
      };

    }


}