using Clicksign.Exemplo.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Clicksign.Exemplo.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}")]
    [Produces("application/json")]
    [ExcludeFromCodeCoverage]
    public class ClicksignCallbackController : Controller
    {
        [HttpPost("clicksign/event-received")]
        [ProducesResponseType(typeof(ClickSignEventRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostClickSignUpdate(ClickSignEventRequest request, CancellationToken cancellationToken)
        {
            //faz algo com o evento recebido

            return Ok(request);
        }
    }
}
