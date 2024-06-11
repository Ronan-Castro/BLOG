using BlogAPI.Attributes;
using BlogAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Controllers{
    [ApiController]
    [Route("")]    
    public class HomeController : ControllerBase{

        //HealthCheck
        [HttpGet("")]
        public IActionResult Get(){

            return Ok(new ResultViewModel<string>("Estamos Funcionando", null));
        }
    }
}