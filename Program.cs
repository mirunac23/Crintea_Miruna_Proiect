using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Crintea_Miruna_Proiect.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OrganizerPolicy", policy =>
   policy.RequireRole("Organizer"));
    options.AddPolicy("TechnicalPolicy", policy =>
   policy.RequireRole("Technical"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Skaters", "OrganizerPolicy");
    options.Conventions.AuthorizeFolder("/Elements", "TechnicalPolicy");
    options.Conventions.AuthorizeFolder("/Coaches", "OrganizerPolicy");
    options.Conventions.AuthorizeFolder("/SkatingClubs");
    options.Conventions.AllowAnonymousToPage("/Skaters/Index");
});
builder.Services.AddDbContext<Crintea_Miruna_ProiectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Crintea_Miruna_ProiectContext") ?? throw new InvalidOperationException("Connection string 'Crintea_Miruna_ProiectContext' not found.")));
builder.Services.AddDbContext<ProiectIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Crintea_Miruna_ProiectContext") ?? throw new InvalidOperationException("Connection string 'Crintea_Miruna_ProiectContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ProiectIdentityContext>();

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
