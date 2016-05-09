using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class2.Areas.Stock.Controllers
{
    public class OutController : Controller
    {
        //
        // GET: /Stock/Out/

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// List of OutReport
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            Book.BLL.V_Stock_Out bll = new Book.BLL.V_Stock_Out();
            int PageSize = 5;//默认值
            int PageIndex = 1;
            string keywords = Convert.ToString(Request.Form["keywords"]);
            if (Request.Form["pageNum"] != null)
            {
                PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
                PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            }
            //读取该页的数据
            DataSet ds = bll.GetListByPage("id like '%" + keywords + "%'", "id", (PageIndex - 1) * PageSize, PageIndex * PageSize);
            List<Book.Model.V_Stock_Out> lst = bll.DataTableToList(ds.Tables[0]);
            int totalcount = bll.GetRecordCount("id like '%" + keywords + "%'");
            ViewBag.pagesize = PageSize;
            ViewBag.pageindex = PageIndex;
            ViewBag.lst = lst;
            ViewBag.totalcount = totalcount;
            return View();
        }


        /// <summary>
        /// AddOutReport
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            Book.BLL.V_Stock_Book bll = new Book.BLL.V_Stock_Book();
            List<Book.Model.V_Stock_Book> lst = bll.GetModelList("1=1");
            ViewBag.lst = lst;
            return View();
        }
        public JsonResult AddSave()
        {
            Book.Model.T_STOCK_OutHead head = new Book.Model.T_STOCK_OutHead();
            head.CeateTime = Convert.ToDateTime(Request.Form["CreateName"]);
            head.OrderNumber = Convert.ToString(Request.Form["OrderNumber"]);
            head.GuestID = Convert.ToInt32(Request.Form["json.ID"]);
            head.GuestName = Convert.ToString(Request.Form["json.Name"]);
            head.UserID = 1;
            head.UserName = "admin";

            List<Book.Model.T_STOCK_OutBody> lst = new List<Book.Model.T_STOCK_OutBody>();
            int i = 0;
            while (Request.Form["items[" + i + "].book.ID"] != null)
            {

                Book.Model.T_STOCK_OutBody body = new Book.Model.T_STOCK_OutBody();

                string BookID = Request.Form["items[" + i + "].book.ID"];
                BookID = BookID.Replace(",", "");
                body.BookID = Convert.ToInt32(BookID);
                body.Discount = Convert.ToDecimal(Request.Form["items[" + i + "].book.Discount"]);
                body.InHeadID = 0;
                body.Num = Convert.ToInt32(Request.Form["items[" + i + "].book.Num"]);
                body.Price = Convert.ToDecimal(Request.Form["items[" + i + "].book.Price"]);

                lst.Add(body);

                i++;
            }
            BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            bool result = bll.Add(head, lst);
            if (result)
            {
                MODEL.Message message = new MODEL.Message();
                message = BookProject.Public.T_CloseSMess("OutList", "OutList", "添加出库单成功！");
                return Json(message);

            }
            else
            {
                MODEL.Message message = new MODEL.Message();
                message = BookProject.Public.T_CloseFMess("InList", "InList", "添加入库单失败！");
                return Json(message);
            }
        }


        /// <summary>
        /// DeleteOutReport
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string ids)
        {
            Book.BLL.V_Stock_Out bll = new Book.BLL.V_Stock_Out();
            Book.BLL.T_STOCK_OutBody bll2 = new Book.BLL.T_STOCK_OutBody();
            //分离逗号的方法
            string[] list = ids.Split(',');
            int flag = 0;
            for (int i = 0; i < list.Length; i++)
            {
                bool result = bll.DeleteList(list[i]);
                bool result2 = bll.DeleteStr(list[i]);
                if (result && result2)
                    flag++;
            }
            if (flag > 0)
            {
                MODEL.Message message = BookProject.Public.U_CloseSMess("InList", "InList", "删除出库单成功！");
                return Json(message);
            }
            else
            {
                MODEL.Message message = BookProject.Public.U_CloseFMess("InList", "InList", "删除入库单失败！");
                return Json(message);
            }

        }
        /// <summary>
        /// EditOutReport
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ActionResult Edit(int uid)
        {
            Book.BLL.T_STOCK_OutHead bllHead= new Book.BLL.T_STOCK_OutHead();
            Book.Model.T_STOCK_OutHead head = bllHead.GetModel(uid);

            Book.BLL.V_Outbody_Book bllBody = new Book.BLL.V_Outbody_Book();
            List<Book.Model.V_Outbody_Book> lst = bllBody.GetModelList("InHeadID=" + uid);

            ViewBag.head = head;
            ViewBag.lst = lst;
            return View();
        }
        [HttpPost]
        public ActionResult EditSave()
        {
            Book.Model.T_STOCK_OutHead head = new Book.Model.T_STOCK_OutHead();
            head.ID = Convert.ToInt32(Request.Form["ID"]);
            head.CeateTime = Convert.ToDateTime(Request.Form["CreateTime"]);
            head.OrderNumber = Convert.ToString(Request.Form["OrderNumber"]);
            head.GuestID = Convert.ToInt32(Request.Form["json.ID"]);
            head.GuestName = Convert.ToString(Request.Form["json.Name"]);
            head.UserID = 1;
            head.UserName = "admin";

            List<Book.Model.T_STOCK_OutBody> lst = new List<Book.Model.T_STOCK_OutBody>();
            int i = 0;
            while (Request.Form["items[" + i + "].book.BookID"] != null)
            {

                Book.Model.T_STOCK_OutBody body = new Book.Model.T_STOCK_OutBody();

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

            BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            bool result = bll.EditSave(head, lst);
            if (result)
            {
                MODEL.Message message = BookProject.Public.T_CloseSMess("InList", "InList", "编辑出库单成功！");
                return Json(message);
            }
            else
            {
                MODEL.Message message = BookProject.Public.T_CloseFMess("InList", "InList", "编辑出库单失败！");
                return Json(message);
            }
        }
        /// <summary>
        /// json数据带回
        /// </summary>
        /// <returns></returns>
        public ActionResult getjson()
        {
            BLL.T_DIC_Guest bll = new BLL.T_DIC_Guest();
            List<MODEL.T_DIC_Guest> lst = bll.GetAll();
            string json = "[";
            for (int i = 0; i < lst.Count; i++)
            {
                if (i == lst.Count - 1)
                    json += " {\"ID\":\"" + lst[i].ID + "\", \"Name\":\"" + lst[i].NameEntity + "\", \"Phone\":\"" + lst[i].Phone + "\"}";
                else
                    json += " {\"ID\":\"" + lst[i].ID + "\", \"Name\":\"" + lst[i].NameEntity + "\", \"Phone\":\"" + lst[i].Phone + "\"},";
            }

            json += "]";
            return Content(json);
        }
        public ActionResult getjson2()
        {
            BLL.T_DIC_Book bll = new BLL.T_DIC_Book();
            List<MODEL.T_DIC_Book> lst = bll.GETALL();
            string json2 = "[";
            for (int i = 0; i < lst.Count; i++)
            {
                if (i == lst.Count - 1)
                    json2 += " {\"ID\":\"" + lst[i].ID + "\", \"Name\":\"" + lst[i].Name + "\", \"Price\":\"" + lst[i].Pricing + "\"}";
                else
                    json2 += " {\"ID\":\"" + lst[i].ID + "\", \"Name\":\"" + lst[i].Name + "\", \"Price\":\"" + lst[i].Pricing + "\"},";
            }
            json2 += "]";
            return Content(json2);
        }
    }
}
