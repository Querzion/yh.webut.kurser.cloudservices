using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Grpc.Data;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext(options)
{
    
}