using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class2.Areas.DIC.Controllers
{
    /// <summary>
    /// 实现了对表用户的增删改查
    /// 分页显示和局部刷新功能
    /// </summary>
    /// 

    public class UserController : Controller
    {
/// <summary>
/// List of Users
/// </summary>
/// <returns></returns>
/// 
        public ActionResult List()
        {
            BLL.T_DIC_User bll = new BLL.T_DIC_User();

            //通过解析XML来进行列表展示
            int PageSize = 10, PageIndex = 1;

            string keywords=Convert.ToString(Request.Form["keywords"]);
            if (keywords == ""|| keywords==null)
            {
                keywords = null;
            }
            else
            {
                keywords = "='"+Convert.ToString(Request.Form["keywords"])+"'";
            }

            int totalcount = BookProject.Tools.XMLParser.GetCount(keywords);

            if (Request.Form["pageNum"] != null)
            {
                PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
                PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            }
            List<MODEL.T_DIC_User> lst = BookProject.Tools.XMLParser.GetUser(PageSize, PageIndex,keywords);
            ViewBag.pagesize = PageSize;
            ViewBag.pageindex = PageIndex;
            ViewBag.totalcount = totalcount;
            ViewBag.lst = lst;

            //未使用分页方法
            //List<MODEL.T_DIC_User> lst=new List<MODEL.T_DIC_User>();
            //lst = bll.GetAll();

            //使用分页方法展示
            //string where = "1=1";
            //int PageSize = 10;//默认值
            //int PageIndex = 1;
            //int totalcount = bll.GetUserTotalCount(where);
            //if (Request.Form["pageNum"] != null)
            //{
            //    PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
            //    PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            //}
            //List<MODEL.T_DIC_User> lst=bll.GetUserByPage(PageSize,PageIndex);
            //ViewBag.pagesize = PageSize;
            //ViewBag.pageindex = PageIndex;
            //ViewBag.lst = lst;
            //ViewBag.totalcount = totalcount;
            return View();
        }

/// <summary>
/// AddUser
/// </summary>
/// <returns></returns>
        public ActionResult AddUser()
        {
            return View();
        }
        public JsonResult AddUserSave(MODEL.T_DIC_User user)
        {
            BLL.T_DIC_User bll = new BLL.T_DIC_User();

            //if (bll.AddUser(user))//数据库操作
            if(BookProject.Tools.XMLParser.AddUser(user))//XML文件操作
            {
                MODEL.Message message = BookProject.Public.T_CloseSMess("UserList", "UserList", "注册用户成功！");
                return Json(message);
            }
            else
            {
                MODEL.Message message = BookProject.Public.T_CloseFMess("UserList", "UserList", "注册用户失败！");
                return Json(message);
            }
        }
/// <summary>
/// DeleteUser
/// </summary>
/// <param name="uid"></param>
/// <returns></returns>
        public JsonResult Delete(int uid)
        {
            BLL.T_DIC_User bll = new BLL.T_DIC_User();
            //bool result = bll.Delete(uid);
            bool result = BookProject.Tools.XMLParser.DeleteUser(uid);
            if (result)
            {
                MODEL.Message message = BookProject.Public.U_CloseSMess("UserList", "UserList", "删除用户成功！");
                return Json(message);
            }
            else
            {
                MODEL.Message message = BookProject.Public.U_CloseFMess("UserList", "UserList", "删除用户失败！");
                return Json(message);
            }
        }

/// <summary>
/// EditUser
/// </summary>
/// <param name="uid"></param>
/// <returns></returns>
        public ActionResult EditUser(int uid)
        {
            BLL.T_DIC_User bll = new BLL.T_DIC_User();
            //MODEL.T_DIC_User model = bll.GetModel(uid);
            MODEL.T_DIC_User model = BookProject.Tools.XMLParser.EditUser(uid);
            ViewBag.lst = model;
            return View();
        }
        public JsonResult EditUserSave(MODEL.T_DIC_User model)
        {
            BLL.T_DIC_User bll = new BLL.T_DIC_User();
            //bool result=bll.Update(model);
            bool result = BookProject.Tools.XMLParser.EditSave(model);
            if (result)
            {
                MODEL.Message message = BookProject.Public.T_CloseSMess("UserList", "UserList", "编辑用户成功！");
                return Json(message);
            }
            else
            {
                MODEL.Message message = BookProject.Public.T_CloseFMess("UserList", "UserList", "编辑用户失败！");
                return Json(message);
            }
        }
        //public ActionResult ListBySearch()
        //{
        //    BLL.T_DIC_User bll = new BLL.T_DIC_User();

        //    //通过解析XML来进行列表展示
        //    int PageSize = 10, PageIndex = 1;
        //    int totalcount = BookProject.Tools.XMLParser.GetCount();
        //    string where=
        //    if (Request.Form["pageNum"] != null)
        //    {
        //        PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
        //        PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
        //    }
        //    List<MODEL.T_DIC_User> lst = BookProject.Tools.XMLParser.Search(PageSize, PageIndex,);
        //    ViewBag.pagesize = PageSize;
        //    ViewBag.pageindex = PageIndex;
        //    ViewBag.totalcount = totalcount;
        //    ViewBag.lst = lst;
        //    return View();
        //}
    }
}
