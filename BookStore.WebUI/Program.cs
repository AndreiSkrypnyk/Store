using BookStore.Application.Interfaces;
using BookStore.Application.Managers;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BookStore.Application.DTO_s;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookStoreCodeFirstDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBookRepository<Book>, BookRepository>();
builder.Services.AddScoped<IBookManager, BookManager>();
builder.Services.AddAutoMapper(typeof(BookMappingProfile));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
