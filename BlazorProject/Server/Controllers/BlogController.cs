using BlazorProject.Server.Models;
using BlazorProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Controllers
{    
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository blogRepository;
        private readonly IConfiguration configuration;

        public BlogController(IBlogRepository _blogRepository, IConfiguration _configuration)
        {
            blogRepository = _blogRepository;
            configuration = _configuration;
        }

        [Route("view/[controller]/all")]
        [HttpGet]
        public async Task<ActionResult<Blog>> GetBlogs()
        {

            try
            {
                var result = await blogRepository.GetBlogs();

                if (result == null)
                {
                    return NotFound("Blog not found");
                }

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [Route("view/[controller]/paginated")]
        [HttpGet]
        public async Task<ActionResult<BlogsDTO>> GetPaginatedBlogs(
            [FromQuery]string p,[FromQuery] string s)
        {
            int.TryParse(p, out int pagenum);
            int.TryParse(s, out int pagesize);

            try
            {
                var result = await blogRepository.GetPaginatedBlogs(pagenum, pagesize);

                if (result == null)
                {
                    return NotFound("Blog not found");
                }

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving paginated blogs from the database");
            }

        }

        [Route("view/[controller]/{id}")]
        [HttpGet("{id:int}")]
        public async Task<ResponseDTO> GetBlog(int id)
        {
            ResponseDTO rdto = new ResponseDTO();

            try
            {
                var result = await blogRepository.GetBlog(id);
                
                if(result == null)
                {
                    rdto.StatusCode = 404;
                    rdto.Message = "Blog not found";
                    rdto.Data = null;
                    return rdto;
                    //return NotFound("Blog not found");                    
                }

                rdto.StatusCode = 200;
                rdto.Message = "";
                rdto.Data = result;
                rdto.DataType = "Blog";
                return rdto;
                //return Ok(result);
            }
            catch (Exception)
            {
                rdto.StatusCode = 500;
                rdto.Message = "Error retrieving data from the database";
                rdto.Data = null;
                return rdto;

                //return StatusCode(StatusCodes.Status500InternalServerError,
                //  "Error retrieving data from the database");
            }           

        }

        [Route("api/[controller]/GetBlogsByUserid")]
        [HttpPost]
        public async Task<ResponseDTO> GetBlogsByUserid([FromBody] string userid)
        {

            //var desdata = JsonConvert.DeserializeObject(userid.ToString());
            ResponseDTO rdto = new ResponseDTO();

            int.TryParse(userid, out int id);
            if(id == 0) 
            {
                rdto.StatusCode = 400;
                rdto.Message = "Userid not valid";
                return rdto;
            }

            try
            {
                var result = await blogRepository.GetBlogsByUserid(id);

                if (result == null)
                {
                    rdto.StatusCode = 404;
                    rdto.Message = "Blog not found";
                    return rdto;
                }

                rdto.StatusCode = 200;
                rdto.Message = "";
                rdto.Data = result;

                return rdto;
            }
            catch (Exception)
            {
                rdto.StatusCode = 500;
                rdto.Message = "Error retrieving data for GetBlogByUserid() from the database";
                rdto.Data = null;
                return rdto;
                
            }

        }

        [Route("api/[controller]/createblog")]
        [HttpPost]
        public async Task<ResponseDTO> CreateBlog([FromBody]Blog blog)
        {

            ResponseDTO rdto = new ResponseDTO();

            if (blog == null)
            {
                //return BadRequest();
                rdto.StatusCode = 400;
                rdto.Message = "Bad request, data missing.";
                rdto.Data = null;

                return rdto;
            }

            DateTime dt = DateTime.Now;
            blog.CreatedAt = dt;
            blog.UpdatedAt = dt;
             
            int.TryParse(Request.Headers["userid"].ToString(), out int userid);
            blog.UserId = userid;
            
            try
            {              

                var createdBlog = await blogRepository.AddBlog(blog);

                rdto.StatusCode = 201;
                rdto.Message = "Created";
                rdto.Data = createdBlog;

                return rdto;

                //return Created("", createdBlog);
                //return CreatedAtAction(nameof(GetBlog),
                  //  new { id = createdBlog.BlogId }, createdBlog);
            }
            catch (Exception)
            {
                rdto.StatusCode = 500;
                rdto.Message = "Error creating new blog record";
                rdto.Data = null;

                return rdto;
                //return StatusCode(StatusCodes.Status500InternalServerError,
                  //  "Error creating new blog record");
            }
        }
         
        [Route("/api/[controller]/updateblog")]                
        [HttpPut]
        public async Task<ResponseDTO> UpdateBlog([FromBody] Blog blog)
        {
            ResponseDTO rdto = new ResponseDTO();
            
            int.TryParse(Request.Headers["userid"].ToString(),out int userid);
            if(blog.UserId != userid)
            {
                rdto.StatusCode = 400;
                rdto.Message = "It seems you are not the author of this blog.";
                rdto.Data = null;
                return rdto;
                //return BadRequest("It seems you are not the author of this blog.");
            }
            Blog updatedblog;            
            try
            {                
                var blogToUpdate = await blogRepository.GetBlog(blog.BlogId);

                if (blogToUpdate == null)
                {
                    rdto.StatusCode = 404;
                    rdto.Message = "Not found.";
                    rdto.Data = null;
                    return rdto;
                    //return NotFound($"Blog with Id = {blog.BlogId} not found");
                }

                updatedblog = await blogRepository.UpdateBlog(blog);
                rdto.StatusCode = 200;
                rdto.Message = "";
                rdto.Data = updatedblog;
                return rdto;
                //return Ok(updatedblog);
            }
            catch (Exception)
            {
                rdto.StatusCode = 500;
                rdto.Message = "Error updating blog.";
                rdto.Data = null;
                return rdto;
                //return StatusCode(StatusCodes.Status500InternalServerError,
                  //  "Error updating blog.");
            }
        }

        [Route("/api/blog/deleteblog/{id}")]
        [HttpDelete("{id:int}")]
        public async Task<ResponseDTO> DeleteEmployee(int id)
        {
            ResponseDTO rdto = new ResponseDTO();
            int result = 0;
            try
            {
                var blogToDelete = await blogRepository.GetBlog(id);

                if (blogToDelete == null)
                {
                    rdto.StatusCode = 404;
                    rdto.Message = "Not found.";
                    rdto.Data = null;
                    return rdto;
                    //return NotFound($"Blog with Id = {id} not found");
                }

                result = await blogRepository.DeleteBlog(id);
                if (result > 0)
                {
                    rdto.StatusCode = 200;
                    rdto.Message = $"Blog with Id = {id} deleted";
                    rdto.Data = null;
                    return rdto;
                    //return Ok($"Blog with Id = {id} deleted");
                }
                else
                {
                    rdto.StatusCode = 500;
                    rdto.Message = "Error, please try again.";
                    rdto.Data = null;
                    return rdto;
                    //return BadRequest();
                }
            }
            catch (Exception)
            {
                rdto.StatusCode = 500;
                rdto.Message = "Error deleting blog record.";
                rdto.Data = null;
                return rdto;

                //return StatusCode(StatusCodes.Status500InternalServerError,
                  //  "Error deleting blog record");
            }
        }

        [Route("search/[controller]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> SearchBlog([FromQuery] string q)
        {
            try
            {
                var result = await blogRepository.SearchBlogs(q);

                if (result == null)
                {
                    return NotFound("Blog not found");
                }

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data for search result from the database");
            }

        }
    }
}
