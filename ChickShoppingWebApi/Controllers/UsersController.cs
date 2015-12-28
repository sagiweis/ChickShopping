using ChickShoppingCommonResources;
using ChickShoppingDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        [HttpPost]
        public ActionResult AddUser(string uuid, string firstName, string lastName, string imageURI)
        {
            User user = new User(uuid, firstName, lastName, imageURI);
            UsersDataAccess.GetInstance().AddUser(user);
            return Json(JsonConvert.SerializeObject(user, null, new JsonSerializerSettings()), JsonRequestBehavior.AllowGet);
        }
    }
}