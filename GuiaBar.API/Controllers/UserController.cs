using System.Collections.Generic;
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

        [HttpGet("home")]
        public ActionResult Get()
        {
            IEnumerable<Pub> result = service.GetAllPubs();
            return Ok(result);
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
        
        [HttpPost]
        [Route("evaluation")]
        [Authorize(Roles = "common")]
        public ActionResult EvaluationPost([FromBody]CreateEvaluationRequest request)
        {
            service.CreateEvaluation(request.UserId, request.PubName, request.Evaluation);
            return Ok();
        }     

        [HttpGet("distance")]
        [Authorize(Roles = "common")]
        public ActionResult<Root> Get([FromQuery]GetRouteRequest request)
        {
            Root result = service.CountDistance(request.UserId, request.PubName);
            return Ok(result);
        } 
    }
}