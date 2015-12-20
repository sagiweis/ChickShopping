using ChickShoppingCommonResources;
using ChickShoppingDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace ChickShoppingWebApi.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUser(string uuid)
        {
            User user = UsersDataAccess.GetInstance().GetUser(uuid);
            string converted = JsonConvert.SerializeObject(user, null, new JsonSerializerSettings());
            return Json(converted, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void AddUser(string firstName, string secondName, string phoneNumber)
        {
            User user = new User(firstName, secondName, phoneNumber);
            UsersDataAccess.GetInstance().AddUser(user);
        }
    }
}