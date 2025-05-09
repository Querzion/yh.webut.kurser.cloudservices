using LocalIdentityAuthService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddGrpcClient<IdentityServiceContract.IdentityServiceContractClient>(x =>
{
    x.Address = new Uri("https://localhost:7298");
});

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();