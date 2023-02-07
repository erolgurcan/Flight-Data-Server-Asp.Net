using flight_data_server.Database;
using flight_data_server.Interface;
using flight_data_server.Services.DBFunctions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using flight_data_server.Services.UserFunctions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


Log.Logger = new LoggerConfiguration().MinimumLevel
    .Debug()
    .WriteTo.File("log/airliner_debug.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddDbContext<AirlinerDBContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("FlightDB"));
});

builder.Services.AddScoped<IAirlinerDBFunctions, AirlinerDBFunctions>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.Authority = "https://localhost:7003/";
        x.TokenValidationParameters = new TokenValidationParameters
            {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
            };
    });

builder.Services.AddSwaggerGen(

    options =>
{
    options.AddSecurityDefinition(
        "Bearer",
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
            Description =
                "JWT Authorization header using the Bearer scheme. \r\n\r\n "
                + "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n"
                + "Example: \"Bearer 12345abcdef\"",
            Name = "Authorization",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Scheme = "Bearer"
            });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });

}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
    app.UseSwagger();
    app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
