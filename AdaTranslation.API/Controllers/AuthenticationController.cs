using AdaTranslation.Application.Services;
using AdaTranslation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger,  AuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

       
    }
}
