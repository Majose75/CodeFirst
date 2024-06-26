using CodeFirst.Models;
using CodeFirst.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibreriaContext>();  //Sino se pone nada va a onconfiguring
//builder.Services.AddScoped<IAutorRepositorio, FakeAutorRepositorio>();
//builder.Services.AddScoped<ILibroRepositorio, FakeLibroRepositorio>();
builder.Services.AddScoped<IAutorRepositorio, EFAutorRepositorio>();
builder.Services.AddScoped<ILibroRepositorio, EFLibroRepositorio>();

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
