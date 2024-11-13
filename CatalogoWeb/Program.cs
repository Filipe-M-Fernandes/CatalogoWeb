using CatalogoWeb.Api.Extensions;
using CatalogWeb.Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddConsole();

string allowSpecificOrigins = "_allowSpecificOrigins";
builder.Services.AddDefaultCorsPolicy(allowSpecificOrigins);
builder.Services.AddDbContext<CatalogoDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.RegistrarApplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
}).AddValidators();

builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    options.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddJwtAuthentication(builder.Configuration.GetSection("JWT"));
builder.Services.AddSwagger();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(allowSpecificOrigins);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
