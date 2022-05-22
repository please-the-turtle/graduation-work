using BuisnessLogicLayer.Users;
using BuisnessLogicLayer.Projects;
using PresentationLayer.Blazor.Infrastructure;
using DataAccessLayer.PostgreSQL;
using DataAccessLayer.PostgreSQL.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMudServices();
builder.Services.AddServerSideBlazor();

IConfigurationRoot configuration = GetConfiguration();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();

builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ProjectService>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

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
app.MapFallbackToPage("/_Host");

app.Run();

static IConfigurationRoot GetConfiguration()
{
    var configurationBuilder = new ConfigurationBuilder();
    configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
    configurationBuilder.AddJsonFile("appsettings.json");
    var configuration = configurationBuilder.Build();

    return configuration;
}