using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Class2.Controllers
{

    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //角色控制
        [Authorize(Roles = "vip")]
        public ActionResult Index()
        {
            return View();
        }
        //用户登录
        public ActionResult Login()
        {
            return View();
    
        }
        [HttpPost]
        public JsonResult btnLogin()
        {
            string LoginName = Convert.ToString(Request.Form["userID"]);
            string PWD = Convert.ToString(Request.Form["password"]);

            BookProject.Public.LoginName = LoginName;

            //ViewBag.LoginName = LoginName;

            LoginName = "='" +LoginName + "'";
            List<MODEL.T_DIC_User> lst = BookProject.Tools.XMLParser.GetUser(10, 1, LoginName);

            if (lst.Count > 0)
            {
                if (lst[0].Pwd == PWD)
                {
                    if (lst[0].Status == 0)
                    {
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        lst[0].LoginName.ToString(),
                        DateTime.Now,
                        DateTime.Now.Add(FormsAuthentication.Timeout),
                        false,
                        "vip"                                             //管理员（后台）角色
                        );
                        HttpCookie cookie = new HttpCookie(
                            FormsAuthentication.FormsCookieName,
                            FormsAuthentication.Encrypt(ticket)
                        );
                        Response.Cookies.Add(cookie);
                        //MODEL.Message message = BookProject.Public.LoginSuc();
                        return Json(0);         //登陆成功

                    }
                    else
                    {
                        return Json(1);     //无效用户
                    }

                }
                else
                    return Json(2);         //密码错误
            }
            else
                return Json(3);             //无效用户
        }
        //用户退出
        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        //修改密码
        public ActionResult ChangePwd()
        {
            return View();
        }
        public JsonResult ChangePwdSave()
        {
            string pwd = Convert.ToString(Request.Form["Pwd"]);
            bool result = BookProject.Tools.XMLParser.ChangePwd(pwd);
            if (result)
            {
                MODEL.Message message = BookProject.Public.LoginSuc();
                return Json(message);
            }
            else
            {
                return Json("");
            }
        }

        public RedirectResult LoginToRoles()
        {
            string url = Request["ReturnUrl"];

            if (string.IsNullOrEmpty(url))
            {
                return new RedirectResult("/home/login");
            }
            else
            {
                return new RedirectResult("/home/login" + "?ReturnUrl=" + url);
            }
           
        }
    }
}
