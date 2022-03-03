using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WordleApp.Controllers
{
    [Route("api/wordle")]
    [ApiController]
    public class WordleController : ControllerBase
    {
        public static List<string> Words { get; } = new()
        {
            
        };
    }
}
