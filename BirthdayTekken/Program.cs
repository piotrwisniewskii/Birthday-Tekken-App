using BirthdayTekken.Data;
using BirthdayTekken.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IParticipantService, ParticipantService>();
builder.Services.AddTransient<ITournamentService, TournamentService>();
builder.Services.AddTransient<IMatchService, MatchService>();
builder.Services.AddTransient<Random>();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
