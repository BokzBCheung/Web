using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class2.Areas.DIC.Controllers
{
    public class GuestController : Controller
    {
        //
        // GET: /DIC/Guest/
        /// <summary>
        /// Guest的增删改查实现
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        //Guest列表模块
        public ActionResult List()
        {
            BLL.T_DIC_Guest bll =new BLL.T_DIC_Guest();
            int PageSize = 10;//默认值
            int PageIndex = 1;
            string keywords = Convert.ToString(Request.Form["keywords"]);
            if (keywords == "" || keywords == null)
            {
                keywords = null;
            }
            else
            {
                keywords = " and Contact like '%" + Convert.ToString(Request.Form["keywords"]) + "%'";
            }
            if (Request.Form["pageNum"] != null)
            {
                PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
                PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            }
            List<MODEL.T_DIC_Guest> lst = bll.GetGuestByPage(PageSize, PageIndex, keywords);
            int totalcount = bll.GetUserTotalCount(keywords);
            ViewBag.pagesize = PageSize;
            ViewBag.pageindex = PageIndex;
            ViewBag.lst = lst;
            ViewBag.totalcount = totalcount;
            return View();
        }

        //Guest增加模块
        public ActionResult AddGuest()
        {
            return View();
        }
        public JsonResult AddGuestSave(MODEL.T_DIC_Guest model)
        {
            BLL.T_DIC_Guest bll = new BLL.T_DIC_Guest();
            bool result = bll.AddGuest(model);
            if (result)
            {
                MODEL.Message message = new MODEL.Message();
                message.statusCode = "200";
                message.message = "增加客户成功!";
                message.navTabId = "GuestList";
                message.rel = "GuestList";
                message.forwardUrl = "";
                message.callbackType = "closeCurrent";
                return Json(message);
            }
            else
            {
                MODEL.Message message = new MODEL.Message();
                message.statusCode = "300";
                message.message = "增加客户失败!";
                message.navTabId = "GuestList";
                message.rel = "GuestList";
                message.forwardUrl = "";
                message.callbackType = "closeCurrent";
                return Json(message);
            }
        }

        //Guest删除功能
        public JsonResult Delete(int uid)
        {
            BLL.T_DIC_Guest bll = new BLL.T_DIC_Guest();
            bool result = bll.Delete(uid);
            if (result)
            {
                MODEL.Message message = new MODEL.Message();
                message.statusCode = "200";
                message.message = "删除客户成功!";
                message.navTabId = "GuestList";
                message.rel = "GuestList";
                message.forwardUrl = "";
                message.callbackType = " ";
                return Json(message);
            }
            else
            {
                MODEL.Message message = new MODEL.Message();
                message.statusCode = "300";
                message.message = "删除客户失败!";
                message.navTabId = "GuestList";
                message.rel = "GuestList";
                message.forwardUrl = "";
                message.callbackType = " ";
                return Json(message);
            }
        }

        //Guest编辑模块
        public ActionResult EditGuest(int uid)
        {
            BLL.T_DIC_Guest bll = new BLL.T_DIC_Guest();
            string where="id="+uid;
            ViewBag.lst = bll.GetModel(where)[0];
            return View();
        }
        public JsonResult EditGuestSave(MODEL.T_DIC_Guest model)
        {
            BLL.T_DIC_Guest bll = new BLL.T_DIC_Guest();
            bool result = bll.Update(model);
            if (result)
            {
                MODEL.Message message = new MODEL.Message();
                message.statusCode = "200";
                message.message = "编辑客户成功!";
                message.navTabId = "GuestList";
                message.rel = "GuestList";
                message.forwardUrl = "";
                message.callbackType = "closeCurrent";
                return Json(message);
            }
            else
            {
                MODEL.Message message = new MODEL.Message();
                message.statusCode = "300";
                message.message = "编辑客户失败!";
                message.navTabId = "GuestList";
                message.rel = "GuestList";
                message.forwardUrl = "";
                message.callbackType = "closeCurrent";
                return Json(message);
            }
        }
    }
}
