using Microsoft.EntityFrameworkCore;
using MyAppData;
using MyAppData.Data;
using MyAppData.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<SystemDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("AlwaysDataConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("AlwaysDataConnection")!
         )));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

//Services métier
builder.Services.AddScoped<IGroupeEtudeService, GroupeEtudeService>();
builder.Services.AddScoped<ICoursService, CoursService>();
builder.Services.AddScoped<IEtudiantService, EtudiantService>();
builder.Services.AddScoped<IDisponibiliteService, DisponibiliteService>();
builder.Services.AddScoped<ILocalService, LocalService>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.UseAntiforgery();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorComponents<MyBlazorLib.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();