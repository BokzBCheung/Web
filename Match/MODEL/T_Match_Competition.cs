/**  版本信息模板在安装目录下，可自行修改。
* T_Match_Competition.cs
*
* 功 能： N/A
* 类 名： T_Match_Competition
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/9 12:47:43   N/A    初版
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
	/// T_Match_Competition:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Match_Competition
	{
		public T_Match_Competition()
		{}
		#region Model
		private int _cid;
		private string _cname;
		private string _cintroduce;
		private string _cattachment1;
		private string _cattachment2;
		private string _cattachment3;
		private DateTime? _cstarttime;
		private DateTime? _cendtime;
		private DateTime? _capplystime;
		private DateTime? _capplyetime;
		private int? _ctype;
		private int? _cpublisherid;
		private string _cpublishername;
		private int? _clevel;
		/// <summary>
		/// 竞赛表ID
		/// </summary>
		public int CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 比赛名称
		/// </summary>
		public string CName
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 比赛介绍
		/// </summary>
		public string CIntroduce
		{
			set{ _cintroduce=value;}
			get{return _cintroduce;}
		}
		/// <summary>
		/// 比赛附件1
		/// </summary>
		public string CAttachment1
		{
			set{ _cattachment1=value;}
			get{return _cattachment1;}
		}
		/// <summary>
		/// 比赛附件2
		/// </summary>
		public string CAttachment2
		{
			set{ _cattachment2=value;}
			get{return _cattachment2;}
		}
		/// <summary>
		/// 比赛附件3
		/// </summary>
		public string CAttachment3
		{
			set{ _cattachment3=value;}
			get{return _cattachment3;}
		}
		/// <summary>
		/// 比赛开始时间
		/// </summary>
		public DateTime? CStartTime
		{
			set{ _cstarttime=value;}
			get{return _cstarttime;}
		}
		/// <summary>
		/// 比赛截止时间
		/// </summary>
		public DateTime? CEndTime
		{
			set{ _cendtime=value;}
			get{return _cendtime;}
		}
		/// <summary>
		/// 报名开始时间
		/// </summary>
		public DateTime? CApplySTime
		{
			set{ _capplystime=value;}
			get{return _capplystime;}
		}
		/// <summary>
		/// 报名截止时间
		/// </summary>
		public DateTime? CApplyETime
		{
			set{ _capplyetime=value;}
			get{return _capplyetime;}
		}
		/// <summary>
		/// 比赛类型
		/// </summary>
		public int? CType
		{
			set{ _ctype=value;}
			get{return _ctype;}
		}
		/// <summary>
		/// 比赛发布者ID
		/// </summary>
		public int? CPublisherID
		{
			set{ _cpublisherid=value;}
			get{return _cpublisherid;}
		}
		/// <summary>
		/// 比赛发布者名字
		/// </summary>
		public string CPublisherName
		{
			set{ _cpublishername=value;}
			get{return _cpublishername;}
		}
		/// <summary>
		/// 比赛级别
		/// </summary>
		public int? CLevel
		{
			set{ _clevel=value;}
			get{return _clevel;}
		}
		#endregion Model

	}
}

