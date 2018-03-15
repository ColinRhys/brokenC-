using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using DbConnection;
using theWall.Models;


namespace theWall.Controllers
{
    public class loginAndRegistrationController : Controller
   {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        //POST: /Put users into database/
        [HttpPost]
        [Route("/register")]
        public IActionResult Register(User newUser)
        {
            System.Console.WriteLine("Got here");
            if(ModelState.IsValid)
            {
                string checkEmail = $"SELECT * FROM users WHERE(email = '{newUser.email}')";
                var emailExists = DbConnector.Query(checkEmail);
                if (emailExists.Count == 0)
                {
                    string query = $"INSERT INTO users(first_name, last_name, email, password, created_at)VALUES('{newUser.first_name}', '{newUser.last_name}', '{newUser.email}', '{newUser.password}', NOW())";
                    DbConnector.Execute(query);
                    return RedirectToAction("Index", "theWall");
            }
            else
            {
                ViewBag.email = "An account with this email already exists";
                return View("Index");
            }
        }
        else {
            ViewBag.email = "";
            return View("Index");
        }
        }
        [HttpGet]
        [Route("toLogin")]
        public IActionResult ToLogin()
        {
            System.Console.WriteLine("________________________Got to wl in to long in_______________________");
            return View("Login");
        }

        [HttpPost]
        [Route("/simplePost")]
        public IActionResult SimplePost(string name)
        {
            System.Console.WriteLine(name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/testRoute")]
        public IActionResult TestRoute()
        {
            return View("test");
        }

        [HttpPost]
        [Route("/loginUser")]
        public IActionResult LoginUser(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                string query = $"SELECT * FROM users WHERE email = '{user.email}'";
                System.Console.WriteLine(query);
                var exists = DbConnector.Query(query);
                System.Console.WriteLine("______________",exists,"_________");
                if (exists.Count == 0)
                {
                    ViewBag.email = "Email not found";
                    return View("Login");
                }
                else {
                    string password = (exists[0]["password"]).ToString();
                    if (password != user.password)
                    {
                        ViewBag.password = "Password not recognized";
                        return View("Login");
                    }
                    else 
                    {
                        return View("Success");
                    }
                }
            }
            else {
                return RedirectToAction("Success");
            }
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}