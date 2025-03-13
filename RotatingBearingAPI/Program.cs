using Microsoft.EntityFrameworkCore;
using RotatingBearingAPI.Data;
using RotatingBearingAPI.Repositories;
using RotatingBearingAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Entity Framework Core with SQL Server Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));


builder.Services.AddScoped<ITestSequenceRepository, TestSequenceRepository>();
builder.Services.AddScoped<ITestSequenceService, TestSequenceService>();
builder.Services.AddScoped<ITestResultRepository, TestResultRepository>();
builder.Services.AddScoped<ITestResultService, TestResultService>();


// Enable CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowUI", policy =>
//    {
//        policy.WithOrigins("https://localhost:7108") // Allow the UI to connect from this port
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

var app = builder.Build();

// HTTP request pipeline Configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Apply the CORS policy
app.UseCors("AllowUI"); // Use the policy you defined above
app.MapControllers();

app.Run();
