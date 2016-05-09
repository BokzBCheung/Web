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
namespace Match.Model
{
	/// <summary>
	/// T_Match_DetailBody:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Match_DetailBody
	{
		public T_Match_DetailBody()
		{}
		#region Model
		private int _id;
		private int _headerid;
		private string _competition ;
		private string _phone;
		private string _mail;
		private string _comments;
		private string _studentid;
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
		public int HeaderID
		{
			set{ _headerid=value;}
			get{return _headerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Competition 
		{
			set{ _competition =value;}
			get{return _competition ;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mail
		{
			set{ _mail=value;}
			get{return _mail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Comments
		{
			set{ _comments=value;}
			get{return _comments;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentID
		{
			set{ _studentid=value;}
			get{return _studentid;}
		}
		#endregion Model

	}
}

