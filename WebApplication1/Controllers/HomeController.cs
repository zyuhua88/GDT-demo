using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
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
            else {
                return View("../home/login");
            }
        }

        public ActionResult login()
        {
            return View();
        }


        public ActionResult cs()
        {
            return View();
        }
        public ActionResult unlogin()
        {
            Response.Cookies["usid"].Values.Clear();
            Response.Cookies["usid"].Expires = DateTime.Now.AddDays(-1000);
            Response.Cookies.Remove("usid");
            return View("../home/login");
        }

        public bool login(int usid)
        {
            
            return true;
        }
        public ActionResult Index()
        {
            

            if (Request.QueryString["usid"] != null)
            {
                Response.Cookies["usid"].Value = Request.QueryString["usid"];
                ViewBag.usid = Request.QueryString["usid"];
                HttpCookie cook = new HttpCookie("usid");
                cook.Value = Request.QueryString["usid"];
                cook.Expires = DateTime.Now.AddYears(100);
                Response.Cookies.Add(cook);
                return View();
            }
            else {
                if (Request.Cookies["usid"]!=null)
                {
                    ViewBag.usid = Request.Cookies["usid"].Value;
                    return View();
                }
                else {
                    return View("../home/login");
                }
            }
            
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePwd()
        {
            return Actions();
        }


        public ActionResult welcome()
        {
            ViewBag.usCount = HttpContext.Application["usCount"];
            string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();

            string sql = "select timecount from systimes";
            SqlCommand com = new SqlCommand(sql,conn);
            ViewBag.online= com.ExecuteScalar();

            conn.Close();

            return Actions();
        }

        public ActionResult addHead()
        {
            return Actions();
        }

        public ActionResult updateLogo()
        {
            return Actions();
        }

        public ActionResult company_list()
        {
            return Actions();
        }


        public ActionResult Add_company()
        {
            ViewBag.com_id = Request.QueryString["com_id"];
            return Actions();
        }

        public ActionResult deparmentList()
        {
            return Actions();
        }


        public ActionResult add_deparment()
        {
            ViewBag.b_id = Request.QueryString["b_id"];
            return Actions();
        }

        public ActionResult Classes()
        {
            ViewBag.b_id = Request.QueryString["b_id"];
            return Actions();
        }

        public ActionResult AddClass()
        {
            ViewBag.c_id = Request.QueryString["c_id"];
            return Actions();
        }

        public ActionResult userList()
        {
            return Actions();
        }

        public ActionResult AddUsers()
        {
            ViewBag.us_id = Request.QueryString["us_id"];
            return Actions();
        }

        public ActionResult GroupbyClass()
        {
            ViewBag.testid = Request.QueryString["testid"];
            return Actions();
        }


        public ActionResult Verify()
        {
            return Actions();
        }
        
    }
}