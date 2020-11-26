

using System.Collections.Generic;
using GuiaBar.API.Models.Request;
using GuiaBar.Domain.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuiaBar.API.Controllers
{
    [ApiController]
    [Route("api/pub")]
    
    public class PubController : ControllerBase
    {
        private readonly IPubService service;
        public PubController(IPubService service) 
        {
            this.service = service;
        }

        /// <summary>
        /// Cadastra um bar no banco de dados
        /// </summary>
        /// <param name="name">Nome do bar</param>
        /// <param name="description">Descrição do bar</param>
        /// <param name="address">Endereço do bar</param>
        /// <param name="contact">Contato do bar</param>
        /// <response code="200">Usuário cadastrado</response>
        /// <response code="400">Bar já cadastrado</response>
        /// <response code="401">"Token Inválido ou expirado!"</response>
        /// <response code="403">"Apenas administradores podem cadastrar bares"</response>

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Post([FromBody]CreatePubRequest request)
        {
            service.CreatePub(request.Name, request.Description, request.Address, request.Contact);
            return Ok();
        }

    }
}