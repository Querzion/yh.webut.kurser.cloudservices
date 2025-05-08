using Grpc.Core;
using gRPC_Server;

namespace gRPC_Server.Services;

public class GreeterService(ILogger<GreeterService> logger) : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger = logger;

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<FullNameReply> GetFullName(FullNameRequest request, ServerCallContext context)
    {
        return Task.FromResult(new FullNameReply
        {
            FullName = $"{request.FirstName} {request.LastName}"
        });
    }
}