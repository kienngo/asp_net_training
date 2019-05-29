using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AspTraining.Models;

namespace AspTraining.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            asp_net_training_anEntities dbContext = new asp_net_training_anEntities();
            var login = dbContext.Logins.Select(s => new { s.ID, s.Username, s.Password}).FirstOrDefault();
            return View(new LoginModel(login.ID, login.Username, login.Password));
        }

        // POST: Register
        public ActionResult Register()
        {
            asp_net_training_anEntities dbContext = new asp_net_training_anEntities();

            var register = new Login
            {
                Username = "Register_Test_001",
                Password = "pass_test_001"
            };
            dbContext.Logins.Add(register);
            dbContext.SaveChanges();
            return View();
        }

        // POST: Update
        public async Task<bool> Update()
        {
            asp_net_training_anEntities dbContext = new asp_net_training_anEntities();
            
            var login = (from lg in dbContext.Logins
                         select lg).FirstOrDefault();
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                login.Username = "User_Update_002";
                dbContext.SaveChanges();
            }

            return true;
        } 
    }
}