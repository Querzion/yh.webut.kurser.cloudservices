using System.Net;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalIdentityAuthService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterController(IdentityServiceContract.IdentityServiceContractClient identityClient)
    : ControllerBase
{
    private readonly IdentityServiceContract.IdentityServiceContractClient _identityClient = identityClient;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await _identityClient.RegisterAsync(request);
            return result.Succeeded ? Ok(result) : BadRequest(new { error = result.Message });
        }
        catch (RpcException ex)
        {
            // return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            return StatusCode((int) HttpStatusCode.InternalServerError, new { error = ex.Status.Detail });
        }
    }
}