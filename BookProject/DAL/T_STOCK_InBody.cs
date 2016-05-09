/**  版本信息模板在安装目录下，可自行修改。
* T_STOCK_InBody.cs
*
* 功 能： N/A
* 类 名： T_STOCK_InBody
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/11/27 14:03:47   N/A    初版
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
	/// 数据访问类:T_STOCK_InBody
	/// </summary>
	public partial class T_STOCK_InBody
	{
		public T_STOCK_InBody()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "T_STOCK_InBody"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_STOCK_InBody");
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
		public int Add(Book.Model.T_STOCK_InBody model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_STOCK_InBody(");
			strSql.Append("BookID,Discount,Num,Total,Price,InHeadID)");
			strSql.Append(" values (");
			strSql.Append("@BookID,@Discount,@Num,@Total,@Price,@InHeadID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BookID", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Decimal,5),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@Total", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@InHeadID", SqlDbType.Int,4)};
			parameters[0].Value = model.BookID;
			parameters[1].Value = model.Discount;
			parameters[2].Value = model.Num;
			parameters[3].Value = model.Total;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.InHeadID;

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
		public bool Update(Book.Model.T_STOCK_InBody model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_STOCK_InBody set ");
			strSql.Append("BookID=@BookID,");
			strSql.Append("Discount=@Discount,");
			strSql.Append("Num=@Num,");
			strSql.Append("Total=@Total,");
			strSql.Append("Price=@Price,");
			strSql.Append("InHeadID=@InHeadID");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@BookID", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Decimal,5),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@Total", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@InHeadID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.BookID;
			parameters[1].Value = model.Discount;
			parameters[2].Value = model.Num;
			parameters[3].Value = model.Total;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.InHeadID;
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
			strSql.Append("delete from T_STOCK_InBody ");
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
			strSql.Append("delete from T_STOCK_InBody ");
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
		public Book.Model.T_STOCK_InBody GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BookID,Discount,Num,Total,Price,InHeadID from T_STOCK_InBody ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Book.Model.T_STOCK_InBody model=new Book.Model.T_STOCK_InBody();
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
		public Book.Model.T_STOCK_InBody DataRowToModel(DataRow row)
		{
			Book.Model.T_STOCK_InBody model=new Book.Model.T_STOCK_InBody();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,BookID,Discount,Num,Total,Price,InHeadID ");
			strSql.Append(" FROM T_STOCK_InBody ");
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
			strSql.Append(" ID,BookID,Discount,Num,Total,Price,InHeadID ");
			strSql.Append(" FROM T_STOCK_InBody ");
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
			strSql.Append("select count(1) FROM T_STOCK_InBody ");
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
			strSql.Append(")AS Row, T.*  from T_STOCK_InBody T ");
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
			parameters[0].Value = "T_STOCK_InBody";
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

        public bool DeleteByHeadid(int headid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_STOCK_InBody ");
            strSql.Append(" where Inheadid=@headid");
            SqlParameter[] parameters = {
					new SqlParameter("@headid", SqlDbType.Int,4)
			};
            parameters[0].Value = headid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

