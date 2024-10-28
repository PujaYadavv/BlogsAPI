using BlogsServices.Core.Interfaces;
using BlogsServices.Core.Models;
using Microsoft.AspNetCore.Mvc;
namespace BlogsAPI.Controllers
{
    [Route("api/v1/writer/{writerId}/blogs")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlogsServices _blogServices;
        public BlogController(IBlogsServices blogServices)
        {
            _blogServices = blogServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs(int writerId)
        {
            List<Blogs> blogs = await _blogServices.GetAllBlogs(writerId);
            if (blogs != null)
            {
                return Ok(blogs);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogs(int writerId ,int id)
        {
            Blogs blogs = await _blogServices.GetBlogs(writerId,id);
            if (blogs != null)
            {
                return Ok(blogs);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogs(int writerId, Blogs blogs)
        {
            bool result  = await _blogServices.CreateBlogs(writerId, blogs);
            if(result)
            {
                return Created(string.Empty, string.Empty);
            }
            return BadRequest();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlogs(int writerId,Blogs blogs)
        {
            bool result = await _blogServices.UpdateBlogs(writerId,blogs);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteBlogs(int writerId,int id)
        {
            bool result = await _blogServices.DeleteBlogs(writerId,id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();

        }
            

    }
}
