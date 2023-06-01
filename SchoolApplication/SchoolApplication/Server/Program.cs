global using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ResponseCompression;

using SchoolApplication.Server.Data;
using SchoolApplication.Server.InjectServices;
using SchoolApplication.Server.IPschoolsRepository;
using SchoolApplication.Server.PschoolsRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//builder.Services.AddScoped<IStudentRepository, StudentRepository>();
//builder.Services.AddScoped<IParentRepository, ParentRepository>();
#region DB Connection

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefualtConnection")));
new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


#endregion
#region Service Bindings
// you can inject in class file "ServiceBinding" inside Folder "InjectProviders"
object value = builder.Services.InjectServices();
#endregion

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
