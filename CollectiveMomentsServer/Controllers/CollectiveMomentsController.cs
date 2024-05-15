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
            if (user.ProfilePicture != null)
                u.ProfilePicture = user.ProfilePicture;
            try { await context.SaveChangesAsync(); return true; }
            catch (Exception ex) { return false; }    
        }

        //[Route("GetAlbumsByLocation")]
        //[HttpGet]
        //public async Task<ActionResult<List<AlbumDto>>> GetAlbumsByLocationAsync([FromQuery] string Latitude, string Longtitude)
        //{
        //    try
        //    {
        //        List<Album> albums = new List<Album>();
        //        albums=context.Albums.Where(a=> a.Longitude==album.Longitude && a.Latitude==album.Latitude).ToList();
        //        if (albums !=null)
        //        {
        //            List<AlbumDto> albumDtos = new List<AlbumDto>();
        //            for (int i = 0; i < albums.Count; i++)
        //            {
        //                Album a= albums.ElementAt(i);
        //                AlbumDto dto = await ConvertMedia(a);
        //                albumDtos.Add( new AlbumDto () { AdminId = a.AdminId, AlbumCover=a.AlbumCover, AlbumTitle=a.AlbumTitle, Id=a.Id, Latitude=a.Latitude, Longitude=a.Longitude, Media=dto.Media });
        //            }
        //            return Ok(albumDtos);
        //        }

        //        return NotFound();

        //    }
        //    catch (Exception ex)
        //    {


        //    }
        //    return BadRequest();


        //}
        
        private async Task<AlbumDto> ConvertMedia (Album album)
        {
            AlbumDto albumDto= new AlbumDto();
            if (album.AlbumMedia != null)
            {
                for (int i = 0; i < album.AlbumMedia.Count; i++)
                {
                    MediaItem a = album.MediaItems.ElementAt(i);
                    albumDto.Media.Add(a.Media);
                }
            }
            return albumDto;    
        }

        private async Task<AlbumDto> ConvertMembers(Album album)
        {
            AlbumDto albumDto = new AlbumDto();
            if (album.Members != null)
            {
                for (int i = 0; i < album.AlbumMedia.Count; i++)
                {
                    User u = album.Members.ElementAt(i).User;
                    albumDto.Members.Add(u);
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

        //[Route("GetAlbumsByAdmin")]
        //[HttpPost]
        //public async Task<ActionResult<List<AlbumDto>>> GetAlbumsByAdminAsync([FromBody] User user)
        //{
        //    try
        //    {
        //        List<Album> albums = new List<Album>();
        //        albums = context.Albums.Where(u => u.AdminId==user.Id).ToList();
        //        if (albums != null)
        //        {
        //            List<AlbumDto> albumDtos = new List<AlbumDto>();
        //            for (int i = 0; i < albums.Count; i++)
        //            {
        //                Album a = albums.ElementAt(i);
        //                AlbumDto dto = await ConvertMedia(a);
        //                AlbumDto dto2 = await ConvertMembers(a);
        //                albumDtos.Add(new AlbumDto() { AdminId = a.AdminId, AlbumCover = a.AlbumCover, AlbumTitle = a.AlbumTitle, Id = a.Id, Latitude = a.Latitude, Longitude = a.Longitude, Media = dto.Media, Members=dto2.Members });
        //            }
        //            return Ok(albumDtos);
        //        }

        //        return NotFound();

        //    }
        //    catch (Exception ex)
        //    {

                
        //    }
        //    return BadRequest();


        //}

        //[Route("GetAlbumsByMembers")]
        //[HttpPost]
        //public async Task<ActionResult<List<AlbumDto>>> GetAlbumsByMembersAsync([FromBody] User user)
        //{
        //    try
        //    {
        //        List<Album> albums = new List<Album>();
        //        List<AlbumDto> albumdtos = new List<AlbumDto>();
        //        albums = context.Albums.Where(u => u.AdminId != user.Id || (context.Members.FirstOrDefault(m => m.UserId == user.Id)) != null).ToList();

        //        if (albums != null)
        //        {
        //            foreach (Album a in albums)
        //            {
        //                AlbumDto dto = await ConvertMembers(a);
        //                 AlbumDto dto2 = await ConvertMedia(a);
        //                albumdtos.Add((new AlbumDto() { AdminId = a.AdminId, AlbumCover = a.AlbumCover, AlbumTitle = a.AlbumTitle, Id = a.Id, Latitude = a.Latitude, Longitude = a.Longitude, Media = dto2.Media, Members = dto.Members }));
                            
        //             }
        //            return Ok(albumdtos);
        //        }
                    

                
        //        return NotFound();

        //    }
        //    catch (Exception ex)
        //    {


        //    }
        //    return BadRequest();


        //}
        [Route("GetAlbumsByUser")]
        [HttpGet]
        public async Task<ActionResult<List<AlbumDto>>> GetAlbumsByUserAsync([FromQuery] int userId)
        {
            try
            {
                
                List<AlbumDto> albumdtos = new List<AlbumDto>();
                var albums = context.Albums.Where( al=> al.AdminId==userId|| al.Members.Any(mm=>mm.UserId==userId)); 

                if (albums != null)
                {
                    foreach (Album a in albums)
                    {
                        AlbumDto dto = await ConvertMembers(a);
                        AlbumDto dto2 = await ConvertMedia(a);
                       albumdtos.Add((new AlbumDto() { AdminId = a.AdminId, AlbumCover = a.AlbumCover, AlbumTitle = a.AlbumTitle, Id = a.Id, Latitude = a.Latitude, Longitude = a.Longitude, Media = dto2.Media, Members = dto.Members, MediaCount=a.MediaCount }));
                      }
                    return Ok(albumdtos);
                }

                //return NotFound();

            
                

            }
            catch (Exception ex)
            {


            }
            return BadRequest();


        }
        [Route("GetMediaByAlbum")]
        [HttpGet]
        public async Task<ActionResult<List<Medium>>> GetMediaByAlbumAsync([FromQuery] int albumId)
        {
            try
            {
               
                var media = context.MediaItems.Where(m=> m.AlbumId == albumId).ToList();
                List<Medium> media1 = new List<Medium>();
                if (media != null)
                {
                    var items = context.MediaItems.Where(m => m.AlbumId == albumId).ToList();

                    foreach (var m in media)
                    {
                        media1.Add(m.Media);
                        
                    }
                    return Ok(media1);
                }

                return NotFound();




            }
            catch (Exception ex)
            {


            }
            return BadRequest();


        }
        [Route("UploadMedia")]
        [HttpPost]
        public async Task<ActionResult<AlbumDto>> UploadMediaAsync(IFormFile file, [FromForm] string album, [FromForm] string photo)
        {
            try
            {
                Album? filealbum = JsonSerializer.Deserialize<Album>(album);
                IFormFile f = file;
                Album a = context.Albums.Find(filealbum.Id);
                if (a != null)
                {
                    AlbumDto dto= await ConvertMedia(a);
                    AlbumDto alb = new AlbumDto() { Id = a.Id, AdminId = a.AdminId, AlbumCover = a.AlbumCover, AlbumTitle = a.AlbumTitle, Latitude = a.Latitude, Longitude = a.Longitude, Media=dto.Media };
                    Medium? media = JsonSerializer.Deserialize<Medium>(photo);
                    bool IsUpdated = await UpdateMediaPath(file, media, alb);
                    if (IsUpdated == true)
                    {
                        await context.SaveChangesAsync();

                        return Ok(alb);
                    }
                }
            }
            catch (Exception ex) { }
            return BadRequest();

        }
        private async Task<bool> UpdateMediaPath(IFormFile file, Medium media, AlbumDto album)
        {
            string mediapath = $"{media.Id}{Path.GetExtension(file.FileName)}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", mediapath);
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                
                media.Sources = mediapath;
                album.Media.Add(media); 
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }


        [Route("UpdateAlbumCover")]
        [HttpPost]
        public async Task<ActionResult<string>> UpdateAlbumCoverAsync(IFormFile file, [FromForm] string album)
        {
            try
            {
                Album? filealbum = JsonSerializer.Deserialize<Album>(album);
                IFormFile f = file;
                Album a = context.Albums.Find(filealbum.Id);
                if (a != null)
                {
                    await UpdatePath(f, a);
                   return Ok(a.AlbumCover);
                }
                
            }
            catch (Exception ex) { }
            return BadRequest();

        }



    }



}







