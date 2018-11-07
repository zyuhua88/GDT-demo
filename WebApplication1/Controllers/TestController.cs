using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
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
        // GET: Test
        public ActionResult Test_List()
        {
            return Actions();
        }

        public ActionResult AddTestClassify()
        {
            ViewBag.id = Request.QueryString["id"];
            return Actions();
        }

        public ActionResult TestListAll()
        {
            return Actions();
        }

        public ActionResult Upload_File()
        {
            ViewBag.classify_id = Request.QueryString["classify_id"];
            return Actions();
        }

        public ActionResult Sdudent()
        {
            ViewBag.classify_id = Request.QueryString["classify_id"];
            return Actions();
        }

        public ActionResult StartTest()
        {
            ViewBag.testid = Request.QueryString["testid"];
            return Actions();
        }


        /// <summary>
        /// 三级教育卡
        /// </summary>
        /// <returns></returns>
        public ActionResult TestCard()
        {
            ViewBag.us_id = Request.QueryString["us_id"];
            return Actions();
        }

        public ActionResult Control()
        {
            return Actions();
        }

        /// <summary>
        /// 我的试题库列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Mytest()
        {
            ViewBag.t_types = Request.QueryString["t_types"];
            return Actions();
        }

        public ActionResult TestError()
        {
            return Actions();
        }

        public ActionResult TestErrorList()
        {
            ViewBag.classify_id = Request.QueryString["classify_id"];
            return Actions();
        }

        /// <summary>
        /// 学习资料管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Test_File()
        {
            ViewBag.filetype = Request.QueryString["filetype"];
            ViewBag.jibie = Request.QueryString["jibie"];
            return Actions();
        }

        public ActionResult Upload()
        {
            return Actions();
        }

        public ActionResult FileList()
        {
            ViewBag.value = Request.QueryString["value"];
            ViewBag.filetype = Request.QueryString["filetype"];
            ViewBag.jibie = Request.QueryString["jibie"];
            return Actions();
        }

        public ActionResult documentView()
        {
            ViewBag.src = Request.QueryString["src"];
            ViewBag.fileid = Request.QueryString["fileid"];
            ViewBag.usid = Request.QueryString["usid"];
            if (Request.QueryString["usid"]==null || Request.QueryString["fileid"]==null) {
                return View("../home/login");
            }
            return Actions();
        }
    }
}