using DataBaseConnector;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using rXCompanionApp.Areas.Identity;
using rXCompanionApp.Data;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

CultureInfo culture = CultureInfo.CreateSpecificCulture("es-CR");
CultureInfo cultureUI = System.Globalization.CultureInfo.CreateSpecificCulture("es");
System.Threading.Thread.CurrentThread.CurrentCulture = culture;
System.Threading.Thread.CurrentThread.CurrentUICulture = cultureUI;

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	List<CultureInfo> cultures = new List<CultureInfo> { culture, cultureUI };
	options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(culture);
	options.SupportedCultures = cultures;
	options.SupportedUICultures = cultures;
});





// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'Default' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<ISQLDataAccess, SQLDataAccess>();
builder.Services.AddSingleton<DataBase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseRequestLocalization();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
