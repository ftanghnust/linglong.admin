/**  版本信息模板在安装目录下，可自行修改。
* t_payment.cs
*
* 功 能： N/A
* 类 名： t_payment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:53   N/A    初版
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
	/// t_payment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_payment
	{
		public t_payment()
		{}
		#region Model
		private int _id;
		private string _paymentno;
		private int? _customerid;
		private int? _goodsid;
		private DateTime? _paymenttime;
		private decimal? _money;
		private int? _state;
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
		public string PaymentNo
		{
			set{ _paymentno=value;}
			get{return _paymentno;}
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
		public int? GoodsId
		{
			set{ _goodsid=value;}
			get{return _goodsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PaymentTime
		{
			set{ _paymenttime=value;}
			get{return _paymenttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

