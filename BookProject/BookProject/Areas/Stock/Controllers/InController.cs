using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class2.Areas.Stock.Controllers
{
    public class InController : Controller
    {

/// <summary>
/// 实现入库单的增加，修改，删除以及编辑的功能
/// 通过触发器来同步库存的显示数据Num。
/// </summary>
/// <returns></returns>

        public ActionResult Index()
        {
            return View();
        }

/// <summary>
/// List Of Reports
/// </summary>
/// <returns></returns>
        public ActionResult List()
        {
            Book.BLL.V_Stock_In bll = new Book.BLL.V_Stock_In();
            //List<Book.Model.V_Stock_In> lst = bll.GetModelList("1=1");
            int PageSize = 5;//默认值
            int PageIndex = 1;
            string keywords = Convert.ToString(Request.Form["keywords"]);
            if (Request.Form["pageNum"] != null)
            {
                PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
                PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            }
            //读取该页的数据
            DataSet ds = bll.GetListByPage("id like '%"+keywords+"%'", "id", (PageIndex - 1) * PageSize, PageIndex * PageSize);
            List<Book.Model.V_Stock_In> lst = bll.DataTableToList(ds.Tables[0]);
            int totalcount = bll.GetRecordCount("id like '%" + keywords + "%'");
            ViewBag.pagesize = PageSize;
            ViewBag.pageindex = PageIndex;
            ViewBag.lst = lst;
            ViewBag.totalcount = totalcount;
            return View();
        }

/// <summary>
/// EditReprot
/// </summary>
/// <param name="uid"></param>
/// <returns></returns>
        public ActionResult Edit(int uid)
        {
            BLL.T_STOCK_InHead bllHead = new BLL.T_STOCK_InHead();
            Book.Model.T_STOCK_InHead head = bllHead.GetModel(uid);

            Book.BLL.V_Inbody_Book bllBody = new Book.BLL.V_Inbody_Book();
            List<Book.Model.V_Inbody_Book> lst = bllBody.GetModelList("InHeadID=" + uid);

            ViewBag.head = head;
            ViewBag.lst = lst;
            return View();
        }
        [HttpPost]
        public ActionResult EditSave()
        {
            Book.Model.T_STOCK_InHead head = new Book.Model.T_STOCK_InHead();
            head.ID = Convert.ToInt32(Request.Form["ID"]);
            head.CeateTime = Convert.ToDateTime(Request.Form["CreateTime"]);
            head.OrderNumber = Convert.ToString(Request.Form["OrderNumber"]);
            head.ProviderID = Convert.ToInt32(Request.Form["json.ID"]);
            head.ProviderName = Convert.ToString(Request.Form["json.Name"]);
            head.UserID = 1;
            head.UserName = "系统";

            List<Book.Model.T_STOCK_InBody> lst = new List<Book.Model.T_STOCK_InBody>();
            int i = 0;
            while (Request.Form["items[" + i + "].book.BookID"] != null)
            {

                Book.Model.T_STOCK_InBody body = new Book.Model.T_STOCK_InBody();

                string BookID = Request.Form["items[" + i + "].book.BookID"];
                BookID = BookID.Replace(",", "");
                body.BookID = Convert.ToInt32(BookID);
                body.Discount = Convert.ToDecimal(Request.Form["items[" + i + "].book.Discount"]);
                body.InHeadID = 0;
                body.Num = Convert.ToInt32(Request.Form["items[" + i + "].book.Num"]);
                body.Price = Convert.ToDecimal(Request.Form["items[" + i + "].book.Price"]);
                lst.Add(body);

                i++;
            }

            BLL.T_Stock_In  bll = new BLL.T_Stock_In();
            bool result = bll.EditSave(head, lst);
            if (result)
            {
                MODEL.Message message = BookProject.Public.T_CloseSMess("InList", "InList","编辑入库单成功！");
                return Json(message);
            }
            else
            {
                MODEL.Message message = BookProject.Public.T_CloseFMess("InList","InList","编辑入库单失败！");
                return Json(message);
            }
        }

/// <summary>
/// DeleteReports
/// </summary>
/// <param name="ids"></param>
/// <returns></returns>

        [HttpPost]
        public ActionResult Delete(string ids)
        {
            Book.BLL.V_Stock_In bll = new Book.BLL.V_Stock_In();
            Book.BLL.T_STOCK_InBody bll2 = new Book.BLL.T_STOCK_InBody();
            //分离逗号的方法
            string[] list = ids.Split(',');
            int flag=0;
            for (int i = 0; i < list.Length; i++)
            {
                bool result = bll.DeleteList(list[i]);
                bool result2 = bll.DeleteStr(list[i]);
                if (result 　&&　result2)
                    flag++;
            }
            if (flag>0)
            {
                MODEL.Message message = BookProject.Public.U_CloseSMess("InList", "InList","删除入库单成功！");
                return Json(message);
            }
            else
            {
                MODEL.Message message = BookProject.Public.U_CloseFMess("InList", "InList","删除入库单失败！");
                return Json(message);
            }

        }

/// <summary>
/// AddInReport
/// </summary>
/// <returns></returns>
/// 
        public ActionResult Add()
        {

            return View();
        }
        public ActionResult AddSave()
        {
            Book.Model.T_STOCK_InHead head = new Book.Model.T_STOCK_InHead();
            head.CeateTime = Convert.ToDateTime(Request.Form["CreateName"]);
            head.OrderNumber = Convert.ToString(Request.Form["OrderNumber"]);
            head.ProviderID = Convert.ToInt32(Request.Form["json.ID"]);
            head.ProviderName = Convert.ToString(Request.Form["json.Name"]);
            head.UserID = 1;
            head.UserName = "系统";

            List<Book.Model.T_STOCK_InBody> lst = new List<Book.Model.T_STOCK_InBody>();
            int i = 0;
            while (Request.Form["items[" + i + "].book.ID"] != null)
            {

                Book.Model.T_STOCK_InBody body = new Book.Model.T_STOCK_InBody();

                string BookID = Request.Form["items[" + i + "].book.ID"];
                BookID = BookID.Replace(",", "");
                body.BookID = Convert.ToInt32(BookID);
                body.Discount=Convert.ToDecimal(Request.Form["items["+i+"].book.Discount"]);
                body.InHeadID = 0;
                body.Num = Convert.ToInt32(Request.Form["items[" + i + "].book.Num"]);
                body.Price = Convert.ToDecimal(Request.Form["items[" + i + "].book.Price"]);

                lst.Add(body);

                i++;     
            }
            BLL.T_Stock_In bll = new BLL.T_Stock_In();
            bool result = bll.Add(head, lst);
            if(result)
            {
                MODEL.Message message = new MODEL.Message();
                message = BookProject.Public.T_CloseSMess("InList", "InList", "添加入库单成功！");
                return Json(message);

            }
            else
            {
                MODEL.Message message = new MODEL.Message();
                message = BookProject.Public.T_CloseFMess("InList", "InList", "添加入库单失败！");
                return Json(message);
            }
        }
        //json方法来获取所需字段
        public ActionResult getjson()
        {
            BLL.T_DIC_Supplier bll = new BLL.T_DIC_Supplier();
            List<Model.T_DIC_Supplier> lst = bll.GetModelList("1=1");
            string json = "[";
            for (int i = 0; i < lst.Count; i++)
            {
                if (i == lst.Count-1)
                    json += " {\"ID\":\"" + lst[i].ID + "\", \"Name\":\"" + lst[i].NameEntity + "\", \"Phone\":\"" + lst[i].Phone + "\"}";
                else
                    json += " {\"ID\":\"" + lst[i].ID + "\", \"Name\":\"" + lst[i].NameEntity + "\", \"Phone\":\"" + lst[i].Phone + "\"},";
            }

            json += "]";
            return Content(json);
        }
        public ActionResult getjson2()
        { 
            BLL.T_DIC_Book bll=new BLL.T_DIC_Book();
            List<MODEL.T_DIC_Book> lst=bll.GETALL();
            string json2="[";
            for(int i=0;i<lst.Count;i++)
            {
                if(i==lst.Count-1)
                    json2+=" {\"ID\":\"" + lst[i].ID + "\", \"Name\":\"" + lst[i].Name + "\", \"Price\":\"" + lst[i].Pricing+ "\"}";
                else
                    json2+= " {\"ID\":\"" + lst[i].ID + "\", \"Name\":\"" + lst[i].Name + "\", \"Price\":\"" + lst[i].Pricing + "\"},";
            }
            json2 += "]";
            return Content(json2);
        }
/// <summary>
/// List Of Report
/// </summary>
/// <returns></returns>
        public ActionResult Report()
        {

            Book.BLL.V_Stock_Book bll = new Book.BLL.V_Stock_Book();

            //分页读取
            int PageSize = 5; //默认值
            int PageIndex = 1;//默认值
            string keywords=Convert.ToString(Request.Form["keyword"]);
            if (Request.Form["pageNum"] != null)
            {
                PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
                PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            }

            //读取该页数据

            DataSet ds = bll.GetListByPage("Name like '%" + keywords+"%'", "id", (PageIndex - 1) * PageSize, (PageIndex) * PageSize);
            List<Book.Model.V_Stock_Book> lst = bll.DataTableToList(ds.Tables[0]);
            //读取所有记录条数
            int TotalCount = bll.GetRecordCount("Name like '%" + keywords + "%'");

            ViewBag.TotalCount = TotalCount;
            ViewBag.PageSize = PageSize;
            ViewBag.PageIndex = PageIndex;
            ViewBag.lst = lst;
            return View();

        }
    }
}
