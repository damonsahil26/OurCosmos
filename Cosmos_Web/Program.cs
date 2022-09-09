using Cosmos_ApplicationServices.IServices;
using Cosmos_ApplicationServices.Services;
using Cosmos_DataAccess.Data;
using Cosmos_DataAccess.IRepository;
using Cosmos_DataAccess.Repository;
using Cosmos_Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IGalaxyRepository, GalaxyRepository>();
builder.Services.AddScoped<IGalaxyService, GalaxyService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseCosmos(builder.Configuration["AccountEndPoint"],
builder.Configuration["AccountKey"],
builder.Configuration["DbName"]
));
builder.Services.AddHttpClient("Cosmos", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://cosmos-api-service.azurewebsites.net/");

    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
