using Microsoft.Extensions.Options;
using MyStore.UI.Models;
using MyStore.UI.Services;
using Microsoft.EntityFrameworkCore;
using MyStore.UI.Data;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Identity;
using MyStore.UI.Areas.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var endpoints = builder.Configuration.GetSection("Endpoints").Get<Endpoints>();

var dbUsers = builder.Configuration.GetConnectionString("Users");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(dbUsers));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();



builder.Services.AddHttpClient("default",
    (c) =>
    {
        c.BaseAddress = new Uri(endpoints.BaseUrl);
    });

builder.Services.AddScoped<IOptions<Endpoints>>(_ => new OptionsWrapper<Endpoints>(endpoints));
builder.Services.AddScoped<IProductsServiceProxy, ProductsServiceProxy>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();