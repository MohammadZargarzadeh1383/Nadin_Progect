using Microsoft.EntityFrameworkCore;
using Nadin_Soft_Api_Project.Application.Interfaces.ApplicationDbContext;
using Nadin_Soft_Api_Project.Application.Interfaces.Repositories;
using Nadin_Soft_Api_Project.Domain.Entities.Comment;
using Nadin_Soft_Api_Project.Domain.Entities.User;
using Nadin_Soft_Api_Project.Infrastucture.ApplicationDb;
using Nadin_Soft_Api_Project.Infrastucture.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IGenericRepository<Comment>, GenericRepository<Comment>>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
