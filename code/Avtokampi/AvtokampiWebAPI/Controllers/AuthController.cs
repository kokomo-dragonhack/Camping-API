using AvtokampiWebAPI.Models.AuthAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using AvtokampiWebAPI.Services.Auth;

namespace AvtokampiWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        /// <summary>
        ///     Prijava uporabnika
        /// </summary>
        /// <returns>JWT Token</returns>
        /// <response code="200">Response JWT Token</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="401">Unauthorized</response>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> RequestToken([FromBody] TokenDto request)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}

                var result = await _authService.IsAuthenticated(request);
                if (result.Item1)
                {
                    return Ok(new {token = result.Item2});
                }

                return Unauthorized(
 /*new ErrorHandlerModel("Napačno uporabniško ime ali geslo", HttpStatusCode.Unauthorized)*/);
            }
            catch (Exception e)
            {
                _logger.LogError("RequestToken Auth Unhandled exception ...", e);
                return BadRequest( /*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Registracija uporabnika
        /// </summary>
        /// <returns>Boolean value</returns>
        /// <response code="201">Successfully register user</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="401">Unauthorized</response>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> RequestRegister([FromBody] RegisterDto user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _authService.IsRegister(user);
                if (result == false)
                {
                    return BadRequest();
                }

                return Created("/auth/login", result);
            }
            catch (Exception e)
            {
                _logger.LogError("RequestRegister Auth Unhandled exception ...", e);
                return BadRequest(e /*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }
    }
}