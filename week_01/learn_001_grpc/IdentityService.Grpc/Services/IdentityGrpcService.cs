using Grpc.Core;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Grpc.Services;

public class IdentityGrpcService(UserManager<IdentityUser> userManager)
    : IdentityServiceContract.IdentityServiceContractBase
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    public override async Task<RegisterReply> Register(RegisterRequest request, ServerCallContext context)
    {
        var user = new IdentityUser { UserName = request.Email, Email = request.Email };
        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            return new RegisterReply
            {
                Succeeded = true,
                Message = "User was registered successfully."
            };
        }

        return new RegisterReply
        {
            Succeeded = false,
            Message = string.Join("; ", result.Errors.Select(e => e.Description))
        };
    }

    public override async Task<UserReply> GetUserByEmail(UserByEmailRequest request, ServerCallContext context)
    {
        var user = await _userManager.FindByEmailAsync(request.Email) ?? throw new RpcException(new Status(StatusCode.NotFound, "User not found."));
        return new UserReply
        {
            Id = user.Id,
            Email = user.Email
        };
    }

    public override async Task<UserReply> GetUserById(UserByIdRequest request, ServerCallContext context)
    {
        var user = await _userManager.FindByIdAsync(request.UserId) ?? throw new RpcException(new Status(StatusCode.NotFound, "User not found."));
        return new UserReply
        {
            Id = user.Id,
            Email = user.Email
        };
    }
}