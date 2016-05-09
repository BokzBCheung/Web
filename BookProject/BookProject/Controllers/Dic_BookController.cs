using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class2.Controllers
{
    /// <summary>
    /// 实现对书籍的增删改查分页和局部刷新显示
    /// </summary>
    public class Dic_BookController : Controller
    {
/// <summary>
/// List Of Books
/// </summary>
/// <returns></returns>
        public ActionResult List()
        {
            BLL.T_DIC_Book bll=new BLL.T_DIC_Book();
            //List<MODEL.T_DIC_Book> lst=new List<MODEL.T_DIC_Book>();
            //lst = bll.GETALL();
            int PageSize = 10;//默认值
            int PageIndex = 1;
            string keywords = Convert.ToString(Request.Form["keywords"]);
            if (keywords == "" || keywords == null)
            {
                keywords = null;
            }
            else
            {
                keywords = " and Name like'%" + Convert.ToString(Request.Form["keywords"]) + "%'";
            }
            if (Request.Form["pageNum"] != null)
            {
                PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
                PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            }
            List<MODEL.T_DIC_Book> lst = bll.GetBookByPage(PageSize, PageIndex,keywords);
            int totalcount = bll.GetUserTotalCount(keywords);
            ViewBag.pagesize = PageSize;
            ViewBag.pageindex = PageIndex;
            ViewBag.lst = lst;
            ViewBag.totalcount = totalcount;
            return View();
        }
/// <summary>
/// AddBook
/// </summary>
/// <returns></returns>
        public ActionResult AddBook() {
            return View();
        }
        public JsonResult AddBookSave(MODEL.T_DIC_Book book) {
            BLL.T_DIC_Book bll = new BLL.T_DIC_Book();
            if (bll.AddBook(book))
            {
                MODEL.Message message = BookProject.Public.T_CloseSMess("BookList", "BookList", "增加书籍成功！");
                return Json(message);

            }
            else {
                MODEL.Message message = BookProject.Public.T_CloseSMess("BookList", "BookList", "增加书籍失败！");
                return Json(message);
            }
        }
/// <summary>
/// DeleteBook
/// </summary>
/// <param name="uid"></param>
/// <returns></returns>
        public JsonResult Delete(int uid)
        {
            BLL.T_DIC_Book bll = new BLL.T_DIC_Book();
            bool result=bll.Delete(uid);
            if (result)
            {
                MODEL.Message message = BookProject.Public.U_CloseSMess("BookList", "BookList", "删除书籍成功！");
                return Json(message);

            }
            else {
                MODEL.Message message = BookProject.Public.U_CloseFMess("BookList", "BookList", "删除书籍失败！");
                return Json(message);
            }
        }
/// <summary>
/// EditBook
/// </summary>
/// <param name="uid"></param>
/// <returns></returns>
        public ActionResult EditBook(int uid)
        {
            BLL.T_DIC_Book bll = new BLL.T_DIC_Book();
            MODEL.T_DIC_Book model = bll.GetModel(uid);
            ViewBag.lst = model;
            return View();
        }
        public JsonResult EditBookSave(MODEL.T_DIC_Book book)
        {
            BLL.T_DIC_Book bll = new BLL.T_DIC_Book();
            bool result = bll.Update(book);
            if (result)
            {
                MODEL.Message message = BookProject.Public.T_CloseSMess("BookList", "BookList", "编辑书籍成功！");
                return Json(message);
            }
            else
            {
                MODEL.Message message = BookProject.Public.T_CloseSMess("BookList", "BookList", "编辑书籍失败！");
                return Json(message);
            }
        }
        

}

}
