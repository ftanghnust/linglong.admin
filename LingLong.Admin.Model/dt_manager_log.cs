/**  版本信息模板在安装目录下，可自行修改。
* dt_manager_log.cs
*
* 功 能： N/A
* 类 名： dt_manager_log
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:35   N/A    初版
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
	/// dt_manager_log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class dt_manager_log
	{
		public dt_manager_log()
		{}
		#region Model
		private int _id;
		private int? _user_id;
		private string _user_name;
		private string _action_type;
		private string _remark;
		private string _user_ip;
		private DateTime? _add_time;
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
		public int? user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string action_type
		{
			set{ _action_type=value;}
			get{return _action_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_ip
		{
			set{ _user_ip=value;}
			get{return _user_ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}
}

