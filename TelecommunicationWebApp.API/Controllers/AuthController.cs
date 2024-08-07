﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using TelecommunicationWebApp.API.Core;
using TelecommunicationWebApp.API.DTO;
using TelecommunicationWebApp.API.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelecommunicationWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenCreator _tokenCreator;

        public AuthController(JwtTokenCreator tokenCreator)
        {
            _tokenCreator = tokenCreator;
        }

        // POST api/<AuthController>
        [HttpPost]
        public IActionResult Post([FromBody] AuthRequestDTO request)
        {
            string token = _tokenCreator.Create(request.Email, request.Password);

            return Ok(new AuthResponseDTO { Token = token });
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromServices] ITokenStorage storage)
        {
            storage.Remove(this.Request.GetTokenId().Value);

            return NoContent();
        }
    }
}
