using Kenouz.Controllers.Helper;
using Kenouz.Data;
using Kenouz.Models;
using Kenouz.Models.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IKenouzRepo<ClassYear>, ClassYearRepo>();
builder.Services.AddScoped<IKenouzRepo<PdfQuiz>, PdfQuizRepo>();
builder.Services.AddScoped<IKenouzRepo<QuizPerLessonC>, QuizPerLessonCRepo>();
builder.Services.AddScoped<IKenouzRepo<QuizPerLessonCU>, QuizPerLessonCURepo>();
builder.Services.AddScoped<IKenouzRepo<QuizPerLessonCUL>, QuizPerLessonCULRepo>();
builder.Services.AddScoped<IKenouzRepo<QuizPerLessonCULQ>, QuizPerLessonCULQRepo>();
builder.Services.AddScoped<IKenouzRepo<RateYourselfQuiz>, RateYourselfQuizRepo>();
builder.Services.AddScoped<IKenouzRepo<RateYourselfQuizS>, RateYourselfQuizSRepo>();
builder.Services.AddScoped<IKenouzRepo<RateYourselfQuizSQ>, RateYourselfQuizSQRepo>();
builder.Services.AddScoped<IKenouzRepo<TeachingC>, TeachingCRepo>();
builder.Services.AddScoped<IKenouzRepo<TeachingCU>, TeachingCURepo>();
builder.Services.AddScoped<IKenouzRepo<TeachingCUL>, TeachingCULRepo>();
builder.Services.AddScoped<IClassYearRepo, ClassYearRepo>();
builder.Services.AddScoped<ITeachingCRepo, TeachingCRepo>();
builder.Services.AddScoped<ITeachingCULRepo, TeachingCULRepo>();
builder.Services.AddScoped<IQuizPerLessonCRepo, QuizPerLessonCRepo>();
builder.Services.AddScoped<IQuizPerLessonCULRepo, QuizPerLessonCULRepo>();
builder.Services.AddScoped<IQuizPerLessonCULQRepo, QuizPerLessonCULQRepo>();
builder.Services.AddScoped<IRateYourselfQuizRepo, RateYourselfQuizRepo>();
builder.Services.AddScoped<IRateYourselfQuizSRepo, RateYourselfQuizSRepo>();
builder.Services.AddScoped<IPdfQuizRepo, PdfQuizRepo>();
builder.Services.AddScoped<Logged_in_Users_DbContext>();

builder.Services.AddSingleton<ITest, Test>();

builder.Services.AddScoped<CheckCode>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<KenouzDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<Logged_in_Users_DbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
    {
        options.Cookie.HttpOnly = true; // Prevent JavaScript from accessing the cookie
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Only over HTTPS
        options.Cookie.SameSite = SameSiteMode.Strict; // Protect against CSRF
        options.ExpireTimeSpan = TimeSpan.FromDays(30); // 30 days
        options.SlidingExpiration = true; // refreshes the cookieTime when the user make a new request
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
