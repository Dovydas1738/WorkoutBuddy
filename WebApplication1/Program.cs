using WorkoutBuddy.Core.Services;
using WorkoutBuddy.Core.Repositories;
using WorkoutBuddy.Core.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>(_ => new UserRepository()); //remove constructor, use using var context
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

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


//void SetupDependencies()
//{
//    builder.Services.AddScoped<IUserRepository, UserRepository>();
//    builder.Services.AddScoped<IUserService, UserService>();
//    builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
//    builder.Services.AddScoped<IExerciseService, ExerciseService>();
//    builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
//    builder.Services.AddScoped<IWorkoutService, WorkoutService>();
//}