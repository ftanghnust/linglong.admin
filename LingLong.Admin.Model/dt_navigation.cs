/**  版本信息模板在安装目录下，可自行修改。
* dt_navigation.cs
*
* 功 能： N/A
* 类 名： dt_navigation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:41   N/A    初版
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
	/// dt_navigation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class dt_navigation
	{
		public dt_navigation()
		{}
		#region Model
		private int _id;
		private int? _parent_id;
		private int? _channel_id;
		private string _nav_type;
		private string _name;
		private string _title;
		private string _sub_title;
		private string _icon_url;
		private string _link_url;
		private int? _sort_id;
		private int? _is_lock;
		private string _remark;
		private string _action_type;
		private int? _is_sys;
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
		public int? parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? channel_id
		{
			set{ _channel_id=value;}
			get{return _channel_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nav_type
		{
			set{ _nav_type=value;}
			get{return _nav_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sub_title
		{
			set{ _sub_title=value;}
			get{return _sub_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string icon_url
		{
			set{ _icon_url=value;}
			get{return _icon_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string link_url
		{
			set{ _link_url=value;}
			get{return _link_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? is_lock
		{
			set{ _is_lock=value;}
			get{return _is_lock;}
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
		public string action_type
		{
			set{ _action_type=value;}
			get{return _action_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? is_sys
		{
			set{ _is_sys=value;}
			get{return _is_sys;}
		}
		#endregion Model

	}
}

