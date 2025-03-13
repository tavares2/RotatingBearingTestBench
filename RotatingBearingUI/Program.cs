using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RotatingBearingUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddRazorComponents().AddInteractiveComponents();
//builder.Services.AddSignalR();

// Register the TestService for dependency injection
builder.Services.AddScoped<TestService>();

// Register HttpClient if you need to make API calls from your service
//builder.Services.AddHttpClient();
//builder.Services.AddScoped<HttpClient>(sp =>
//{
//    return new HttpClient { BaseAddress = new Uri("https://localhost:7129") };
//
//});

builder.Services.AddHttpClient<TestService>(client => client.BaseAddress = new Uri(builder.Configuration["https://localhost:7129"]));
// You can register other services you may need for making HTTP requests
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/Host");

app.Run();
