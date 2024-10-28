using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BlogsAPI.Controllers
{
    [Route("error/puja")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private ILogger _logger;
        public ErrorController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ErrorController>();
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> HandleError()
        {
            if (HttpContext != null)
            {
                IExceptionHandlerPathFeature feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                if (feature != null)
                {
                    //Log the error to app insights/file
                    _logger.LogCritical(feature.Error.Message);
                    return Problem(detail: feature.Error.Message);
                }
            }
            return Problem();
        }
    }
}

