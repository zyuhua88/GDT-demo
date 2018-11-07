using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class YinHuanController : Controller
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
        // GET: YinHuan

        
        public ActionResult Index()
        {
            
            return Actions();
        }
        #region 已过期
        

        

        public ActionResult YinHuanJianDing()
        {
            ViewBag.yh_no = Request.QueryString["yh_no"];
            return Actions();
        }
        #endregion

        public ActionResult yhlist()
        {
            return Actions();
        }

        public ActionResult AddYinHuan()
        {
            ViewBag.y_id = Request.QueryString["y_id"];
            return Actions();
        }

        public ActionResult YinHuanDetail()
        {
            ViewBag.y_id = Request.QueryString["y_id"];
            return Actions();
        }

        /// <summary>
        /// 检查审批列表
        /// </summary>
        /// <returns></returns>
        public ActionResult HeadList()
        {
            return Actions();
        }

        /// <summary>
        /// 隐患需整改列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ZList()
        {
            return Actions();
        }

        /// <summary>
        /// 隐患需确认列表
        /// </summary>
        /// <returns></returns>
        public ActionResult QList()
        {
            return Actions();
        }

        public ActionResult QrForm()
        {
            ViewBag.y_id = Request.QueryString["y_id"];
            return Actions();
        }

        public ActionResult ZgForm()
        {
            ViewBag.y_id = Request.QueryString["y_id"];
            return Actions();
        }

        public ActionResult YhTj()
        {
            return Actions();
        }
    }
}