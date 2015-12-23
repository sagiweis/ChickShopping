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
            return Json(JsonConvert.SerializeObject(user, null, new JsonSerializerSettings()), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddUser(string firstName, string lastName, string uuid)
        {
            User user = new User(firstName, lastName, uuid);
            UsersDataAccess.GetInstance().AddUser(user);
            return Json(JsonConvert.SerializeObject(user, null, new JsonSerializerSettings()), JsonRequestBehavior.AllowGet);
        }
    }
}