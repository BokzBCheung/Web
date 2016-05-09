/**  版本信息模板在安装目录下，可自行修改。
* T_STOCK_InHead.cs
*
* 功 能： N/A
* 类 名： T_STOCK_InHead
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
	/// T_STOCK_InHead:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_STOCK_InHead
	{
		public T_STOCK_InHead()
		{}
		#region Model
		private int _id;
		private int? _providerid;
		private string _providername;
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
		/// 供应商id
		/// </summary>
		public int? ProviderID
		{
			set{ _providerid=value;}
			get{return _providerid;}
		}
		/// <summary>
		/// 供应商名字(冗余)
		/// </summary>
		public string ProviderName
		{
			set{ _providername=value;}
			get{return _providername;}
		}
		/// <summary>
		/// 制单时间
		/// </summary>
		public DateTime? CeateTime
		{
			set{ _ceatetime=value;}
			get{return _ceatetime;}
		}
		/// <summary>
		/// 操作人id
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 操作人名字(冗余)
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 关联单据
		/// </summary>
		public string OrderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
		}
		#endregion Model

	}
}

