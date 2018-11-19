/**  版本信息模板在安装目录下，可自行修改。
* dt_manager_role_value.cs
*
* 功 能： N/A
* 类 名： dt_manager_role_value
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:40   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace LingLong.Admin.Model
{
	/// <summary>
	/// dt_manager_role_value:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class dt_manager_role_value
	{
		public dt_manager_role_value()
		{}
		#region Model
		private int _id;
		private int? _role_id;
		private string _nav_name;
		private string _action_type;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nav_name
		{
			set{ _nav_name=value;}
			get{return _nav_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string action_type
		{
			set{ _action_type=value;}
			get{return _action_type;}
		}
		#endregion Model

	}
}

