using RentalManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Application + Infrastructure DI
//builder.Services.AddApplication();                 // your extension in Application
builder.Services.AddInfrastructure(builder.Configuration); // your extension in Infrastructure

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
app.MapControllers(); // or MapGroup(...) for minimal APIs

app.Run();
