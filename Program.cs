using CrudWebApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var cs = builder.Configuration.GetConnectionString("connectionDB");
builder.Services.AddDbContext<DbUsuContext>(options =>
    options.UseMySql(cs, new MySqlServerVersion(new Version(8, 0, 36)))
);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

//paso 3 crea swagger
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// paso 4: crear codigo para enlasar direcctamente con swagger
app.Use(async (context, next) => {

    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger", permanent: false);
        return;
    }

    await next();

}

    );


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
