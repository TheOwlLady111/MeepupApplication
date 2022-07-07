using Business.Additional;
using Business.Extensions;
using Data;
using FluentValidation.AspNetCore;
using MeetupApp.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile("jwtsettings.json").Build();
builder.Services.AddDbContext<MeetupAppDatabaseContext>(options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddJwtBearerAuth(builder.Configuration.GetSection(JwtOptions.Jwt).Get<JwtOptions>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
   {
       option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
       {
           Name = "Authorization",
           Type = SecuritySchemeType.ApiKey,
           Scheme = "Bearer",
           BearerFormat = "JWT",
           In = ParameterLocation.Header,
           Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
       });

       option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
             new string[] {}
            }
        });
   }
    );
builder.Services.AddAutoMapper(typeof(Program)).AddBusinessLayerMapper();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddPasswordHasher();
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(typeof(Program).Assembly));
builder.Services.AddPoliciesService();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.Jwt));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().
    UseSwaggerUI((c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeetupApp");
    }));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
