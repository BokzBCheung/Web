/**  版本信息模板在安装目录下，可自行修改。
* T_Match_Student.cs
*
* 功 能： N/A
* 类 名： T_Match_Student
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
	/// 数据访问类:T_Match_Student
	/// </summary>
	public partial class T_Match_Student
	{
		public T_Match_Student()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SID", "T_Match_Student"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Match_Student");
			strSql.Append(" where SID=@SID");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)
			};
			parameters[0].Value = SID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Match.Model.T_Match_Student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Match_Student(");
			strSql.Append("SName,SNO,SCollege,SClass,SPhone,SGrade,SGender,SBirthday,SPwd)");
			strSql.Append(" values (");
			strSql.Append("@SName,@SNO,@SCollege,@SClass,@SPhone,@SGrade,@SGender,@SBirthday,@SPwd)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SName", SqlDbType.VarChar,255),
					new SqlParameter("@SNO", SqlDbType.NVarChar,11),
					new SqlParameter("@SCollege", SqlDbType.VarChar,255),
					new SqlParameter("@SClass", SqlDbType.VarChar,255),
					new SqlParameter("@SPhone", SqlDbType.VarChar,20),
					new SqlParameter("@SGrade", SqlDbType.Int,4),
					new SqlParameter("@SGender", SqlDbType.VarChar,10),
					new SqlParameter("@SBirthday", SqlDbType.DateTime),
					new SqlParameter("@SPwd", SqlDbType.VarChar,255)};
			parameters[0].Value = model.SName;
			parameters[1].Value = model.SNO;
			parameters[2].Value = model.SCollege;
			parameters[3].Value = model.SClass;
			parameters[4].Value = model.SPhone;
			parameters[5].Value = model.SGrade;
			parameters[6].Value = model.SGender;
			parameters[7].Value = model.SBirthday;
			parameters[8].Value = model.SPwd;

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
		public bool Update(Match.Model.T_Match_Student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Match_Student set ");
			strSql.Append("SName=@SName,");
			strSql.Append("SNO=@SNO,");
			strSql.Append("SCollege=@SCollege,");
			strSql.Append("SClass=@SClass,");
			strSql.Append("SPhone=@SPhone,");
			strSql.Append("SGrade=@SGrade,");
			strSql.Append("SGender=@SGender,");
			strSql.Append("SBirthday=@SBirthday,");
			strSql.Append("SPwd=@SPwd");
			strSql.Append(" where SID=@SID");
			SqlParameter[] parameters = {
					new SqlParameter("@SName", SqlDbType.VarChar,255),
					new SqlParameter("@SNO", SqlDbType.NVarChar,11),
					new SqlParameter("@SCollege", SqlDbType.VarChar,255),
					new SqlParameter("@SClass", SqlDbType.VarChar,255),
					new SqlParameter("@SPhone", SqlDbType.VarChar,20),
					new SqlParameter("@SGrade", SqlDbType.Int,4),
					new SqlParameter("@SGender", SqlDbType.VarChar,10),
					new SqlParameter("@SBirthday", SqlDbType.DateTime),
					new SqlParameter("@SPwd", SqlDbType.VarChar,255),
					new SqlParameter("@SID", SqlDbType.Int,4)};
			parameters[0].Value = model.SName;
			parameters[1].Value = model.SNO;
			parameters[2].Value = model.SCollege;
			parameters[3].Value = model.SClass;
			parameters[4].Value = model.SPhone;
			parameters[5].Value = model.SGrade;
			parameters[6].Value = model.SGender;
			parameters[7].Value = model.SBirthday;
			parameters[8].Value = model.SPwd;
			parameters[9].Value = model.SID;

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
		public bool Delete(int SID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_Student ");
			strSql.Append(" where SID=@SID");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)
			};
			parameters[0].Value = SID;

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
		public bool DeleteList(string SIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_Student ");
			strSql.Append(" where SID in ("+SIDlist + ")  ");
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
		public Match.Model.T_Match_Student GetModel(int SID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SID,SName,SNO,SCollege,SClass,SPhone,SGrade,SGender,SBirthday,SPwd from T_Match_Student ");
			strSql.Append(" where SID=@SID");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)
			};
			parameters[0].Value = SID;

			Match.Model.T_Match_Student model=new Match.Model.T_Match_Student();
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
		public Match.Model.T_Match_Student DataRowToModel(DataRow row)
		{
			Match.Model.T_Match_Student model=new Match.Model.T_Match_Student();
			if (row != null)
			{
				if(row["SID"]!=null && row["SID"].ToString()!="")
				{
					model.SID=int.Parse(row["SID"].ToString());
				}
				if(row["SName"]!=null)
				{
					model.SName=row["SName"].ToString();
				}
				if(row["SNO"]!=null)
				{
					model.SNO=row["SNO"].ToString();
				}
				if(row["SCollege"]!=null)
				{
					model.SCollege=row["SCollege"].ToString();
				}
				if(row["SClass"]!=null)
				{
					model.SClass=row["SClass"].ToString();
				}
				if(row["SPhone"]!=null)
				{
					model.SPhone=row["SPhone"].ToString();
				}
				if(row["SGrade"]!=null && row["SGrade"].ToString()!="")
				{
					model.SGrade=int.Parse(row["SGrade"].ToString());
				}
				if(row["SGender"]!=null)
				{
					model.SGender=row["SGender"].ToString();
				}
				if(row["SBirthday"]!=null && row["SBirthday"].ToString()!="")
				{
					model.SBirthday=DateTime.Parse(row["SBirthday"].ToString());
				}
				if(row["SPwd"]!=null)
				{
					model.SPwd=row["SPwd"].ToString();
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
			strSql.Append("select SID,SName,SNO,SCollege,SClass,SPhone,SGrade,SGender,SBirthday,SPwd ");
			strSql.Append(" FROM T_Match_Student ");
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
			strSql.Append(" SID,SName,SNO,SCollege,SClass,SPhone,SGrade,SGender,SBirthday,SPwd ");
			strSql.Append(" FROM T_Match_Student ");
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
			strSql.Append("select count(1) FROM T_Match_Student ");
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
				strSql.Append("order by T.SID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Match_Student T ");
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
			parameters[0].Value = "T_Match_Student";
			parameters[1].Value = "SID";
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

