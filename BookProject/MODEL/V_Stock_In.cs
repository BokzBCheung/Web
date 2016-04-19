/**  版本信息模板在安装目录下，可自行修改。
* V_Stock_In.cs
*
* 功 能： N/A
* 类 名： V_Stock_In
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/11 13:58:38   N/A    初版
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
	/// V_Stock_In:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class V_Stock_In
	{
		public V_Stock_In()
		{}
		#region Model
		private int _id;
		private string _providername;
		private string _username;
		private DateTime? _ceatetime;
		private string _abstracts;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProviderName
		{
			set{ _providername=value;}
			get{return _providername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ceatetime
		{
			set{ _ceatetime=value;}
			get{return _ceatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string abstracts
		{
			set{ _abstracts=value;}
			get{return _abstracts;}
		}
		#endregion Model

	}
}

