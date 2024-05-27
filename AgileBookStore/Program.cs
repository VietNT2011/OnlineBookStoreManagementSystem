using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AgileBookStore.Data;
using AgileBookStore.Areas.Identity.Data;
using AgileBookStore.Models;
using AgileBookStore.Controllers;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AgileBookStoreContextConnection") ?? throw new InvalidOperationException("Connection string 'AgileBookStoreContextConnection' not found.");

builder.Services.AddDbContext<AgileBookStoreContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AgileBookStoreUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AgileBookStoreContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

SeedData.EnsurePopulated(app);

app.Run();
