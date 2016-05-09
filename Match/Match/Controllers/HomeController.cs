using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Match.Controllers
{
    public class HomeController : Controller
    {

        //
        // GET: /Home/
      //  [Authorize(Roles = "stu")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public JsonResult btnLogin(string playerID, string password)
        {
            int pID = 0;
            BLL.T_Match_Student playerBll = new BLL.T_Match_Student();
            Model.T_Match_Student playerModel = new Model.T_Match_Student();
            List<Model.T_Match_Student> lst = playerBll.GetModelList("SNO='" + playerID + "'");
            if (lst.Count > 0)
            {
                //判断密码正确？
                playerModel = lst[0];
                pID = playerModel.SID;
                if (playerModel.SPwd == password)
                {
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                           1,
                           pID.ToString(),
                           DateTime.Now,
                           DateTime.Now.AddDays(365),
                           false,
                           "stu"//写入用户角色
                           );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
                    return Json(new { code = 1 }, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    return Json(new { code = 0, msg = "抱歉，账号或密码错误！" }, JsonRequestBehavior.DenyGet);
                }
            }
            else
            {
                return Json(new { code = 0, msg = "抱歉，该用户不存在！" }, JsonRequestBehavior.DenyGet);
            }


        }
    }
}
