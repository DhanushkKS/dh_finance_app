using Microsoft.AspNetCore.Mvc;

namespace aquaFin.API.Controllers;

[ApiController]
[Route( BaseApiPath+"/[controller]")]
public class ApiControllerBase:ControllerBase
{
    private const string BaseApiPath = "/api";
    
}