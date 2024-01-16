using BookStore.Application.Interfaces;
using BookStore.Application.Managers;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BookStore.Application.DTOs;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using BookStore.Infrastructure.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookStoreCodeFirstDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<BookStoreCodeFirstDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.AddScoped<IBookRepository<Book>, BookRepository>();
builder.Services.AddScoped<IBookManager, BookManager>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(BookMappingProfile));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
