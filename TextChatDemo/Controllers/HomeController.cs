using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RabbitMQ.Client;
using RabbitMQ.Util;
using System.Web.Mvc;
//using ChatApplication.Models.HelperBll;
using System.Web.UI.WebControls;
using TextChatDemo.Models;

namespace TextChatDemo.Controllers
{
    public class HomeController : Controller
    {
        RTCIRepository db = new RTCIRepository();

        // GET: Home  
        public ActionResult Index()
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("login");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public JsonResult sendmsg(string message, string friend)
        {
            RabbitMQBll obj = new RabbitMQBll();
            IConnection con = obj.GetConnection();
            bool flag = obj.send(con, message, friend);
            return Json(null);
        }
        [HttpPost]
        public JsonResult receive()
        {
            try
            {
                RabbitMQBll obj = new RabbitMQBll();
                IConnection con = obj.GetConnection();
                string userqueue = Session["username"].ToString();
                string message = obj.receive(con, userqueue);
                return Json(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }


        }
        public ActionResult login()
        {

            return View("Login");
        }

       
        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
           

            bool exist = db.GetAllUserLogin(userModel.email, userModel.password);

            if (exist)
            {
                ViewData["status"] = 1;
                ViewData["msg"] = "login Successful...";
                Session["username"] = userModel.email;
                Session["userid"] = userModel.userid.ToString();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }

        }

        [HttpPost]
        public JsonResult friendlist()
        {
            int id = Convert.ToInt32(Session["userid"].ToString());
            List<UserModel> users = db.GetAdvisors(id);
            List<ListItem> userlist = new List<ListItem>();
            foreach (var item in users)
            {
                userlist.Add(new ListItem
                {
                    Value = item.email.ToString(),
                    Text = item.email.ToString()

                });
            }
            return Json(userlist);
        }
    }
}