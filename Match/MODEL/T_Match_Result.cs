/**  版本信息模板在安装目录下，可自行修改。
* T_Match_Result.cs
*
* 功 能： N/A
* 类 名： T_Match_Result
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
	/// T_Match_Result:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Match_Result
	{
		public T_Match_Result()
		{}
		#region Model
		private int _rid;
		private int? _aid;
		private string _rinformation;
		/// <summary>
		/// 获奖情况表ID
		/// </summary>
		public int RID
		{
			set{ _rid=value;}
			get{return _rid;}
		}
		/// <summary>
		/// 报名表ID
		/// </summary>
		public int? AID
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 获奖信息
		/// </summary>
		public string RInformation
		{
			set{ _rinformation=value;}
			get{return _rinformation;}
		}
		#endregion Model

	}
}

