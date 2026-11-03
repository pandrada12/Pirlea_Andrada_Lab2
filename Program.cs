using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pirlea_Andrada_Lab2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// 1. Contextul principal pentru carti, membri, imprumuturi etc.
builder.Services.AddDbContext<Pirlea_Andrada_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pirlea_Andrada_Lab2Context")
        ?? throw new InvalidOperationException("Connection string 'Pirlea_Andrada_Lab2Context' not found.")));

// 2. Contextul separat pentru Identity (autentificare si conturi utilizatori)
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pirlea_Andrada_Lab2Context")
        ?? throw new InvalidOperationException("Connection string 'Pirlea_Andrada_Lab2Context' not found.")));

// 3. Serviciul de Identity configurat cu LibraryIdentityContext si IdentityUser
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // Important: adaugat inainte de UseAuthorization pentru autentificare
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();