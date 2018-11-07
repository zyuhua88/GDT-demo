using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ProjectController : Controller
    {
        private int usid = 0;

        public ActionResult Actions()
        {
            if (Request.Cookies["usid"] != null)
            {
                usid = Convert.ToInt32(Request.Cookies["usid"].Value);
                ////通过用户的id加载用户的权限
                //api/verify/gdt/getusers
                ViewBag.usid = usid;
                return View();
            }
            else
            {
                return View("../home/login");
            }
        }
        // GET: Project
        public ActionResult ProjectList()
        {
            ViewBag.t_id = Request.QueryString["t_id"];
            return Actions();
        }

        public ActionResult train_project()
        {
            return Actions();
        }

        public ActionResult AddTrain_project()
        {
            ViewBag.t_id = Request.QueryString["t_id"];
            return Actions();
        }

        public ActionResult add_projectlist()
        {
            ViewBag.t_id = Request.QueryString["t_id"];
            return Actions();
        }
        
    }
}