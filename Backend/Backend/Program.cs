using Infrastructure.ServiceExtension;
using Application.Configuring;
using Backend.Middlware;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddServices();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddRepository();
builder.Services.AddHttpContextAccessor();



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["token"];
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization(options =>
{
     options.AddPolicy("AdminPolicy", policy =>
     {
         policy.RequireClaim("Role",SD.Admin);
     });
     
     options.AddPolicy("EmployeePolicy", policy =>
     {
         policy.RequireClaim("Role",SD.Admin,SD.Employee);
     });
     
     options.AddPolicy("CustomerPolicy", policy =>
     {
         policy.RequireClaim("Role",SD.Customer,SD.Admin,SD.Employee);
     });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}

app.UseMiddleware<ExceptionHandlerMiddlware>();

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
