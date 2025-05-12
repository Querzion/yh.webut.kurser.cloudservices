using Contracts;
using Server.Services;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

// Register the service first before adding any endpoints
app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<NameService>(); // Register service here

    // Add HTTPS endpoint
    serviceBuilder.AddServiceEndpoint<NameService, INameService>(
        new BasicHttpBinding(BasicHttpSecurityMode.Transport),
        new Uri("https://localhost:80/nameservice")
    );

    // Add Net.TCP endpoint
    serviceBuilder.AddServiceEndpoint<NameService, INameService>(
        new NetTcpBinding(SecurityMode.None),
        new Uri("net.tcp://localhost:8090/nameservice")
    );

    // Metadata endpoint
    var smb = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    smb.HttpsGetEnabled = true;
    smb.HttpsGetUrl = new Uri("https://localhost:80/nameservice?wsdl");

    serviceBuilder.AddServiceEndpoint<IMetadataExchange>(
        typeof(IMetadataExchange),
        new BasicHttpBinding(BasicHttpSecurityMode.Transport),
        new Uri("https://localhost:80/mex")
    );
});

app.Run();