

using BussinessLayer.Services;
using AspNetCoreIdentityApp.Web.ClaimProviders;
using AspNetCoreIdentityApp.Web.Requirements;
using DataAccessLayer.Concrete;
using DataAccessLayer.Models;
using DataAccessLayer.Seeds;
using DataAccessLayer.Services;
using EntityLayer.OptionsModels;
using EntityLayer.PermissionsRoot;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using Pit2mKurumsalWebSiteUI.Extenisons;
using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Abstract;
 
using Pit2mKurumsalWebSiteUI.Mapper;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();


builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.FromMinutes(30); 
});

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddIdentityWithExt();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IClaimsTransformation, UserClaimProvider>();
builder.Services.AddScoped<IAuthorizationHandler, ExchangeExpireRequirementHandler>();
builder.Services.AddScoped<IAuthorizationHandler, ViolenceRequirementHandler>();
builder.Services.AddScoped<IMemberService, MemberService>();

 

builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
builder.Services.AddScoped<IDepartmentDal, EfDepartmentRepository>();

builder.Services.AddScoped<IInstructorService, InstructorManager>();
builder.Services.AddScoped<IInstructorDal, EfInstructorRepository>();
 
builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<IProjectDal, EfProjectRepository>();

builder.Services.AddScoped<IResultService, ResultManager>();
builder.Services.AddScoped<IResultDal, EfResultRepository>();

builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<IStudentDal, EfStudentRepository>();

builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddScoped<ITeamDal, EfTeamRepository>();
 
builder.Services.AddScoped<ILoggerService, LoggerManager>();

builder.Services.AddScoped<IOptimizationService, OptimizationManager>();
builder.Services.AddScoped<IOptimizationDal, EfOptimizationRepository>();

builder.Services.AddScoped<IGraphService, GraphManager>();
builder.Services.AddScoped<IGraphDal, EfGraphRepository>();

builder.Services.AddScoped<IEmptyProjectService, EmptyProjectManager>();
builder.Services.AddScoped<IEmptyProjectDal, EfEmptyProjectRepository>();


// builder.Services.AddAutoMapper(typeof(MappingProfile));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});


IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("AnkaraPolicy", policy =>
    {
        policy.RequireClaim("city", "ankara");
    });

    options.AddPolicy("ExchangePolicy", policy =>
    {
        policy.AddRequirements(new ExchangeExpireRequirement());
    });

    options.AddPolicy("ViolencePolicy", policy =>
    {
        policy.AddRequirements(new ViolenceRequirement() { ThresholdAge = 18 });
    });

    options.AddPolicy("OrderPermissionReadAndDelete", policy =>
    {
        policy.RequireClaim("permission", Permissions.Order.Read);
        policy.RequireClaim("permission", Permissions.Order.Delete);
        policy.RequireClaim("permission", Permissions.Stock.Delete);
    });

    options.AddPolicy("Permissions.Order.Read", policy =>
    {
        policy.RequireClaim("permission", Permissions.Order.Read);
    });

    options.AddPolicy("Permissions.Order.Delete", policy =>
    {
        policy.RequireClaim("permission", Permissions.Order.Delete);
    });

    options.AddPolicy("Permissions.Stock.Delete", policy =>
    {
        policy.RequireClaim("permission", Permissions.Stock.Delete);
    });

});

builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder();

    cookieBuilder.Name = "AppCookie";
    opt.LoginPath = new PathString("/Home/Signin");
    opt.LogoutPath = new PathString("/Member/logout");
    opt.AccessDeniedPath = new PathString("/Member/AccessDenied");
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

    await PermissionSeed.Seed(roleManager);
}


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
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=SignIn}/{id?}");

app.Run();