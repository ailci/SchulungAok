using Api.Configuration;
using Api.Controllers;
using Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .ConfigureApi()
    .ConfigureDb(builder.Configuration)
    .ConfigureDI();

var app = builder.Build();

// Configure the HTTP request pipeline. ###########################################################
//app.Use(async (context, next) =>
//{
//    var userAgent = context.Request.Headers["User-Agent"][0]?.ToLower();
//    await context.Response.WriteAsync($"First middleware {userAgent}\n");
//    await next();
//    await context.Response.WriteAsync("First middleware Back\n");

//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Second middleware\n");
//    await next();
//});
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("End middleware\n");
//});

//app.UseBrowserAllowedMiddleware(BrowserType.Chrome, BrowserType.Edge);

app.UseExceptionHandler(opt => { });

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
