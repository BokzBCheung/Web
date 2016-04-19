using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Match.Areas.Match.Controllers
{
    public class SignController : Controller
    {
        //
        // GET: /Match/Sign/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddSave()
        {
            Model.T_Match_DetailBody body = new Model.T_Match_DetailBody();
            body.HeaderID = Convert.ToInt32(Request.Form["OrderNumber"]);
            body.StudentID = Convert.ToString(Request.Form["Person.ID"]);
            body.StudentID = Convert.ToString(Request.Form["Person.Phone"]);
            body.StudentID = Convert.ToString(Request.Form["Person.Mail"]);
            body.StudentID = Convert.ToString(Request.Form["Person.Comments"]);
            BLL.T_Match_DetailBody bll = new BLL.T_Match_DetailBody();
            int  result = bll.Add(body);
            if (result > 0)
            {
                Model.Message message = new Model.Message();
                message.statusCode = "200";
                message.message = "增加条目成功!";
                message.navTabId = "UserList";
                message.rel = "UserList";
                message.forwardUrl = "";
                message.callbackType = "closeCurrent";
                return Json(message);
            }
            else
            {
                Model.Message message = new Model.Message();
                message.statusCode = "300";
                message.message = "增加条目失败!";
                message.navTabId = "UserList";
                message.rel = "UserList";
                message.forwardUrl = "";
                message.callbackType = "closeCurrent";
                return Json(message);
            }
        }
        public ActionResult GetJson()
        {
            BLL.T_Match_DetailHeader bll = new BLL.T_Match_DetailHeader();
            List<Model.T_Match_DetailHeader> lst = bll.GetModelList("1=1");
            string json = "[";
            for (int i = 0; i < lst.Count; i++)
            {
                if (i == lst.Count - 1)
                    json += " {\"ID\":\"" + lst[i].ID + "\", \"Name\":\"" + lst[i].Name + "\", \"Phone\":\"" + lst[i].Time + "\"}";
                else
                    json += " {\"ID\":\"" + lst[i].ID + "\", \"Name\":\"" + lst[i].Name + "\", \"Phone\":\"" + lst[i].Time + "\"},";
            }

            json += "]";
            return Content(json);
        }
    }
}
