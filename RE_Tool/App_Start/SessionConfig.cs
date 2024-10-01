using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dao.Entity;
namespace RE_Tool.App_Start
{
    public class SessionConfig
    {
        //Luu User khi dang nhap vao
        public static void SetUser(Account user)
        {
            HttpContext.Current.Session["user"] = user;
        }
        //lay session
        public static Account GetUser()
        {
            return (Account)HttpContext.Current.Session["user"];
        }
    }
}