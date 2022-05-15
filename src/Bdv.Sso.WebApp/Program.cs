using Bdv.Authentication;
using Bdv.Authentication.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Token",
        Type = SecuritySchemeType.ApiKey,
        Scheme = BdvAuthenticationConstants.AuthenticationScheme,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Token",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { 
            new OpenApiSecurityScheme
            {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 }
            },
            Array.Empty<string>()
        }
    });
});

//Authentication
builder.Services.AddBdvAuthentication();

//Configure web api
Bdv.Sso.WebApi.Dependencies.Configure(builder.Services, builder.Configuration);

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

app.MapControllers();

app.Run();
