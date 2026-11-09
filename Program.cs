using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pirlea_Andrada_Lab2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/PublisherPages", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/CategoryPages", "AdminPolicy");
});

builder.Services.AddDbContext<Pirlea_Andrada_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pirlea_Andrada_Lab2Context")
        ?? throw new InvalidOperationException("Connection string 'Pirlea_Andrada_Lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pirlea_Andrada_Lab2Context")
        ?? throw new InvalidOperationException("Connection string 'Pirlea_Andrada_Lab2Context' not found.")));

builder.Services.AddDefaultIdentity<Pirlea_Andrada_Lab2.Data.ApplicationUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

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