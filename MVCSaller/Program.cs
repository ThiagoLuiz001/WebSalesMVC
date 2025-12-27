using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql ;
using Microsoft.Extensions.DependencyInjection;
using MVCSaller.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCSallerContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("MVCSallerContext");
    options.UseMySql(cs, ServerVersion.AutoDetect(cs),builder => builder.MigrationsAssembly("MVCSaller"));
});
builder.Services.AddScoped<SeedingService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<MVCSallerContext>();
    var seed = services.GetRequiredService<SeedingService>();

    if (app.Environment.IsDevelopment())
    {
        seed.Seed();
    }
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
