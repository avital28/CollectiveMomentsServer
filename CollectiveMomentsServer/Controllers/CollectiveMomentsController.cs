using CollectiveMomentsServer.DTO_Models;
using CollectiveMomentsServerBL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CollectiveMomentsServer.Controllers
{
    [Route("CollectiveMomentsAPI")]
    [ApiController]
    public class CollectiveMomentsController : ControllerBase
    {
        CollectiveMomentsDbContext context;

        public CollectiveMomentsController (CollectiveMomentsDbContext context)
        {
            this.context = context;
        }

        [Route("Login")]
        [HttpPost]

        public async Task<ActionResult<User>> LoginAsync([FromBody] User usr)
        {
            try { 
            User user = null;

            user = context.Users.Where((u) => u.UserName == usr.UserName && u.Passwrd == usr.Passwrd).FirstOrDefault();
            if (user != null)
            { 
                 HttpContext.Session.SetObject("user", user);
                    return Ok(user);
            }
                   return Forbid();
            }
            catch(Exception ex) { }
            return BadRequest();    
         
        }

        [Route("Register")]
        [HttpPost]

        public async Task<ActionResult<User>> RegisterAsync([FromBody] User usr)
        {
            try
            {
                bool response = context.Users.Any(u => u.UserName == usr.UserName);
                if (response == false)
                {
                    context.Users.Add(usr);
                  await  context.SaveChangesAsync();
                    return Ok(usr);
                }
                return Conflict();

            }
            catch (Exception ex)
            {

                
            }
            return BadRequest();    

            
        }
        [Route("UpdateUser")]
        [HttpPost]
        public async Task<ActionResult<User>> UpdateUserAsync([FromBody] UserDto usr )
        {
            try
            {
                User u = context.Users.Find(usr.Id);
                if (u != null)
                {
                    if(await UpdateUser(u, usr))
                    
                    return Ok(usr);
                    return BadRequest();
                }
                else
                    return Forbid();
            }
            catch (Exception ex)
            {


            }
            return BadRequest();
        }

        private async Task<bool>  UpdateUser (User u, UserDto user)
        {
            
                if (user.Firstname!=null)
                    u.FirstName = user.Firstname;
                if (user.Lastname != null)
                    u.LastName = user.Lastname;
                if (user.Passwrd != null)
                    u.Passwrd = user.Passwrd;
                if (user.Email != null)
                    u.Email = user.Email;
                if (user.Username != null)
                    u.UserName = user.Username;
                try { await context.SaveChangesAsync(); return true; }
            catch (Exception ex) { return false; }    

            



        }
    }

    
}
