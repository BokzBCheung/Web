/**  版本信息模板在安装目录下，可自行修改。
* T_Match_Competition.cs
*
* 功 能： N/A
* 类 名： T_Match_Competition
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/9 12:47:43   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Match.Model;
namespace Match.BLL
{
	/// <summary>
	/// T_Match_Competition
	/// </summary>
	public partial class T_Match_Competition
	{
		private readonly Match.DAL.T_Match_Competition dal=new Match.DAL.T_Match_Competition();
		public T_Match_Competition()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CID)
		{
			return dal.Exists(CID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Match.Model.T_Match_Competition model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Match.Model.T_Match_Competition model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CID)
		{
			
			return dal.Delete(CID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CIDlist )
		{
			return dal.DeleteList(CIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Match.Model.T_Match_Competition GetModel(int CID)
		{
			
			return dal.GetModel(CID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Match.Model.T_Match_Competition GetModelByCache(int CID)
		{
			
			string CacheKey = "T_Match_CompetitionModel-" + CID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Match.Model.T_Match_Competition)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Match.Model.T_Match_Competition> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Match.Model.T_Match_Competition> DataTableToList(DataTable dt)
		{
			List<Match.Model.T_Match_Competition> modelList = new List<Match.Model.T_Match_Competition>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Match.Model.T_Match_Competition model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

