using GuiaBar.API.Models.Request;
using GuiaBar.Domain.Entities;
using GuiaBar.Domain.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GuiaBar.API.Controller
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        public UserController(IUserService service) 
        {
            this.service = service;
        }

        [HttpPost]
        public ActionResult Post([FromBody]CreateUserRequest request)
        {
            service.CreateUser(request.UserName, request.Password, request.Email, request.Address);
            return Ok();
        }   

        [HttpPost("login")]
        public ActionResult<Token> Post([FromBody]LoginRequest request)
        {
            Token result = service.Login(request.UserName, request.Password);
            return Ok(result);
        } 
    }
}