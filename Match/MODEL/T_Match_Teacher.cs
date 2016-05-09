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
namespace Match.Model
{
	/// <summary>
	/// T_Match_Teacher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Match_Teacher
	{
		public T_Match_Teacher()
		{}
		#region Model
		private int _tid;
		private string _tname;
		private string _tgender;
		private string _tcollege;
		private string _tdepartment;
		private string _ttitle;
		private string _tphone;
		private string _tpwd;
		/// <summary>
		/// 老师ID
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 老师姓名
		/// </summary>
		public string TName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		/// <summary>
		/// 老师性别
		/// </summary>
		public string TGender
		{
			set{ _tgender=value;}
			get{return _tgender;}
		}
		/// <summary>
		/// 老师所属学院
		/// </summary>
		public string TCollege
		{
			set{ _tcollege=value;}
			get{return _tcollege;}
		}
		/// <summary>
		/// 老师所属系
		/// </summary>
		public string TDepartment
		{
			set{ _tdepartment=value;}
			get{return _tdepartment;}
		}
		/// <summary>
		/// 老师职称
		/// </summary>
		public string TTitle
		{
			set{ _ttitle=value;}
			get{return _ttitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TPhone
		{
			set{ _tphone=value;}
			get{return _tphone;}
		}
		/// <summary>
		/// 老师密码
		/// </summary>
		public string TPwd
		{
			set{ _tpwd=value;}
			get{return _tpwd;}
		}
		#endregion Model

	}
}

