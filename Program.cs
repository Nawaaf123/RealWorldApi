var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger ALWAYS (DevOps apps need it in Docker)
app.UseSwagger();
app.UseSwaggerUI();

// ❌ IMPORTANT: Disable HTTPS redirect (Docker has no HTTPS cert)
 // app.UseHttpsRedirection();   // <-- REMOVE OR COMMENT THIS

app.UseAuthorization();

app.MapControllers();

app.MapGet("/version", () =>
{
    return new { version = "v5", time = DateTime.Now.ToString() };
});

app.Run();
