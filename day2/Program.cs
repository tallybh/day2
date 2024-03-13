using day2.Contracts;
using day2.Models;
using day2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//TODO Add mock as singleton service
builder.Services.AddControllers();
builder.Services.AddSingleton<IDirectoriesRepository, DirectoriesRepository>();
builder.Services.Configure<UnitOptions>(builder.Configuration.GetSection("Units"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
