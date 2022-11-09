using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using store_management_api.Data.Repository.implementations;
using store_management_api.Data.Repository.Interfaces;
using store_management_api.Helpers;
using System.Text;
using static store_management_api.Data.implementations.ProdRepository;
using static store_management_api.Data.Repository.implementations.UbicRepository;
using static store_management_api.Data.Repository.implementations.UsuarioRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
        setupAction.AddSecurityDefinition("StoreManagementApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
        {
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            Description = "Ac� pegar el token generado al loguearse."
        });

        setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "StoreManagementApiBearerAuth"
                    } //Tiene que coincidir con el id seteado arriba en la definici�n
                }, new List<string>()
            }
        });
});
builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de auntenticaci�n que tenemos que elegir despu�s en PostMan para pasarle el token
    .AddJwtBearer(options => //Ac� definimos la configuraci�n de la autenticaci�n. le decimos qu� cosas queremos comprobar. La fecha de expiraci�n se valida por defecto.
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);

#region Injection
builder.Services.AddSingleton<IProductoRepository, ProductoRepository>();
builder.Services.AddSingleton<IUsuarioRepository, UsuariosRepository>();
builder.Services.AddSingleton<IUbicacionRepository, UbicacionRepository>();
#endregion

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
