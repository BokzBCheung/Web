/**  版本信息模板在安装目录下，可自行修改。
* T_Match_DetailBody.cs
*
* 功 能： N/A
* 类 名： T_Match_DetailBody
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/9 15:13:24   N/A    初版
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
	/// 数据访问类:T_Match_DetailBody
	/// </summary>
	public partial class T_Match_DetailBody
	{
		public T_Match_DetailBody()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "T_Match_DetailBody"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Match_DetailBody");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Match.Model.T_Match_DetailBody model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Match_DetailBody(");
			strSql.Append("HeaderID,Competition ,Phone,Mail,Comments,StudentID)");
			strSql.Append(" values (");
			strSql.Append("@HeaderID,@Competition ,@Phone,@Mail,@Comments,@StudentID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@HeaderID", SqlDbType.Int,4),
					new SqlParameter("@Competition ", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,11),
					new SqlParameter("@Mail", SqlDbType.NVarChar,80),
					new SqlParameter("@Comments", SqlDbType.NVarChar,100),
					new SqlParameter("@StudentID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.HeaderID;
			parameters[1].Value = model.Competition ;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Mail;
			parameters[4].Value = model.Comments;
			parameters[5].Value = model.StudentID;

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
		public bool Update(Match.Model.T_Match_DetailBody model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Match_DetailBody set ");
			strSql.Append("HeaderID=@HeaderID,");
			strSql.Append("Competition =@Competition ,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Mail=@Mail,");
			strSql.Append("Comments=@Comments,");
			strSql.Append("StudentID=@StudentID");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@HeaderID", SqlDbType.Int,4),
					new SqlParameter("@Competition ", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,11),
					new SqlParameter("@Mail", SqlDbType.NVarChar,80),
					new SqlParameter("@Comments", SqlDbType.NVarChar,100),
					new SqlParameter("@StudentID", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.HeaderID;
			parameters[1].Value = model.Competition ;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Mail;
			parameters[4].Value = model.Comments;
			parameters[5].Value = model.StudentID;
			parameters[6].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_DetailBody ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_DetailBody ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Match.Model.T_Match_DetailBody GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,HeaderID,Competition ,Phone,Mail,Comments,StudentID from T_Match_DetailBody ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Match.Model.T_Match_DetailBody model=new Match.Model.T_Match_DetailBody();
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
		public Match.Model.T_Match_DetailBody DataRowToModel(DataRow row)
		{
			Match.Model.T_Match_DetailBody model=new Match.Model.T_Match_DetailBody();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["HeaderID"]!=null && row["HeaderID"].ToString()!="")
				{
					model.HeaderID=int.Parse(row["HeaderID"].ToString());
				}
				if(row["Competition "]!=null)
				{
					model.Competition =row["Competition "].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Mail"]!=null)
				{
					model.Mail=row["Mail"].ToString();
				}
				if(row["Comments"]!=null)
				{
					model.Comments=row["Comments"].ToString();
				}
				if(row["StudentID"]!=null)
				{
					model.StudentID=row["StudentID"].ToString();
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
			strSql.Append("select ID,HeaderID,Competition ,Phone,Mail,Comments,StudentID ");
			strSql.Append(" FROM T_Match_DetailBody ");
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
			strSql.Append(" ID,HeaderID,Competition ,Phone,Mail,Comments,StudentID ");
			strSql.Append(" FROM T_Match_DetailBody ");
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
			strSql.Append("select count(1) FROM T_Match_DetailBody ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Match_DetailBody T ");
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
			parameters[0].Value = "T_Match_DetailBody";
			parameters[1].Value = "ID";
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

