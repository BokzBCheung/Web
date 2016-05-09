/**  版本信息模板在安装目录下，可自行修改。
* T_DIC_Supplier.cs
*
* 功 能： N/A
* 类 名： T_DIC_Supplier
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/11/27 15:32:24   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model
{
	/// <summary>
	/// T_DIC_Supplier:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_DIC_Supplier
	{
		public T_DIC_Supplier()
		{}
		#region Model
		private int _id;
		private string _coding;
		private string _nameentity;
		private string _addressentity;
		private string _contact;
		private string _phone;
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
		public string Coding
		{
			set{ _coding=value;}
			get{return _coding;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NameEntity
		{
			set{ _nameentity=value;}
			get{return _nameentity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AddressEntity
		{
			set{ _addressentity=value;}
			get{return _addressentity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		#endregion Model

	}
}

