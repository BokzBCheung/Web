using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Match.Areas.Match.Controllers
{
    public class MatDetailController : Controller
    {
        //
        // GET: /Match/MatDetial/
        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            BLL.T_Match_Competition bll = new BLL.T_Match_Competition();
            //List<Model.T_Match_Competition> lst = bll.GetModelList("1=1");
            int PageSize = 10;//默认值
            int PageIndex = 1;
            string keywords = Convert.ToString(Request.Form["keywords"]);
            if (Request.Form["pageNum"] != null)
            {
                PageSize = Convert.ToInt32(Request.Form["numPerPage"]);
                PageIndex = Convert.ToInt32(Request.Form["pageNum"]);
            }
            //读取该页的数据
            DataSet ds = bll.GetListByPage("CName like '%" + keywords + "%'", "CID", (PageIndex-1) * PageSize+1, PageIndex * PageSize);
            List<Model.T_Match_Competition> lst = bll.DataTableToList(ds.Tables[0]);
            int totalcount = bll.GetRecordCount("CName like '%" + keywords + "%'");
            ViewBag.pagesize = PageSize;
            ViewBag.pageindex = PageIndex;
            ViewBag.lst = lst;
            ViewBag.totalcount = totalcount;

            return View();
        }

        /// <summary>
        /// Delete Competiton
        /// </summary>
        /// <returns></returns>
        public JsonResult Delete(int uid)
        {
            BLL.T_Match_Competition bll = new BLL.T_Match_Competition();
            bool result = bll.Delete(uid);
            if (result)
            {
                Model.Message message = new Model.Message();
                message.statusCode = "200";
                message.message = "删除比赛成功！";
                message.navTabId = "CompetitonList";
                message.rel = "CompetitonList";
                message.forwardUrl = "CompetitonList";
                message.callbackType = "";

                return Json(message);
            }
           ///删除比赛成功返回
            else
            {
                Model.Message message = new Model.Message();
                message.statusCode = "300";
                message.message = "删除比赛失败！";
                message.navTabId = "CompetitonList";
                message.rel = "CompetitonList";
                message.forwardUrl = "CompetitonList";
                message.callbackType = "";

                return Json(message);
            }
            ///删除比赛失败返回
        }

        /// <summary>
        /// Add Competition
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
        public JsonResult AddSave(Model.T_Match_Competition model)
        {
            BLL.T_Match_Competition bll=new BLL.T_Match_Competition();
            int result = bll.Add(model);
            //提示发布状态
            #region 
            if (result>0)
            {
                Model.Message message = new Model.Message();
                message.statusCode = "200";
                message.message = "发布比赛成功！";
                message.navTabId = "CompetitonList";
                message.rel = "CompetitonList";
                message.forwardUrl = "CompetitonList";
                message.callbackType = "closeCurrent";

                return Json(message);
            }
            ///删除比赛成功返回
            else
            {
                Model.Message message = new Model.Message();
                message.statusCode = "300";
                message.message = "发布比赛失败！";
                message.navTabId = "CompetitonList";
                message.rel = "CompetitonList";
                message.forwardUrl = "CompetitonList";
                message.callbackType = "closeCurrent";

                return Json(message);
            }
            #endregion
        }
        /// <summary>
        /// Edit Competiton
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int uid)
        {
            BLL.T_Match_Competition bll = new BLL.T_Match_Competition();
            Model.T_Match_Competition model = bll.GetModel(uid);
            ViewBag.lst = model;
            return View();
        }
        public JsonResult EditSave(Model.T_Match_Competition model)
        {
            BLL.T_Match_Competition bll = new BLL.T_Match_Competition();
            bool result = bll.Update(model);
            //提示修改状态
            #region
            if (result)
            {
                Model.Message message = new Model.Message();
                message.statusCode = "200";
                message.message = "修改比赛成功！";
                message.navTabId = "CompetitonList";
                message.rel = "CompetitonList";
                message.forwardUrl = "CompetitonList";
                message.callbackType = "closeCurrent";

                return Json(message);
            }
            ///删除比赛成功返回
            else
            {
                Model.Message message = new Model.Message();
                message.statusCode = "300";
                message.message = "修改比赛失败！";
                message.navTabId = "CompetitonList";
                message.rel = "CompetitonList";
                message.forwardUrl = "CompetitonList";
                message.callbackType = "closeCurrent";

                return Json(message);
            }
            #endregion
        }

        /// <summary>
        /// Download Excel
        /// </summary>
        public void Download()
        {
            //接收需要导出的数据
            BLL.T_Match_Competition bll = new BLL.T_Match_Competition();
            List<Model.T_Match_Competition> list = bll.DataTableToList(bll.GetList("1=1 order by CName asc").Tables[0]);
            //命名导出表格的StringBuilder变量
            System.Text.StringBuilder sHtml = new System.Text.StringBuilder(string.Empty);
            //打印表头
            sHtml.Append("<table border=\"1\" width=\"100%\">");
            //sHtml.Append("<tr height=\"40\"><td colspan=\"5\" align=\"center\" style='font-size:24px'><b>学生表" + "</b></td></tr>");

            //打印列名
            sHtml.Append("<tr height=\"20\" align=\"center\"><td>姓名</td><td>介绍</td><td>附件</td><td>开始时间</td><td>结束时间</td><td>报名开始</td><td>报名结束</td><td>发布者</td></tr>");

            //循环读取List集合 
            for (int i = 0; i < list.Count; i++)
            {
                sHtml.Append("<tr height=\"20\" align=\"center\"><td>" + list[i].CName + "</td><td>" + list[i].CIntroduce+ "</td><td>" + list[i].CAttachment1 + "</td><td>" + list[i].CStartTime + "</td><td>" + list[i].CEndTime + "</td><td>" + list[i].CApplySTime + "</td><td>" + list[i].CApplyETime + "</td><td>" + list[i].CPublisherName + "</td></tr>");
            }
            //打印表尾
            //   sHtml.Append("<tr height=\"40\"><td align=\"center\" colspan=\"5\" style='background-color:#CD0000;font-size:24px'><b>XXXXXXXX</a> </b></td></tr>");
            sHtml.Append("</table>");
            //调用输出Excel表的方法
            ExportToExcel("application/ms-excel", "比赛表.xls", sHtml.ToString());
        }
        public void ExportToExcel(string FileType, string FileName, string ExcelContent)
        {
            System.Web.HttpContext.Current.Response.Charset = "UTF-8";
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8).ToString());
            System.Web.HttpContext.Current.Response.ContentType = FileType;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.HttpContext.Current.Response.Output.Write(ExcelContent.ToString());
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }

        //public ActionResult List()
        //{
        //    BLL.T_Match_DetailHeader bll1 = new BLL.T_Match_DetailHeader();
        //    //BLL.T_Match_DetailBody bll2 = new BLL.T_Match_DetailBody();
        //    List<Model.T_Match_DetailHeader> lst1 = bll1.GetModelList("1=1");
        //    //List<Model.T_Match_DetailBody> lst2 = bll2.GetModelList("1=1");
        //    ViewBag.lst1 = lst1;
        //    //ViewBag.lst2 = lst2;

        //    return View();
        //}

    }
}
