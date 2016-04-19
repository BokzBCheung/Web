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
namespace Book.Model
{
	/// <summary>
	/// T_STOCK_InBody:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_STOCK_InBody
	{
		public T_STOCK_InBody()
		{}
		#region Model
		private int _id;
		private int? _bookid;
		private decimal? _discount;
		private int? _num;
		private decimal? _total;
		private decimal? _price;
		private int? _inheadid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 书籍id(外键)
		/// </summary>
		public int? BookID
		{
			set{ _bookid=value;}
			get{return _bookid;}
		}
		/// <summary>
		/// 折扣
		/// </summary>
		public decimal? Discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int? Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 总额
		/// </summary>
		public decimal? Total
		{
			set{ _total=value;}
			get{return _total;}
		}
		/// <summary>
		/// 单价
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? InHeadID
		{
			set{ _inheadid=value;}
			get{return _inheadid;}
		}
		#endregion Model

	}
}

