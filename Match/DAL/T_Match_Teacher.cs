/**  版本信息模板在安装目录下，可自行修改。
* T_Match_Teacher.cs
*
* 功 能： N/A
* 类 名： T_Match_Teacher
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/9 13:07:35   N/A    初版
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
	/// 数据访问类:T_Match_Teacher
	/// </summary>
	public partial class T_Match_Teacher
	{
		public T_Match_Teacher()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TID", "T_Match_Teacher"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Match_Teacher");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int,4)
			};
			parameters[0].Value = TID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Match.Model.T_Match_Teacher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Match_Teacher(");
			strSql.Append("TName,TGender,TCollege,TDepartment,TTitle,TPhone,TPwd)");
			strSql.Append(" values (");
			strSql.Append("@TName,@TGender,@TCollege,@TDepartment,@TTitle,@TPhone,@TPwd)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TName", SqlDbType.VarChar,255),
					new SqlParameter("@TGender", SqlDbType.VarChar,10),
					new SqlParameter("@TCollege", SqlDbType.VarChar,255),
					new SqlParameter("@TDepartment", SqlDbType.VarChar,255),
					new SqlParameter("@TTitle", SqlDbType.VarChar,255),
					new SqlParameter("@TPhone", SqlDbType.VarChar,20),
					new SqlParameter("@TPwd", SqlDbType.VarChar,255)};
			parameters[0].Value = model.TName;
			parameters[1].Value = model.TGender;
			parameters[2].Value = model.TCollege;
			parameters[3].Value = model.TDepartment;
			parameters[4].Value = model.TTitle;
			parameters[5].Value = model.TPhone;
			parameters[6].Value = model.TPwd;

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
		public bool Update(Match.Model.T_Match_Teacher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Match_Teacher set ");
			strSql.Append("TName=@TName,");
			strSql.Append("TGender=@TGender,");
			strSql.Append("TCollege=@TCollege,");
			strSql.Append("TDepartment=@TDepartment,");
			strSql.Append("TTitle=@TTitle,");
			strSql.Append("TPhone=@TPhone,");
			strSql.Append("TPwd=@TPwd");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TName", SqlDbType.VarChar,255),
					new SqlParameter("@TGender", SqlDbType.VarChar,10),
					new SqlParameter("@TCollege", SqlDbType.VarChar,255),
					new SqlParameter("@TDepartment", SqlDbType.VarChar,255),
					new SqlParameter("@TTitle", SqlDbType.VarChar,255),
					new SqlParameter("@TPhone", SqlDbType.VarChar,20),
					new SqlParameter("@TPwd", SqlDbType.VarChar,255),
					new SqlParameter("@TID", SqlDbType.Int,4)};
			parameters[0].Value = model.TName;
			parameters[1].Value = model.TGender;
			parameters[2].Value = model.TCollege;
			parameters[3].Value = model.TDepartment;
			parameters[4].Value = model.TTitle;
			parameters[5].Value = model.TPhone;
			parameters[6].Value = model.TPwd;
			parameters[7].Value = model.TID;

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
		public bool Delete(int TID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_Teacher ");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int,4)
			};
			parameters[0].Value = TID;

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
		public bool DeleteList(string TIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_Teacher ");
			strSql.Append(" where TID in ("+TIDlist + ")  ");
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
		public Match.Model.T_Match_Teacher GetModel(int TID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TID,TName,TGender,TCollege,TDepartment,TTitle,TPhone,TPwd from T_Match_Teacher ");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int,4)
			};
			parameters[0].Value = TID;

			Match.Model.T_Match_Teacher model=new Match.Model.T_Match_Teacher();
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
		public Match.Model.T_Match_Teacher DataRowToModel(DataRow row)
		{
			Match.Model.T_Match_Teacher model=new Match.Model.T_Match_Teacher();
			if (row != null)
			{
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=int.Parse(row["TID"].ToString());
				}
				if(row["TName"]!=null)
				{
					model.TName=row["TName"].ToString();
				}
				if(row["TGender"]!=null)
				{
					model.TGender=row["TGender"].ToString();
				}
				if(row["TCollege"]!=null)
				{
					model.TCollege=row["TCollege"].ToString();
				}
				if(row["TDepartment"]!=null)
				{
					model.TDepartment=row["TDepartment"].ToString();
				}
				if(row["TTitle"]!=null)
				{
					model.TTitle=row["TTitle"].ToString();
				}
				if(row["TPhone"]!=null)
				{
					model.TPhone=row["TPhone"].ToString();
				}
				if(row["TPwd"]!=null)
				{
					model.TPwd=row["TPwd"].ToString();
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
			strSql.Append("select TID,TName,TGender,TCollege,TDepartment,TTitle,TPhone,TPwd ");
			strSql.Append(" FROM T_Match_Teacher ");
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
			strSql.Append(" TID,TName,TGender,TCollege,TDepartment,TTitle,TPhone,TPwd ");
			strSql.Append(" FROM T_Match_Teacher ");
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
			strSql.Append("select count(1) FROM T_Match_Teacher ");
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
				strSql.Append("order by T.TID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Match_Teacher T ");
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
			parameters[0].Value = "T_Match_Teacher";
			parameters[1].Value = "TID";
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

