using Saturno_Backend.Data;
using Saturno_Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Requirimento del Token en Swagger (Desactivado siguen funcionando pero sin)
builder.Services.AddSwaggerGen(setupAction =>  
{
    setupAction.AddSecurityDefinition("ConsultaAlumnosApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Acá pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement 
    { 
        {
            new OpenApiSecurityScheme  
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ConsultaAlumnosApiBearerAuth" 
                } //Tiene que coincidir con el id seteado arriba en la definición

            },  new List<string>()
        }
    });
});


//Contexto de la Base de Datos
builder.Services.AddSqlServer<SaturnoContext>(builder.Configuration.GetConnectionString("DataBaseConnection"));

//Capa de servicios
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ProfessionalServices>();
builder.Services.AddScoped<ServiceServices>();
builder.Services.AddScoped<TurnServices>();
builder.Services.AddScoped<LoginService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( builder.Configuration["JWT:Key"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options => {
    options.AddPolicy("SuperAdmin", policy => policy.RequireClaim("Admin Type", "Super"));
});

//CORS POLICY
 builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {

                        policy.WithOrigins("http://localhost:3000");
                        policy.AllowAnyMethod();
                        policy.AllowAnyHeader();
                    });
            });

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
