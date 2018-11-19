/**  版本信息模板在安装目录下，可自行修改。
* t_reward_detail.cs
*
* 功 能： N/A
* 类 名： t_reward_detail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:55   N/A    初版
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
	/// t_reward_detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_reward_detail
	{
		public t_reward_detail()
		{}
		#region Model
		private int _id;
		private int? _rewardid;
		private string _openrid;
		private decimal? _distributionratio;
		private int? _usertype;
		private decimal? _rewardmoney;
		private decimal? _benefitmoney;
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
		public int? RewardId
		{
			set{ _rewardid=value;}
			get{return _rewardid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OpenrId
		{
			set{ _openrid=value;}
			get{return _openrid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DistributionRatio
		{
			set{ _distributionratio=value;}
			get{return _distributionratio;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? RewardMoney
		{
			set{ _rewardmoney=value;}
			get{return _rewardmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BenefitMoney
		{
			set{ _benefitmoney=value;}
			get{return _benefitmoney;}
		}
		#endregion Model

	}
}

