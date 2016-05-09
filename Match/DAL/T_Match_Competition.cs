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
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Match.DAL
{
	/// <summary>
	/// 数据访问类:T_Match_Competition
	/// </summary>
	public partial class T_Match_Competition
	{
		public T_Match_Competition()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CID", "T_Match_Competition"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Match_Competition");
			strSql.Append(" where CID=@CID");
			SqlParameter[] parameters = {
					new SqlParameter("@CID", SqlDbType.Int,4)
			};
			parameters[0].Value = CID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Match.Model.T_Match_Competition model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Match_Competition(");
			strSql.Append("CName,CIntroduce,CAttachment1,CAttachment2,CAttachment3,CStartTime,CEndTime,CApplySTime,CApplyETime,CType,CPublisherID,CPublisherName,CLevel)");
			strSql.Append(" values (");
			strSql.Append("@CName,@CIntroduce,@CAttachment1,@CAttachment2,@CAttachment3,@CStartTime,@CEndTime,@CApplySTime,@CApplyETime,@CType,@CPublisherID,@CPublisherName,@CLevel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CName", SqlDbType.VarChar,100),
					new SqlParameter("@CIntroduce", SqlDbType.NVarChar,-1),
					new SqlParameter("@CAttachment1", SqlDbType.VarChar,255),
					new SqlParameter("@CAttachment2", SqlDbType.VarChar,255),
					new SqlParameter("@CAttachment3", SqlDbType.VarChar,255),
					new SqlParameter("@CStartTime", SqlDbType.DateTime),
					new SqlParameter("@CEndTime", SqlDbType.DateTime),
					new SqlParameter("@CApplySTime", SqlDbType.DateTime),
					new SqlParameter("@CApplyETime", SqlDbType.DateTime),
					new SqlParameter("@CType", SqlDbType.Int,4),
					new SqlParameter("@CPublisherID", SqlDbType.Int,4),
					new SqlParameter("@CPublisherName", SqlDbType.VarChar,255),
					new SqlParameter("@CLevel", SqlDbType.Int,4)};
			parameters[0].Value = model.CName;
			parameters[1].Value = model.CIntroduce;
			parameters[2].Value = model.CAttachment1;
			parameters[3].Value = model.CAttachment2;
			parameters[4].Value = model.CAttachment3;
			parameters[5].Value = model.CStartTime;
			parameters[6].Value = model.CEndTime;
			parameters[7].Value = model.CApplySTime;
			parameters[8].Value = model.CApplyETime;
			parameters[9].Value = model.CType;
			parameters[10].Value = model.CPublisherID;
			parameters[11].Value = model.CPublisherName;
			parameters[12].Value = model.CLevel;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Match.Model.T_Match_Competition model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Match_Competition set ");
			strSql.Append("CName=@CName,");
			strSql.Append("CIntroduce=@CIntroduce,");
			strSql.Append("CAttachment1=@CAttachment1,");
			strSql.Append("CAttachment2=@CAttachment2,");
			strSql.Append("CAttachment3=@CAttachment3,");
			strSql.Append("CStartTime=@CStartTime,");
			strSql.Append("CEndTime=@CEndTime,");
			strSql.Append("CApplySTime=@CApplySTime,");
			strSql.Append("CApplyETime=@CApplyETime,");
			strSql.Append("CType=@CType,");
			strSql.Append("CPublisherID=@CPublisherID,");
			strSql.Append("CPublisherName=@CPublisherName,");
			strSql.Append("CLevel=@CLevel");
			strSql.Append(" where CID=@CID");
			SqlParameter[] parameters = {
					new SqlParameter("@CName", SqlDbType.VarChar,100),
					new SqlParameter("@CIntroduce", SqlDbType.NVarChar,-1),
					new SqlParameter("@CAttachment1", SqlDbType.VarChar,255),
					new SqlParameter("@CAttachment2", SqlDbType.VarChar,255),
					new SqlParameter("@CAttachment3", SqlDbType.VarChar,255),
					new SqlParameter("@CStartTime", SqlDbType.DateTime),
					new SqlParameter("@CEndTime", SqlDbType.DateTime),
					new SqlParameter("@CApplySTime", SqlDbType.DateTime),
					new SqlParameter("@CApplyETime", SqlDbType.DateTime),
					new SqlParameter("@CType", SqlDbType.Int,4),
					new SqlParameter("@CPublisherID", SqlDbType.Int,4),
					new SqlParameter("@CPublisherName", SqlDbType.VarChar,255),
					new SqlParameter("@CLevel", SqlDbType.Int,4),
					new SqlParameter("@CID", SqlDbType.Int,4)};
			parameters[0].Value = model.CName;
			parameters[1].Value = model.CIntroduce;
			parameters[2].Value = model.CAttachment1;
			parameters[3].Value = model.CAttachment2;
			parameters[4].Value = model.CAttachment3;
			parameters[5].Value = model.CStartTime;
			parameters[6].Value = model.CEndTime;
			parameters[7].Value = model.CApplySTime;
			parameters[8].Value = model.CApplyETime;
			parameters[9].Value = model.CType;
			parameters[10].Value = model.CPublisherID;
			parameters[11].Value = model.CPublisherName;
			parameters[12].Value = model.CLevel;
			parameters[13].Value = model.CID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_Competition ");
			strSql.Append(" where CID=@CID");
			SqlParameter[] parameters = {
					new SqlParameter("@CID", SqlDbType.Int,4)
			};
			parameters[0].Value = CID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string CIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_Competition ");
			strSql.Append(" where CID in ("+CIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Match.Model.T_Match_Competition GetModel(int CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CID,CName,CIntroduce,CAttachment1,CAttachment2,CAttachment3,CStartTime,CEndTime,CApplySTime,CApplyETime,CType,CPublisherID,CPublisherName,CLevel from T_Match_Competition ");
			strSql.Append(" where CID=@CID");
			SqlParameter[] parameters = {
					new SqlParameter("@CID", SqlDbType.Int,4)
			};
			parameters[0].Value = CID;

			Match.Model.T_Match_Competition model=new Match.Model.T_Match_Competition();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Match.Model.T_Match_Competition DataRowToModel(DataRow row)
		{
			Match.Model.T_Match_Competition model=new Match.Model.T_Match_Competition();
			if (row != null)
			{
				if(row["CID"]!=null && row["CID"].ToString()!="")
				{
					model.CID=int.Parse(row["CID"].ToString());
				}
				if(row["CName"]!=null)
				{
					model.CName=row["CName"].ToString();
				}
				if(row["CIntroduce"]!=null)
				{
					model.CIntroduce=row["CIntroduce"].ToString();
				}
				if(row["CAttachment1"]!=null)
				{
					model.CAttachment1=row["CAttachment1"].ToString();
				}
				if(row["CAttachment2"]!=null)
				{
					model.CAttachment2=row["CAttachment2"].ToString();
				}
				if(row["CAttachment3"]!=null)
				{
					model.CAttachment3=row["CAttachment3"].ToString();
				}
				if(row["CStartTime"]!=null && row["CStartTime"].ToString()!="")
				{
					model.CStartTime=DateTime.Parse(row["CStartTime"].ToString());
				}
				if(row["CEndTime"]!=null && row["CEndTime"].ToString()!="")
				{
					model.CEndTime=DateTime.Parse(row["CEndTime"].ToString());
				}
				if(row["CApplySTime"]!=null && row["CApplySTime"].ToString()!="")
				{
					model.CApplySTime=DateTime.Parse(row["CApplySTime"].ToString());
				}
				if(row["CApplyETime"]!=null && row["CApplyETime"].ToString()!="")
				{
					model.CApplyETime=DateTime.Parse(row["CApplyETime"].ToString());
				}
				if(row["CType"]!=null && row["CType"].ToString()!="")
				{
					model.CType=int.Parse(row["CType"].ToString());
				}
				if(row["CPublisherID"]!=null && row["CPublisherID"].ToString()!="")
				{
					model.CPublisherID=int.Parse(row["CPublisherID"].ToString());
				}
				if(row["CPublisherName"]!=null)
				{
					model.CPublisherName=row["CPublisherName"].ToString();
				}
				if(row["CLevel"]!=null && row["CLevel"].ToString()!="")
				{
					model.CLevel=int.Parse(row["CLevel"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CID,CName,CIntroduce,CAttachment1,CAttachment2,CAttachment3,CStartTime,CEndTime,CApplySTime,CApplyETime,CType,CPublisherID,CPublisherName,CLevel ");
			strSql.Append(" FROM T_Match_Competition ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" CID,CName,CIntroduce,CAttachment1,CAttachment2,CAttachment3,CStartTime,CEndTime,CApplySTime,CApplyETime,CType,CPublisherID,CPublisherName,CLevel ");
			strSql.Append(" FROM T_Match_Competition ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_Match_Competition ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.CID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Match_Competition T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_Match_Competition";
			parameters[1].Value = "CID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

