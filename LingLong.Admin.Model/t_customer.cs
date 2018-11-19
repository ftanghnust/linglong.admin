/**  版本信息模板在安装目录下，可自行修改。
* t_customer.cs
*
* 功 能： N/A
* 类 名： t_customer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:50   N/A    初版
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
	/// t_customer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_customer
	{
		public t_customer()
		{}
		#region Model
		private int _id;
		private int? _customertype;
		private string _truename;
		private string _nickname;
		private int? _gender;
		private string _avatarurl;
		private string _openid;
		private string _unionid;
		private string _appid;
		private string _phonenumber;
		private string _city;
		private string _province;
		private string _country;
		private string _nativeplace;
		private decimal? _height;
		private DateTime? _birthday;
		private DateTime? _registertime;
		private string _wechat;
		private string _password;
		private string _remark;
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
		public int? CustomerType
		{
			set{ _customertype=value;}
			get{return _customertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Nickname
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AvatarUrl
		{
			set{ _avatarurl=value;}
			get{return _avatarurl;}
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
		public string UnionId
		{
			set{ _unionid=value;}
			get{return _unionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppId
		{
			set{ _appid=value;}
			get{return _appid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhoneNumber
		{
			set{ _phonenumber=value;}
			get{return _phonenumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NativePlace
		{
			set{ _nativeplace=value;}
			get{return _nativeplace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RegisterTime
		{
			set{ _registertime=value;}
			get{return _registertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wechat
		{
			set{ _wechat=value;}
			get{return _wechat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
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

