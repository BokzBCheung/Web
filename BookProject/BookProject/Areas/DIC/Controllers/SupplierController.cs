using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class2.Areas.DIC.Controllers
{
    public class SupplierController : Controller
    {
    /// <summary>
    /// 实现供应商的增删改查
    /// 分页功能和局部刷新
    /// </summary>
    /// <returns></returns>
    /// 
        //public ActionResult List()
        //{
        //    BLL.T_DIC_Supplier bll = new BLL.T_DIC_Supplier();
        //    DataSet ds= bll.GetAllList();
        //    List<Model.T_DIC_Supplier> lst= bll.DataTableToList(ds.Tables[0]);
        //    ViewBag.lst = lst;
        //    return View();
        //}
/// <summary>
/// List of Supplier
/// </summary>
/// <returns></returns>
        public ActionResult List() 
        {
            BLL.T_DIC_Supplier bll = new BLL.T_DIC_Supplier();
            int PageSize = 5;//默认值
            int PageIndex = 1;
            string keywords = Convert.ToString(Request.Form["keywords"]);
            if (Request.Form["pageNum"] != null)
            {
                PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
                PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            }
            //读取该页的数据
            DataSet ds = bll.GetListByPage("NameEntity like '%" + keywords + "%'", "id", (PageIndex - 1) * PageSize, PageIndex * PageSize);
            List<Model.T_DIC_Supplier> lst = bll.DataTableToList(ds.Tables[0]);
            int totalcount = bll.GetRecordCount("NameEntity like '%" + keywords + "%'");
            ViewBag.pagesize = PageSize;
            ViewBag.pageindex = PageIndex;
            ViewBag.lst = lst;
            ViewBag.totalcount = totalcount;
            return View();
        }
/// <summary>
/// AddSupplier
/// </summary>
/// <returns></returns>
        public ActionResult AddSupplier()
        {
            return View();
        }
        public JsonResult AddSupplierSave(Model.T_DIC_Supplier model)
        {
            BLL.T_DIC_Supplier bll = new BLL.T_DIC_Supplier();
            MODEL.Message message;
            int i = bll.Add(model);

            if (i > 0)
            { 
                message=BookProject.Public.T_CloseSMess("SupplierList","SupplierList","添加供应商成功！");
            }
            else
            {
                message=BookProject.Public.T_CloseFMess("SupplierList", "SupplierList", "添加供应商失败！");
            }
            return Json(message);
        }
/// <summary>
/// DeleteSupplier
/// </summary>
/// <param name="uid"></param>
/// <returns></returns>
        public JsonResult Delete(int uid)
        {
            BLL.T_DIC_Supplier bll = new BLL.T_DIC_Supplier();
            MODEL.Message message;
            if (bll.Delete(uid))
            {
                message = BookProject.Public.U_CloseSMess("SupplierList", "SupplierList", "删除供应商成功！");
            }
            else
            {
                message = BookProject.Public.U_CloseFMess("SupplierList", "SupplierList", "删除供应商失败！");
            }
            return Json(message);
        }
/// <summary>
/// EditSupplier
/// </summary>
/// <param name="uid"></param>
/// <returns></returns>
        public ActionResult EditSupplier(int uid)
        {
            BLL.T_DIC_Supplier bll = new BLL.T_DIC_Supplier();
            Model.T_DIC_Supplier model = bll.GetModel(uid);
            ViewBag.lst = model;
            return View();
        }
        public JsonResult EditSupplierSave(Model.T_DIC_Supplier model)
        {
            BLL.T_DIC_Supplier bll = new BLL.T_DIC_Supplier();
            bool result = bll.Update(model);
            MODEL.Message message;
            if (result)
            {
                message = BookProject.Public.T_CloseSMess("SupplierList", "SupplierList", "修改供应商成功！");
            }
            else
            {
                message = BookProject.Public.T_CloseFMess("SupplierList", "SupplierList", "修改供应商失败！");
            }
            return Json(message);
        }
    }
}
