using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelecommunicationWebApp.Application.DTO;
using TelecommunicationWebApp.Application.UseCases.Commands.IssueDiscount;
using TelecommunicationWebApp.DataAccess;
using TelecommunicationWebApp.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelecommunicationWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueDiscountController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public IssueDiscountController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // POST: api/<IssueDiscountController>
        [Authorize]
        [HttpPost]
        public IActionResult Get([FromBody] IssueDiscountDTO dto, [FromServices] IIssueDiscountCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

    }
}
