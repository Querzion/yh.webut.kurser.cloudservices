var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddCors(x =>
{
    x.AddPolicy("AllowAll", x =>
    {
        x.AllowAnyOrigin();
        // Allow specific origin
        // x.WithOrigins("https://domain.com");
        x.AllowAnyHeader();
        x.AllowAnyMethod();
        // These can be adjusted to have limitations with the with instead.
        // x.WithMethods("GET, POST");
    });
});

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();