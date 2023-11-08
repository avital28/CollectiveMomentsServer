﻿using CollectiveMomentsServerBL.Models;
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
            User user = null;

            user = context.Users.Where((u) => u.Email == usr.Email && u.Passwrd == usr.Passwrd).FirstOrDefault();
            if (user != null)
            { 
                HttpContext.Session.SetObject("user", user);    
                return Ok(user);
            }
            return Forbid();
        }

        [Route("Register")]
        [HttpPost]

        public async Task<ActionResult<User>> RegisterAsync([FromBody] User usr)
        {

            User user = context.Users.Where(u=> u.UserName==usr.UserName).FirstOrDefault();
            if (user == null)
            {
                context.Users.Add(usr);
                context.SaveChanges();
                return Ok(usr);
            }
                
            return Forbid();

            
        }
    }
}
