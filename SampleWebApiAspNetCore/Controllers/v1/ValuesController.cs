using Microsoft.AspNetCore.Authorization;
 
using Microsoft.AspNetCore.Mvc;
 

namespace WebApiAspNetCore.Controllers.v1
{


    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [Authorize]
        [Microsoft.AspNetCore.Mvc.Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [Authorize(Roles = "admin")]
        [Microsoft.AspNetCore.Mvc.Route("getrole")]
        public IActionResult GetRole()
        {
            return Ok("Ваша роль: администратор");
        }
    }
}
