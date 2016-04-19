using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Match.Areas.Match.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Match/User/

        public ActionResult Index()
        {
            return View();
        }
        //Student页面展示
        public ActionResult SList()
        {
            BLL.T_Match_Student bll = new BLL.T_Match_Student();
            int PageSize = 10;//默认值
            int PageIndex = 1;
            string keywords = Convert.ToString(Request.Form["keywords"]);
            if (Request.Form["pageNum"] != null)
            {
                PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
                PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            }
            //读取该页的数据
            DataSet ds = bll.GetListByPage("SName like '%" + keywords + "%'", "SID", (PageIndex - 1) * PageSize + 1, PageIndex * PageSize);
            List<Model.T_Match_Student> lst = bll.DataTableToList(ds.Tables[0]);
            int totalcount = bll.GetRecordCount("SName like '%" + keywords + "%'");
            ViewBag.pagesize = PageSize;
            ViewBag.pageindex = PageIndex;
            ViewBag.lst = lst;
            ViewBag.totalcount = totalcount;
            return View();
        }

       //Teacher页面展示
        public ActionResult TList()
        {
            BLL.T_Match_Teacher bll = new BLL.T_Match_Teacher();
            int PageSize = 10;//默认值
            int PageIndex = 1;
            string keywords = Convert.ToString(Request.Form["keywords"]);
            if (Request.Form["pageNum"] != null)
            {
                PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
                PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            }
            //读取该页的数据
            DataSet ds = bll.GetListByPage("TName like '%" + keywords + "%'", "TID", (PageIndex - 1) * PageSize + 1, PageIndex * PageSize);
            List<Model.T_Match_Teacher> lst = bll.DataTableToList(ds.Tables[0]);
            int totalcount = bll.GetRecordCount("TName like '%" + keywords + "%'");
            ViewBag.pagesize = PageSize;
            ViewBag.pageindex = PageIndex;
            ViewBag.lst = lst;
            ViewBag.totalcount = totalcount;
            return View();
        }

        //Admin页面展示
        public ActionResult AList()
        {
            BLL.T_Match_Admin bll = new BLL.T_Match_Admin();
            int PageSize = 10;//默认值
            int PageIndex = 1;
            string keywords = Convert.ToString(Request.Form["keywords"]);
            if (Request.Form["pageNum"] != null)
            {
                PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
                PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            }
            //读取该页的数据
            DataSet ds = bll.GetListByPage("Name like '%" + keywords + "%'", "ID", (PageIndex - 1) * PageSize + 1, PageIndex * PageSize);
            List<Model.T_Match_Admin> lst = bll.DataTableToList(ds.Tables[0]);
            int totalcount = bll.GetRecordCount("Name like '%" + keywords + "%'");
            ViewBag.pagesize = PageSize;
            ViewBag.pageindex = PageIndex;
            ViewBag.lst = lst;
            ViewBag.totalcount = totalcount;
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }

        //添加Admin
        public ActionResult AddAdmin()
        {
            return View();
        }
        public JsonResult AddAdminSave(Model.T_Match_Admin model)
        {
            BLL.T_Match_Admin bll = new BLL.T_Match_Admin();
            int result = bll.Add(model);
            //提示添加管理员状态
            #region
            if (result > 0)
            {
                Model.Message message = new Model.Message();
                message.statusCode = "200";
                message.message = "添加管理员成功！";
                message.navTabId = "";
                message.rel = "";
                message.forwardUrl = "";
                message.callbackType = "closeCurrent";

                return Json(message);
            }
            ///添加管理员成功返回
            else
            {
                Model.Message message = new Model.Message();
                message.statusCode = "300";
                message.message = "添加管理员失败！";
                message.navTabId = "";
                message.rel = "";
                message.forwardUrl = "";
                message.callbackType = "closeCurrent";

                return Json(message);
            }
            #endregion
        }

    }
}
