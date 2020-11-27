using System.Collections.Generic;
using System.Linq;
using GuiaBar.API.Models.Request;
using GuiaBar.API.Models.ViewModel;
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
        /// <response code="500">Erro interno</response>
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
        /// <response code="500">Erro interno</response>
        [HttpPost("login")]
        public ActionResult<Token> Post([FromBody]LoginRequest request)
        {
            Token result = service.Login(request.UserName, request.Password);
            return Ok(result.AccessToken);
        } 
        
        /// <summary>
        /// Avaliar o bar
        /// </summary>
        /// <returns>Nothing</returns>
        /// <response code="200">Avaliação cadastrada</response>
        /// <response code="401">"Token Inválido ou expirado!"</response>
        /// <response code="403">"Apenas usuários cadastrados podem avaliar bares"</response>
        /// <response code="500">Erro interno</response>
        [HttpPost("evaluation")]
        [Authorize(Roles = "common")]
        public ActionResult Post([FromBody]CreateEvaluationRequest request)
        {   
            long userId;
            long.TryParse(User.Identity.Name, out userId);

            service.CreateEvaluation(userId, request.PubName, request.Evaluation);
            decimal evaluation = request.Evaluation;

            return Ok($"Sua avaliação {evaluation} foi aplicada com sucesso!");
        }     

        /// <summary>
        /// Calcula distancia e tempo do usuário até o bar
        /// </summary>
        /// <returns>Distancia e tempo entre o bar e o usuario</returns>
        /// <response code="200">Distancia e tempo calculado com sucesso</response>
        /// <response code="401">"Token Inválido ou expirado!"</response>
        /// <response code="403">"Apenas usuários cadastrados podem medir suas distancia até os bares"</response>
        /// <response code="500">Erro interno</response>
        [HttpGet("distance")]
        [Authorize(Roles = "common")]
        public ActionResult<RootViewModel> Get([FromQuery]GetRouteRequest request)
        {
            long userId;
            long.TryParse(User.Identity.Name, out userId);

            
            Root result = service.CountDistance(userId, request.PubName);
            RootViewModel viewModel = new RootViewModel()
            {
               distance = result.rows.First().elements.First().distance.text,
               duration = result.rows.First().elements.First().duration.text
            };
            return Ok(viewModel);
        } 
    }
}