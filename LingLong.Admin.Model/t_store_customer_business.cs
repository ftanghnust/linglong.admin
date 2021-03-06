﻿/**  版本信息模板在安装目录下，可自行修改。
* t_store_customer_business.cs
*
* 功 能： N/A
* 类 名： t_store_customer_business
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 23:00:05   N/A    初版
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
	/// t_store_customer_business:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_store_customer_business
	{
		public t_store_customer_business()
		{}
		#region Model
		private int _id;
		private int? _storeid;
		private int? _customerid;
		private int? _businessid;
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
		public int? BusinessId
		{
			set{ _businessid=value;}
			get{return _businessid;}
		}
		#endregion Model

	}
}

