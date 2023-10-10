using Bistros.Core.Application.Interfaces;
using Bistros.Core.Application.Mapping;
using Bistros.Core.Application.Services;
using Bistros.Infrastructure.Persistance.Context;
using Bistros.Infrastructure.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BistrosContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddApplicationServices();
builder.Services.AddHttpClient();
builder.Services.AddScoped(typeof(ICategoryRepository), typeof(EfCategoryRepository));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
