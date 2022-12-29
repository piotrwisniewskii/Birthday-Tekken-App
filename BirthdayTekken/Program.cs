using BirthdayTekken.Data;
using BirthdayTekken.Repository;
using BirthdayTekken.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Dbcontext configuration
builder.Services.AddDbContext<AppDbContext>(
    options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<IParticipantRepository, ParticipantJsonFileRepository>();
builder.Services.AddTransient<IParticipantService, ParticipantService>();
//builder.Services.AddTransient<ITournamentRepository, TournamentRepository>();
//builder.Services.AddTransient<ITournamentService, TournamentService>();
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



AppDbInitializer.Seed(app);
app.Run();
