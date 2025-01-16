using WalkerAdvertisingLead.Server.BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddSingleton<LeadManagement>(); // Add Lead Managaement service

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()  // Allow all origins (CORS will be open for all)
            .AllowAnyMethod()    // Allow any HTTP method (GET, POST, etc.)
            .AllowAnyHeader();   // Allow any HTTP header
    });
});

builder.Services.AddControllers()
    .AddDataAnnotationsLocalization(); // Enables validation for annotations

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAllOrigins"); // Use the CORS policy

app.UseAuthorization();
app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
