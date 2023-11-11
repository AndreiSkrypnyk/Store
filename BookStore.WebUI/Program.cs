using BookStore.Application.Interfaces;
using BookStore.Application.Managers;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BookStore.Application.DTOs;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Repositories;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookStoreCodeFirstDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBookRepository<Book>, BookRepository>();
builder.Services.AddScoped<IBookManager, BookManager>();
builder.Services.AddAutoMapper(typeof(BookMappingProfile));
builder.Services.AddScoped<IAccountRepository<User>, AccountRepository>();
builder.Services.AddScoped<IAccountManager, AccountManager>();
builder.Services.AddAutoMapper(typeof(BookMappingProfile));

builder.Services.AddAuthentication("Cookie")
    .AddCookie("Cookie", config =>
    {
        config.LoginPath = "/Account/Login";
        config.AccessDeniedPath = "/Account/AccessDenied";
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", builder =>
    {
        //builder.RequireClaim(ClaimTypes.Role, "Administrator");
        builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Name, "Admin") );
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
