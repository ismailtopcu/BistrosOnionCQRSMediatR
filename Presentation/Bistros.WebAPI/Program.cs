using Bistros.Core.Application.Interfaces;
using Bistros.Core.Application.Mapping;
using Bistros.Infrastructure.Persistance.Context;
using Bistros.Infrastructure.Persistance.Repositories;
using Bistros.Core.Application.Services;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BistrosContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddApplicationServices();

builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddCors(opt =>
{
	opt.AddPolicy("Bistros", opts =>
	{
		opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("Bistros");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
