

using GuiaBar.API.Models.Request;
using GuiaBar.Domain.Services.Interface;
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
        public ActionResult Post([FromBody]CreatePubRequest request)
        {
            service.CreatePub(request.Name, request.Description, request.Address, request.Contact);
            return Ok();
        }   

    }
}