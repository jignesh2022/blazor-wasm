using BlazorProject.Server.Models;
using BlazorProject.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;
        private readonly ILogger<UserController> logger;

        public UserController(IUserRepository _userRepository,IConfiguration _configuration, ILogger<UserController> _logger)
        {
            userRepository = _userRepository;
            configuration = _configuration;
            logger = _logger;
        }

        [Route("/testapi")]
        [HttpGet]
        public ActionResult Welcome()
        {
            //throw new Exception("Test error");
          
            return Ok("Web API working!");
        }
        
        [Route("/api/user/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]dynamic data)
        {            
            var desdata =  JsonConvert.DeserializeObject(data.ToString());
            //Console.WriteLine(desdata);
            string email = desdata.Email;
            string password = desdata.Password;
            
            var token = await userRepository.Login(email, password);

            if (token != null)
            {
                return Ok(new {accessToken = token});
            }
            else 
            {
                return BadRequest("Email or Password not matched");
            }
            
        }

        [Route("/api/user/register")]
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            User createdUser;
            try
            {
                var existingUser = await userRepository.GetUserByEmail(user.Email);

                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email already in use");
                    return BadRequest(ModelState);
                }

                createdUser = await userRepository.AddUser(user);
            }
            catch
            {
                return StatusCode(500, "Error from Register()");
            }

            if (createdUser != null)
            {
                return CreatedAtAction(nameof(GetUserByEmail),new { email=user.Email}
                , "User created successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("/api/user/GetUserByEmail")]
        [HttpPost]
        public async Task<ActionResult> GetUserByEmail([FromBody]dynamic data)
        {            
            /*
            string name = Request.Headers["userfullname"].ToString();
            string userid = Request.Headers["userid"].ToString();
            string role = Request.Headers["role"].ToString();
            */
            var desdata = JsonConvert.DeserializeObject(data.ToString());

            string email = desdata.Email;

            var user = await userRepository.GetUserByEmail(email);

            if(user != null)
            {
                var newuser = new
                {
                    userid = user.UserId,
                    userfullname = user.FirstName + " " + user.LastName,
                    roles = user.Roles
                };
                return Ok(newuser);
            }
            else
            {
                return NotFound("User not found");
            }
        }

        [Route("/CheckIfEmailExists")]
        [HttpPost]
        public async Task<IActionResult> CheckIfEmailExists([FromBody] dynamic data)
        {
            /*
            string name = Request.Headers["userfullname"].ToString();
            string userid = Request.Headers["userid"].ToString();
            string role = Request.Headers["role"].ToString();
            */
            var desdata = JsonConvert.DeserializeObject(data.ToString());

            string email = desdata.Email;

            var user = await userRepository.GetUserByEmail(email);

            if (user != null)
            {
                return Ok("exists") ;
            }
            else
            {
                return Ok("not exists");
            }
        }
    }
}
