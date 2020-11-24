

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

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Post([FromBody]CreatePubRequest request)
        {
            service.CreatePub(request.Name, request.Description, request.Address, request.Contact);
            return Ok();
        }   

        [HttpPut]
        [Route("{id}")]

        public ActionResult EvaluationPut([FromRoute] long id, [FromBody]CreatePubRequest request)
        {
             service.PubEvaluation(id, request.Evaluation);
             return Ok();
        }  

    }
}