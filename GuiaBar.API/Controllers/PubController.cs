

using System.Collections.Generic;
using GuiaBar.API.Models.Request;
using GuiaBar.Domain.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GuiaBar.Domain.Entities;
using GuiaBar.API.Models.ViewModel;

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
        /// <response code="200">Usuário cadastrado</response>
        /// <response code="403">"Apenas administradores podem cadastrar bares"</response>
        /// <response code="500">Erro interno</response>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Post([FromBody]CreatePubRequest request)
        {
            service.CreatePub(request.Name, request.Description, request.Address, request.Contact);
            return Ok();
        }

        /// <summary>
        /// Lista todos os bares cadastrados
        /// </summary>
        /// <returns>Listar bares cadastrados</returns>
        /// <response code="200">Lista de todos os bares</response>
        /// <response code="400">Nenhum bar cadastrado</response>
        /// <response code="500">Erro interno</response>
        [HttpGet("home")]
        public ActionResult Get()
        {
            IEnumerable<Pub> result = service.GetAllPubs();
            List<PubViewModel> viewModel = new List<PubViewModel>();
            foreach (var item in result)
            {
                viewModel.Add(new PubViewModel
                {
                    Name = item.Name,
                    Description = item.Description,
                    Address = item.Address,
                    Contact = item.Address,
                    Evaluation = item.Evaluation
                    
                });
            }

            return Ok(viewModel);
        } 

    }
}