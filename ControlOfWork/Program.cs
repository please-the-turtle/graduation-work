using MudBlazor.Services;
using BuisnessLogicLayer;
using DataAccessLayer.PostgreSQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMudServices();
builder.Services.AddServerSideBlazor();

builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

IConfigurationRoot configuration = GetConfiguration();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

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