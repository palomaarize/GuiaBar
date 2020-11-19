
using Microsoft.AspNetCore.Mvc;

namespace GuiaBar.API.Controller
{

    [ApiController]
    [Route("api/userController")]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [HttpPost]
        public ActionResult Post()
        {
            return Ok();
        }
    
        
    }

}