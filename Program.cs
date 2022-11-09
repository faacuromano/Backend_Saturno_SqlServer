using Saturno_Backend.Data;
using Saturno_Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Contexto de la Base de Datos
builder.Services.AddSqlServer<SaturnoContext>(builder.Configuration.GetConnectionString("DataBaseConnection"));

//Capa de servicios
builder.Services.AddScoped<ClientService>();


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
