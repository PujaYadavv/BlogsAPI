using BlogsServices.Core.Interfaces;
using BlogsServices.Core.Models;
using Microsoft.AspNetCore.Mvc;
namespace BlogsAPI.Controllers
{
    [Route("api/v1/writers")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private IWriterServices _writerServices;
        private ILogger _logger;
        public WriterController(IWriterServices writerServices ,ILoggerFactory loggerFactory) 
        {
            _writerServices = writerServices;
            _logger = loggerFactory.CreateLogger<WriterController>();

        }
        [HttpGet]
        public async Task<IActionResult> GetAllWriter()
        {
            _logger.LogError("someone asked for writer list's...");
            List<Writer> writer = await _writerServices.GetAllWriter();
            if (writer != null)
            {
                return Ok(writer);
            }
            return NoContent();
        }
        
        [HttpGet("{id}")]
        public async Task <IActionResult> GetWriter(int id)
        {
            Writer writer = await _writerServices.GetWriter(id);
            if (writer != null)
            {
                return Ok(writer);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task <IActionResult> CreateWriter(Writer writer)
        {
            bool result=await _writerServices.CreateWriter(writer);
            if (result)
            {
                return Ok(result);

            }
            return BadRequest(writer);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWriter(Writer writer)
        {
            bool result = await _writerServices.UpdateWriter(writer);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(writer);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteWriter(int id)
        {
            bool result = await _writerServices.DeleteWriter(id);
            if (result)
            {
                return Ok(result);

            }
            return BadRequest();
        }
    }
}
