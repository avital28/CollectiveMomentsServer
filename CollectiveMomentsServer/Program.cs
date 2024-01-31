using System.Text.Json;
using System.Text.Json.Serialization;
using CollectiveMomentsServerBL.Models;
using Microsoft.EntityFrameworkCore;
namespace ContactsServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region DB Context
            //when working from home "HomeCollectiveMomentsDB" School: "CollectiveMomentsDB"
            string connection = builder.Configuration.GetConnectionString("HomeCollectiveMomentsDB");
            builder.Services.AddDbContext<CollectiveMomentsDbContext>(options =>options.UseSqlServer(connection));
            #endregion
            #region Json handling
            builder.Services.AddControllers().AddJsonOptions(o=>o.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.Preserve);
            #endregion
            #region Session Support
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromSeconds(300); options.Cookie.HttpOnly = true; options.Cookie.IsEssential = true; });
            #endregion
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            #region Use files and session
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            #endregion

            app.MapControllers();

            app.Run();
        }
    }
}