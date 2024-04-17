using Day8Task1.Models;
using Day8Task1.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TraineeContext>(
    op => op.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"))
    );

builder.Services.AddScoped<ITraineeRepository, TraineeRepoService>();
builder.Services.AddScoped<ICourseRepository, CourseRepoService>();
builder.Services.AddScoped<ITrackRepository, TrackRepoService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
