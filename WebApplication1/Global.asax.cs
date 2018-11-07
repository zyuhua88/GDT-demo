using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            //当前在线人数
            Application["usCount"] = 0;
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            Session.Timeout = 1;
            //加锁 防多用户并发
            Application.Lock();
            ///统计在线人数
            Application["usCount"] = (int)Application["usCount"] + 1;
            
            //添加一个定时器用来累加程序的在线总时长
            System.Timers.Timer t = new System.Timers.Timer();
            t.Interval=60000;

            t.Elapsed += new System.Timers.ElapsedEventHandler(AddTime);
            t.AutoReset = true;
            t.Enabled =true;

            Application.UnLock();
        }
        

        protected void Session_End()
        {
            Application.Lock();
            Application["usCount"] = (int)Application["usCount"] - 1;
            Application.UnLock();
        }

        protected void AddTime(object o, System.Timers.ElapsedEventArgs e)
        {
            ////程序的执行时长，每分钟+1
            string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string sql = "update systimes set timecount=timecount+1";
            
            SqlCommand com = new SqlCommand(sql,conn);
            com.ExecuteNonQuery();
            conn.Close();
        }
    }
}
