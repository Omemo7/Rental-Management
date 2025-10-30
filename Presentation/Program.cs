using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Infrastructure;
using RentalManagement.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Application + Infrastructure DI
//builder.Services.AddApplication();  
var cs = builder.Configuration.GetConnectionString("Default")
         ?? throw new InvalidOperationException("Missing connection string 'Default'.");
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(cs));


// 2) Identity (Guid keys) + EF stores
builder.Services.AddIdentityCore<ApplicationUser>(o =>
{
    o.User.RequireUniqueEmail = true;
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<AppDbContext>();

// 3) SignInManager/cookies (ONLY if you use cookie auth)

//builder.Services.AddHttpContextAccessor();
//builder.Services.AddAuthentication().AddIdentityCookies();
//builder.Services.AddAuthorization();

// Controllers (or Minimal APIs, see below)
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers(); // or MapGroup(...) for minimal APIs

app.Run();
