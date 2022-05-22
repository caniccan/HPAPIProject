using HP.Business;
using HP.Business.Mapping;
using HP.DataAccess.Data;
using HP.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using HPAPI.Extensions;
using HPAPI.Middlewares;
using HPAPI.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<ICharacterRepository, EFCharacterRepository>();
builder.Services.AddScoped<IUserRepository, FakeUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<HPDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddCors(opt => opt.AddPolicy("allow", cpb =>
{
    cpb.AllowAnyOrigin();
    cpb.AllowAnyHeader();
    cpb.AllowAnyMethod();
}));

builder.Services.AddMemoryCache();

var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("token:secret").Value));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateActor = true,
                        ValidIssuer = "http//www.kodluyoruz.com",
                        ValidAudience = "http//client.kodluyoruz.com",
                        IssuerSigningKey = key
                    };
                });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCharacterIsExistTestPage();

app.Use((ctx, next) =>
{
    Console.WriteLine($"{ctx.Request.Path} adresinden, {ctx.Request.Method} talebi geldi");
    return next();
});


app.UseCheckIE();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("allow");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
