using MvcWebAppTwo.SingleInterfaceMultiInstances;
using MvcWebAppTwo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();
builder.Services.AddScoped<IMobileService, MobileService>();

builder.Services.AddScoped<IDatabaseService, SqlService>();
builder.Services.AddScoped<IDatabaseService, MongoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TransientScoped}/{action=Create}/{id?}");

app.Run();
