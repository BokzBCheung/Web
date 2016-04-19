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
namespace Match.Model
{
	/// <summary>
	/// T_Match_Student:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Match_Student
	{
		public T_Match_Student()
		{}
		#region Model
		private int _sid;
		private string _sname;
		private string _sno;
		private string _scollege;
		private string _sclass;
		private string _sphone;
		private int? _sgrade;
		private string _sgender;
		private DateTime? _sbirthday;
		private string _spwd;
		/// <summary>
		/// 学生ID
		/// </summary>
		public int SID
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 学生姓名
		/// </summary>
		public string SName
		{
			set{ _sname=value;}
			get{return _sname;}
		}
		/// <summary>
		/// 学生学号
		/// </summary>
		public string SNO
		{
			set{ _sno=value;}
			get{return _sno;}
		}
		/// <summary>
		/// 学生所属学院
		/// </summary>
		public string SCollege
		{
			set{ _scollege=value;}
			get{return _scollege;}
		}
		/// <summary>
		/// 学生所属班级
		/// </summary>
		public string SClass
		{
			set{ _sclass=value;}
			get{return _sclass;}
		}
		/// <summary>
		/// 学生电话
		/// </summary>
		public string SPhone
		{
			set{ _sphone=value;}
			get{return _sphone;}
		}
		/// <summary>
		/// 学生所属年级
		/// </summary>
		public int? SGrade
		{
			set{ _sgrade=value;}
			get{return _sgrade;}
		}
		/// <summary>
		/// 学生性别
		/// </summary>
		public string SGender
		{
			set{ _sgender=value;}
			get{return _sgender;}
		}
		/// <summary>
		/// 学生出生日期
		/// </summary>
		public DateTime? SBirthday
		{
			set{ _sbirthday=value;}
			get{return _sbirthday;}
		}
		/// <summary>
		/// 学生密码
		/// </summary>
		public string SPwd
		{
			set{ _spwd=value;}
			get{return _spwd;}
		}
		#endregion Model

	}
}

