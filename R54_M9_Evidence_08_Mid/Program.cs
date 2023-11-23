using Microsoft.EntityFrameworkCore;
using R54_M9_Evidence_08_Mid.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DressDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
