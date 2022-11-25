global using FastEndpoints;
global using FluentValidation;
global using FastEndpoints.Security;
using FastEndpoints.Swagger;
using taragonapi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddAuthenticationJWTBearer("ASDASDSADSADSADAD!");
builder.Services.AddSwaggerDoc(maxEndpointVersion: 1, settings: s =>
{
  s.DocumentName = "Initial Release 1.0";
  s.Title = "taragon api";
  s.Version = "v1.0";
});

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints(c =>
{
  c.Versioning.Prefix = "v";
  c.Endpoints.RoutePrefix = "api";
});
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());
app.Run();
