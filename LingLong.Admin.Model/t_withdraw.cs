/**  版本信息模板在安装目录下，可自行修改。
* t_withdraw.cs
*
* 功 能： N/A
* 类 名： t_withdraw
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 23:00:07   N/A    初版
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
	/// t_withdraw:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_withdraw
	{
		public t_withdraw()
		{}
		#region Model
		private int _id;
		private int? _storeid;
	    private string _billno;
        private string _openid;
		private string _withdrawname;
		private decimal? _withdraw;
		private DateTime? _withdrawtime;
	    private int? _state;
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
	    public string BillNo
        {
	        set { _billno = value; }
	        get { return _billno; }
	    }
        /// <summary>
        /// 
        /// </summary>
        public string OpenId
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WithdrawName
		{
			set{ _withdrawname=value;}
			get{return _withdrawname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Withdraw
		{
			set{ _withdraw=value;}
			get{return _withdraw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WithdrawTime
		{
			set{ _withdrawtime=value;}
			get{return _withdrawtime;}
		}
	    /// <summary>
	    /// 
	    /// </summary>
	    public int? State
        {
	        set { _state = value; }
	        get { return _state; }
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

