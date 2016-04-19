/**  版本信息模板在安装目录下，可自行修改。
* T_STOCK_OutHead.cs
*
* 功 能： N/A
* 类 名： T_STOCK_OutHead
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/1/4 15:02:16   N/A    初版
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
	/// T_STOCK_OutHead:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_STOCK_OutHead
	{
		public T_STOCK_OutHead()
		{}
		#region Model
		private int _id;
		private int? _guestid;
		private string _guestname;
		private DateTime? _ceatetime;
		private int? _userid;
		private string _username;
		private string _ordernumber;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GuestID
		{
			set{ _guestid=value;}
			get{return _guestid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestName
		{
			set{ _guestname=value;}
			get{return _guestname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CeateTime
		{
			set{ _ceatetime=value;}
			get{return _ceatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
		}
		#endregion Model

	}
}

