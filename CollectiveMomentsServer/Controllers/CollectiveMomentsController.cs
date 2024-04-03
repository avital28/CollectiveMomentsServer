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
        //
        [Route("UpdateUser")]
        [HttpPost]
        public async Task<ActionResult<User>> UpdateUserAsync([FromBody] UserDto usr )
        {
            try
            {
                User u = context.Users.Find(usr.Id);
                if (u != null)
                {
                    if(await UpdateUser1(u, usr))
                    
                    return Ok(u);
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

        private async Task<bool>  UpdateUser1 (User u, UserDto user)
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

        [Route("GetAlbumsByLocation")]
        [HttpPost]
        public async Task<ActionResult<List<AlbumDto>>> GetAlbumsByLocationAsync([FromBody] Album album)
        {
            try
            {
                List<Album> albums = new List<Album>();
                albums=context.Albums.Where(a=> a.Longitude==album.Longitude && a.Latitude==album.Latitude).ToList();
                if (albums !=null)
                {
                    List<AlbumDto> albumDtos = new List<AlbumDto>();
                    for (int i = 0; i < albums.Count; i++)
                    {
                        Album a= albums.ElementAt(i);
                        AlbumDto dto = await ConvertMedia(a);
                        albumDtos.Add( new AlbumDto () { AdminId = a.AdminId, AlbumCover=a.AlbumCover, AlbumTitle=a.AlbumTitle, Id=a.Id, Latitude=a.Latitude, Longitude=a.Longitude, Media=dto.Media });
                    }
                    return Ok(albumDtos);
                }

                return NotFound();

            }
            catch (Exception ex)
            {


            }
            return BadRequest();


        }
        
        private async Task<AlbumDto> ConvertMedia (Album album)
        {
            AlbumDto albumDto= new AlbumDto();
            if (album.AlbumMedia != null)
            {
                for (int i = 0; i < album.AlbumMedia.Count; i++)
                {
                    MediaItem a = album.MediaItems.ElementAt(i);
                    albumDto.Media.Add(new MediaItem() { });
                }
            }
            return albumDto;    
        }

        [Route("CreateAlbum")]
        [HttpPost]
        public async Task<ActionResult<Album>> CreateAlbumAsync( IFormFile file, [FromForm] string album)
        {
            try
            {
                Album? filealbum = JsonSerializer.Deserialize<Album>(album);
                IFormFile f = file;
                context.Albums.Add(filealbum) ;
                await context.SaveChangesAsync();
                await UpdatePath(f, filealbum);
                return Ok(filealbum);
            }
            catch (Exception ex) { }
            return BadRequest();

        }

        //[Route("UpdateAlbumCover")]
        //[HttpPost]
        //public async Task<ActionResult<Album>> UpdateAlbumCover([FromBody] IFormFile f, Album album)
        //{
        //    try
        //    {
        //        if (await UpdatePath(f, album))
        //        {
        //            return Ok(album);
        //        }
        //        return Unauthorized();
        //    }
        //    catch (Exception ex) { }
        //    return BadRequest();
        //}

        private async Task<bool> UpdatePath(IFormFile file, Album album)
        {
            string cover = $"{album.Id}{Path.GetExtension(file.FileName)}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", cover);
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                album.AlbumCover = cover;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        [Route("GetAlbumsByUser")]
        [HttpPost]
        public async Task<ActionResult<List<AlbumDto>>> GetAlbumsByUserAsync([FromBody] User user)
        {
            try
            {
                List<Album> albums = new List<Album>();
                albums = context.Albums.Where(u => u.AdminId==user.Id).ToList();
                if (albums != null)
                {
                    List<AlbumDto> albumDtos = new List<AlbumDto>();
                    for (int i = 0; i < albums.Count; i++)
                    {
                        Album a = albums.ElementAt(i);
                        AlbumDto dto = await ConvertMedia(a);
                        albumDtos.Add(new AlbumDto() { AdminId = a.AdminId, AlbumCover = a.AlbumCover, AlbumTitle = a.AlbumTitle, Id = a.Id, Latitude = a.Latitude, Longitude = a.Longitude, Media = dto.Media });
                    }
                    return Ok(albumDtos);
                }

                return NotFound();

            }
            catch (Exception ex)
            {

                
            }
            return BadRequest();


        }



    }



}







