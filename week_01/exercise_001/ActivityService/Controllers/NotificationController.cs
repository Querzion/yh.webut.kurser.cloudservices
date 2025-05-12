using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivityService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController(NotificationServiceContract.NotificationServiceContractClient notificationClient)
    : ControllerBase
{
    private readonly NotificationServiceContract.NotificationServiceContractClient _notificationClient = notificationClient;
    
    
}