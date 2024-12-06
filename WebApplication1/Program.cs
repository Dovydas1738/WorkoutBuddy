using WorkoutBuddy.Core.Services;
using WorkoutBuddy.Core.Repositories;
using WorkoutBuddy.Core.Contracts;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkoutBuddy API", Version = "v1" });

    // Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTczMzQ5MDQxNiwiaWF0IjoxNzMzNDkwNDE2fQ.Ji2AKx2yIhPa8Ht5ISb52O4mXLmSh4faN_pq1Y78co4"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>(_ => new UserRepository());
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>(_ => new ExerciseRepository());
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IExerciseLogRepository, ExerciseLogRepository>(_ => new ExerciseLogRepository());
builder.Services.AddScoped<IExerciseLogService, ExerciseLogService>();
builder.Services.AddScoped<IWorkoutTemplateRepository, WorkoutTemplateRepository>(_ => new WorkoutTemplateRepository());
builder.Services.AddScoped<IWorkoutTemplateService, WorkoutTemplateService>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>(_ => new WorkoutRepository());
builder.Services.AddScoped<IWorkoutService, WorkoutService>();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkoutBuddy API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//void SetupDependencies()
//{
//    builder.Services.AddScoped<IUserRepository, UserRepository>();
//    builder.Services.AddScoped<IUserService, UserService>();
//    builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
//    builder.Services.AddScoped<IExerciseService, ExerciseService>();
//    builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
//    builder.Services.AddScoped<IWorkoutService, WorkoutService>();
//}