using Microsoft.EntityFrameworkCore;
using WindowBlazor_Business.Repository.IRepository;
using WindowBlazor_Business.Repository;
using WindowBlazor_DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IWindowRepository, WindowRepository>();
builder.Services.AddScoped<ISubElementRepository, SubElementRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("WindowBlazor", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("WindowBlazor");

app.UseAuthorization();

app.MapControllers();

app.Run();
