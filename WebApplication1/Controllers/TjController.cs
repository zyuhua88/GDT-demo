using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TjController : Controller
    {
        
        // GET: Tj
        public ActionResult TjView()
        {
            ViewBag.us_id = Request.QueryString["us_id"];
            return View();
        }
    }
}