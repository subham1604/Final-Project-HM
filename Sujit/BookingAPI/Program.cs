global using BookingAPI.Models;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Add(new ServiceDescriptor(typeof(IDatabase), typeof(HolidayDataAccessLayer), ServiceLifetime.Transient));

            builder.Services.AddDbContext<HolidayDbContext>(options =>
            {
                options.UseSqlServer("Server=.\\sqlexpress;Database=HolidayDB;Trusted_Connection=True;Encrypt=False");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}