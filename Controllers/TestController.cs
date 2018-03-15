using DbConnection;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace theWall.Controllers
{
    public class TestControllers : Controller
    {
        [Route("theWall")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        // [Route("makeQuote")]
        // [HttpPost]
        // public IActionResult MakeQuote()
    }
}