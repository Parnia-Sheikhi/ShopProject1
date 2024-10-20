using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.EF;
using Shop.DAL.EF.Repositories;
using Shop.Domain.Contract.Payments;
using Shop.Domain.Contract.Repositories;
using Shop.Domain.Entities;
using ShopProject1.Models.Identity;
using ShopProject1.Payment;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDatabase"));
});
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDatabase"));
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();


builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<ICartRepository, EfCartRepository>();
builder.Services.AddScoped<Cart>();
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
builder.Services.AddScoped<IPayment, PayIrPayment>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHsts();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(name: "areas", pattern: "{areas:exists}/{controller:Home}/{action:Index}/{id?}");
//    endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
//});

app.Run();
