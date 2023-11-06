using CollectiveMomentsServerBL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]

        public async Task<ActionResult<User>> Login([FromBody] User usr)
        {
            User user = null;

            user = context.Users.Where((u) => u.Email == usr.Email && u.Passwrd == usr.Passwrd).FirstOrDefault();
            if (user != null)
            { 
                HttpContext.Session.SetObject("user", user);    
                return Ok(user);
            }
            return Forbid();
        }


    }
}
