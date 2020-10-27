using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Route ("api/buggy")]
    public class ErrorController : ControllerBase {
        private readonly SkinetContext _context;
        public ErrorController (SkinetContext context) {
            this._context = context;
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetString(){
            return "Buggy Controller";
        }

        [HttpGet ("notfound")]
        public IActionResult ErrorRequest () {
            //404 Not Found
            return NotFound ();
        }

        [HttpGet ("servererror")]
        public IActionResult GetServerError () {
            //500 server-error
            var prod =_context.Products.Find(100);
            var rtrn = prod.ToString();
            return Ok ();
        }

        [HttpGet ("badrequest")]
        public IActionResult GetBadRequest () {
            //404 Not Found
            return BadRequest();
        }

        [HttpGet ("badrequest/{id}")]
        public IActionResult GetBadRequest (int id) {
            //404 Not Found
            return Ok();
        }
    }
}