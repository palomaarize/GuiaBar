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

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <returns>Cadastrar usuário</returns>
        /// <response code="200">Usuário cadastrado</response>
        /// <response code="400">User name já cadastrado</response>
        [HttpPost]
        public ActionResult Post([FromBody]CreateUserRequest request)
        {
            service.CreateUser(request.UserName, request.Password, request.Email, request.Address);
            return Ok();
        } 

        /// <summary>
        /// Login do usuário
        /// </summary>
        /// <returns>Token de acesso do usuário</returns>
        /// <response code="200">Login realizado</response>
        /// <response code="400">Senha incorreta</response>
        /// <response code="400">Usuário nçao cadastrado</response>
        [HttpPost("login")]
        public ActionResult<Token> Post([FromBody]LoginRequest request)
        {
            Token result = service.Login(request.UserName, request.Password);
            return Ok(result);
        } 
        
        /// <summary>
        /// Avaliar o bar
        /// </summary>
        /// <returns>Nothing</returns>
        /// <response code="200">Avaliação cadastrada</response>
        /// <response code="400">Bar não cadastrado</response>
        /// <response code="400">Usuário não cadastrado</response>
        /// <response code="401">"Token Inválido ou expirado!"</response>
        /// <response code="403">"Apenas usuários cadastrados podem avaliar bares"</response>
        [HttpPost]
        [Route("evaluation")]
        [Authorize(Roles = "common")]
        public ActionResult Post([FromBody]CreateEvaluationRequest request)
        {   string userIdByToken = User.Identity.Name;
            long userId;
            long.TryParse(userIdByToken, out userId);

            service.CreateEvaluation(userId, request.PubName, request.Evaluation);
            decimal evaluation = request.Evaluation;
            
            return Ok($"Sua avaliação {evaluation} foi aplicada com sucesso!");
        }     

        /// <summary>
        /// Calcula distancia e tempo do usuário até o bar
        /// </summary>
        /// <returns>Distancia e tempo entre o bar e o usuario</returns>
        /// <response code="200">Distancia e tempo calculado com sucesso</response>
        /// <response code="400">Bar não cadastrado</response>
        /// <response code="400">Usuário não cadastrado</response>
        /// <response code="401">"Token Inválido ou expirado!"</response>
        /// <response code="403">"Apenas usuários cadastrados podem medir suas distancia até os bares"</response>
        [HttpGet("distance")]
        [Authorize(Roles = "common")]
        public ActionResult<Root> Get([FromQuery]GetRouteRequest request)
        {
            string userIdByToken = User.Identity.Name;
            long userId;
            long.TryParse(userIdByToken, out userId);

            Root result = service.CountDistance(userId, request.PubName);
            return Ok(result);
        } 
    }
}