﻿/**  版本信息模板在安装目录下，可自行修改。
* t_store_comment.cs
*
* 功 能： N/A
* 类 名： t_store_comment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 23:00:03   N/A    初版
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
	/// t_store_comment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_store_comment
	{
		public t_store_comment()
		{}
		#region Model
		private int _id;
		private int? _storeid;
		private int? _customerid;
		private decimal? _score;
		private DateTime? _commenttime;
		private int? _isdeleted;
		private long? _deleteruserid;
		private DateTime? _lastmodificationtime;
		private long? _lastmodifieruserid;
		private DateTime? _creationtime;
		private long? _creatoruserid;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StoreId
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CustomerId
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CommentTime
		{
			set{ _commenttime=value;}
			get{return _commenttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsDeleted
		{
			set{ _isdeleted=value;}
			get{return _isdeleted;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? DeleterUserId
		{
			set{ _deleteruserid=value;}
			get{return _deleteruserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastModificationTime
		{
			set{ _lastmodificationtime=value;}
			get{return _lastmodificationtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? LastModifierUserId
		{
			set{ _lastmodifieruserid=value;}
			get{return _lastmodifieruserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreationTime
		{
			set{ _creationtime=value;}
			get{return _creationtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? CreatorUserId
		{
			set{ _creatoruserid=value;}
			get{return _creatoruserid;}
		}
		#endregion Model

	}
}

