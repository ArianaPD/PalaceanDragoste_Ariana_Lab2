using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PalaceanDragoste_Ariana_Lab2.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PalaceanDragoste_Ariana_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PalaceanDragoste_Ariana_Lab2Context") ?? throw new InvalidOperationException("Connection string 'PalaceanDragoste_Ariana_Lab2Context' not found.")));
builder.Services.AddDbContext<PalaceanDragoste_Ariana_Lab2Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PalaceanDragoste_Ariana_Lab2Context") ?? throw new InvalidOperationException("Connection string 'PalaceanDragoste_Ariana_Lab2Context' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
