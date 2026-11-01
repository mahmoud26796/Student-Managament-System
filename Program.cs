using Microsoft.EntityFrameworkCore;
using StudentManagamentSystem.Data;
using StudentManagamentSystem.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnStr"));
});
builder.Services.AddAutoMapper(cgf =>
{
    // passing the configurations to get the assembly of the models to convert between model and dto
    cgf.AddMaps(typeof(StudentProfile).Assembly);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.Run();

