using GuiaBar.API.Models.Request;
using GuiaBar.Domain.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GuiaBar.API.Controllers
{
    public class EvaluationController
    {
         private readonly IUserPubEvaluationService serviceEvaluation;
        public EvaluationController(IUserPubEvaluationService serviceEvaluation) 
        {
            this.serviceEvaluation = serviceEvaluation;
        }

        [HttpPost]
        [Route("api/evaluation")]
        public ActionResult EvaluationPost([FromBody]CreateEvaluationRequest request)
        {
            serviceEvaluation.CreateEvaluation(request.UserId, request.PubId, request.Evaluation);
            return Ok();
        }     


    }
}