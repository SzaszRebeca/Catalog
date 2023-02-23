using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Catalog.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
//builder.Services.AddDbContext<CatalogContext>(options =>
//  options.UseSqlServer(builder.Configuration.GetConnectionString("CatalogContext") ?? throw new InvalidOperationException("Connection string 'CatalogContext' not found.")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//  .AddEntityFrameworkStores<LibraryIdentityContext>();

//builder.Services.AddDbContext<LibraryIdentityContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("CatalogContext") ?? throw new InvalidOperationException("Connection string 'CatalogContex' not found.")));
//builder.Services.AddDefaultIdentity<IdentityUser>(options =>
//options.SignIn.RequireConfirmedAccount = true)
//.AddRoles<IdentityRole>()
//.AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Note");
    options.Conventions.AllowAnonymousToPage("/Note/Index");
    options.Conventions.AllowAnonymousToPage("/Note/Details");
});
builder.Services.AddDbContext<CatalogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CatalogContext") ?? throw new InvalidOperationException("Connection string 'CatalogContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CatalogContext") ?? throw new InvalidOperationException("Connection string 'CatalogContex' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
 .AddRoles<IdentityRole>()
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
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
