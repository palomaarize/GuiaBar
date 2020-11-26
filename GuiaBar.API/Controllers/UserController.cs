using GuiaBar.API.Models.Request;
using GuiaBar.Domain.Entities;
using GuiaBar.Domain.Services.Interface;
using Microsoft.AspNetCore.Authorization;
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
        [Route("evaluation")]
        [Authorize(Roles = "common")]
        public ActionResult EvaluationPost([FromBody]CreateEvaluationRequest request)
        {
            service.CreateEvaluation(request.UserId, request.PubName, request.Evaluation);
            return Ok();
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

        [HttpGet("distance")]
        public ActionResult<Root> Get([FromQuery]GetRouteRequest request)
        {
            Root result = service.CountDistance(request.UserAddress, request.PubAddress);
            return Ok(result);
        } 

        // [HttpGet]
        // [Route("")]
        //  public ActionResult Get([FromBody]CreateEvaluationRequest request)
        // {
        //     service.GetEvaluationById(request.PubId);
        //     return Ok();
        // } 


    }
}