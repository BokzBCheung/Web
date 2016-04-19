/**  版本信息模板在安装目录下，可自行修改。
* T_Match_Apply.cs
*
* 功 能： N/A
* 类 名： T_Match_Apply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/9 13:07:36   N/A    初版
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
	/// T_Match_Apply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Match_Apply
	{
		public T_Match_Apply()
		{}
		#region Model
		private int _aid;
		private int? _sid;
		private int? _cid;
		private DateTime? _atime;
		private int? _tid;
		private int? _agroup;
		/// <summary>
		/// 报名表ID
		/// </summary>
		public int AID
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 学生ID
		/// </summary>
		public int? SID
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 比赛ID
		/// </summary>
		public int? CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 报名时间
		/// </summary>
		public DateTime? ATime
		{
			set{ _atime=value;}
			get{return _atime;}
		}
		/// <summary>
		/// 老师ID
		/// </summary>
		public int? TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 报名组别
		/// </summary>
		public int? AGroup
		{
			set{ _agroup=value;}
			get{return _agroup;}
		}
		#endregion Model

	}
}

