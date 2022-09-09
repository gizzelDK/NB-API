using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NB_API.Models;
using NB_API.Services;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
        opts =>
        {
            var enumConverter = new JsonStringEnumConverter();
            opts.JsonSerializerOptions.Converters.Add(enumConverter);
            /// Forhinder cirkulære cycles, når der hentes lister
            opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
          //  opts.JsonSerializerOptions.PropertyNamingPolicy = null; // prevent camel case
        });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<ICryptoService, CryptoService > ();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
    builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowCredentials()
               .AllowAnyHeader()
               .AllowAnyMethod(); // kun get eller put mm.
    });
});
var nbConnectionString = builder.Configuration.GetConnectionString("NBDbConnection");
//var enumConverter = new JsonStringEnumConverter();

builder.Services.AddDbContext<NBDBContext>(options =>

options.UseSqlServer(nbConnectionString));
// Configure the HTTP request pipeline.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Security:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyAllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
