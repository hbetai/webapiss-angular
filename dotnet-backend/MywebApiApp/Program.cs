var builder = WebApplication.CreateBuilder(args);

// ✅ Force HTTP-only to avoid HTTPS cert issues
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5245); // HTTP only
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ❌ Disable HTTPS redirection to prevent errors
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();