/**  版本信息模板在安装目录下，可自行修改。
* T_Match_Apply.cs
*
* 功 能： N/A
* 类 名： T_Match_Apply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/9 13:07:36   N/A    初版
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
	/// 数据访问类:T_Match_Apply
	/// </summary>
	public partial class T_Match_Apply
	{
		public T_Match_Apply()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AID", "T_Match_Apply"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Match_Apply");
			strSql.Append(" where AID=@AID");
			SqlParameter[] parameters = {
					new SqlParameter("@AID", SqlDbType.Int,4)
			};
			parameters[0].Value = AID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Match.Model.T_Match_Apply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Match_Apply(");
			strSql.Append("SID,CID,ATime,TID,AGroup)");
			strSql.Append(" values (");
			strSql.Append("@SID,@CID,@ATime,@TID,@AGroup)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@CID", SqlDbType.Int,4),
					new SqlParameter("@ATime", SqlDbType.DateTime),
					new SqlParameter("@TID", SqlDbType.Int,4),
					new SqlParameter("@AGroup", SqlDbType.Int,4)};
			parameters[0].Value = model.SID;
			parameters[1].Value = model.CID;
			parameters[2].Value = model.ATime;
			parameters[3].Value = model.TID;
			parameters[4].Value = model.AGroup;

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
		public bool Update(Match.Model.T_Match_Apply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Match_Apply set ");
			strSql.Append("SID=@SID,");
			strSql.Append("CID=@CID,");
			strSql.Append("ATime=@ATime,");
			strSql.Append("TID=@TID,");
			strSql.Append("AGroup=@AGroup");
			strSql.Append(" where AID=@AID");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@CID", SqlDbType.Int,4),
					new SqlParameter("@ATime", SqlDbType.DateTime),
					new SqlParameter("@TID", SqlDbType.Int,4),
					new SqlParameter("@AGroup", SqlDbType.Int,4),
					new SqlParameter("@AID", SqlDbType.Int,4)};
			parameters[0].Value = model.SID;
			parameters[1].Value = model.CID;
			parameters[2].Value = model.ATime;
			parameters[3].Value = model.TID;
			parameters[4].Value = model.AGroup;
			parameters[5].Value = model.AID;

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
		public bool Delete(int AID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_Apply ");
			strSql.Append(" where AID=@AID");
			SqlParameter[] parameters = {
					new SqlParameter("@AID", SqlDbType.Int,4)
			};
			parameters[0].Value = AID;

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
		public bool DeleteList(string AIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_Apply ");
			strSql.Append(" where AID in ("+AIDlist + ")  ");
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
		public Match.Model.T_Match_Apply GetModel(int AID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AID,SID,CID,ATime,TID,AGroup from T_Match_Apply ");
			strSql.Append(" where AID=@AID");
			SqlParameter[] parameters = {
					new SqlParameter("@AID", SqlDbType.Int,4)
			};
			parameters[0].Value = AID;

			Match.Model.T_Match_Apply model=new Match.Model.T_Match_Apply();
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
		public Match.Model.T_Match_Apply DataRowToModel(DataRow row)
		{
			Match.Model.T_Match_Apply model=new Match.Model.T_Match_Apply();
			if (row != null)
			{
				if(row["AID"]!=null && row["AID"].ToString()!="")
				{
					model.AID=int.Parse(row["AID"].ToString());
				}
				if(row["SID"]!=null && row["SID"].ToString()!="")
				{
					model.SID=int.Parse(row["SID"].ToString());
				}
				if(row["CID"]!=null && row["CID"].ToString()!="")
				{
					model.CID=int.Parse(row["CID"].ToString());
				}
				if(row["ATime"]!=null && row["ATime"].ToString()!="")
				{
					model.ATime=DateTime.Parse(row["ATime"].ToString());
				}
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=int.Parse(row["TID"].ToString());
				}
				if(row["AGroup"]!=null && row["AGroup"].ToString()!="")
				{
					model.AGroup=int.Parse(row["AGroup"].ToString());
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
			strSql.Append("select AID,SID,CID,ATime,TID,AGroup ");
			strSql.Append(" FROM T_Match_Apply ");
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
			strSql.Append(" AID,SID,CID,ATime,TID,AGroup ");
			strSql.Append(" FROM T_Match_Apply ");
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
			strSql.Append("select count(1) FROM T_Match_Apply ");
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
				strSql.Append("order by T.AID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Match_Apply T ");
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
			parameters[0].Value = "T_Match_Apply";
			parameters[1].Value = "AID";
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

