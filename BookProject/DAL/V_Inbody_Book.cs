/**  版本信息模板在安装目录下，可自行修改。
* V_Inbody_Book.cs
*
* 功 能： N/A
* 类 名： V_Inbody_Book
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/11 13:58:36   N/A    初版
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
namespace Book.DAL
{
	/// <summary>
	/// 数据访问类:V_Inbody_Book
	/// </summary>
	public partial class V_Inbody_Book
	{
		public V_Inbody_Book()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Book.Model.V_Inbody_Book model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into V_Inbody_Book(");
			strSql.Append("ID,BookID,Discount,Num,Total,Price,InHeadID,Name)");
			strSql.Append(" values (");
			strSql.Append("@ID,@BookID,@Discount,@Num,@Total,@Price,@InHeadID,@Name)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BookID", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Decimal,5),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@Total", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@InHeadID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BookID;
			parameters[2].Value = model.Discount;
			parameters[3].Value = model.Num;
			parameters[4].Value = model.Total;
			parameters[5].Value = model.Price;
			parameters[6].Value = model.InHeadID;
			parameters[7].Value = model.Name;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Book.Model.V_Inbody_Book model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update V_Inbody_Book set ");
			strSql.Append("ID=@ID,");
			strSql.Append("BookID=@BookID,");
			strSql.Append("Discount=@Discount,");
			strSql.Append("Num=@Num,");
			strSql.Append("Total=@Total,");
			strSql.Append("Price=@Price,");
			strSql.Append("InHeadID=@InHeadID,");
			strSql.Append("Name=@Name");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BookID", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Decimal,5),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@Total", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@InHeadID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BookID;
			parameters[2].Value = model.Discount;
			parameters[3].Value = model.Num;
			parameters[4].Value = model.Total;
			parameters[5].Value = model.Price;
			parameters[6].Value = model.InHeadID;
			parameters[7].Value = model.Name;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from V_Inbody_Book ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Book.Model.V_Inbody_Book GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BookID,Discount,Num,Total,Price,InHeadID,Name from V_Inbody_Book ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Book.Model.V_Inbody_Book model=new Book.Model.V_Inbody_Book();
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
		public Book.Model.V_Inbody_Book DataRowToModel(DataRow row)
		{
			Book.Model.V_Inbody_Book model=new Book.Model.V_Inbody_Book();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["BookID"]!=null && row["BookID"].ToString()!="")
				{
					model.BookID=int.Parse(row["BookID"].ToString());
				}
				if(row["Discount"]!=null && row["Discount"].ToString()!="")
				{
					model.Discount=decimal.Parse(row["Discount"].ToString());
				}
				if(row["Num"]!=null && row["Num"].ToString()!="")
				{
					model.Num=int.Parse(row["Num"].ToString());
				}
				if(row["Total"]!=null && row["Total"].ToString()!="")
				{
					model.Total=decimal.Parse(row["Total"].ToString());
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
				}
				if(row["InHeadID"]!=null && row["InHeadID"].ToString()!="")
				{
					model.InHeadID=int.Parse(row["InHeadID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
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
			strSql.Append("select ID,BookID,Discount,Num,Total,Price,InHeadID,Name ");
			strSql.Append(" FROM V_Inbody_Book ");
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
			strSql.Append(" ID,BookID,Discount,Num,Total,Price,InHeadID,Name ");
			strSql.Append(" FROM V_Inbody_Book ");
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
			strSql.Append("select count(1) FROM V_Inbody_Book ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from V_Inbody_Book T ");
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
			parameters[0].Value = "V_Inbody_Book";
			parameters[1].Value = "";
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

