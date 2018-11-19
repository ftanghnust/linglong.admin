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
using System.Data;
using System.Text;
using LingLong.Admin.Common;
using MySql.Data.MySqlClient;
//using LingLong.Admin.IDAL;
//using Maticsoft.DBUtility;//Please add references
namespace LingLong.Admin.DAL
{
	/// <summary>
	/// 数据访问类:t_reward_detail
	/// </summary>
	public partial class t_reward_detail
	{
        private string databaseprefix; //数据库表名前缀
        public t_reward_detail(string _databaseprefix)
		{ databaseprefix = _databaseprefix; }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("ID", "t_reward_detail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_reward_detail");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			return DbHelperMySql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LingLong.Admin.Model.t_reward_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_reward_detail(");
			strSql.Append("RewardId,OpenrId,DistributionRatio,UserType,RewardMoney,BenefitMoney)");
			strSql.Append(" values (");
			strSql.Append("@RewardId,@OpenrId,@DistributionRatio,@UserType,@RewardMoney,@BenefitMoney)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@RewardId", MySqlDbType.Int32,11),
					new MySqlParameter("@OpenrId", MySqlDbType.LongText),
					new MySqlParameter("@DistributionRatio", MySqlDbType.Float),
					new MySqlParameter("@UserType", MySqlDbType.Int16,4),
					new MySqlParameter("@RewardMoney", MySqlDbType.Decimal,10),
					new MySqlParameter("@BenefitMoney", MySqlDbType.Decimal,10)};
			parameters[0].Value = model.RewardId;
			parameters[1].Value = model.OpenrId;
			parameters[2].Value = model.DistributionRatio;
			parameters[3].Value = model.UserType;
			parameters[4].Value = model.RewardMoney;
			parameters[5].Value = model.BenefitMoney;

			int rows=DbHelperMySql.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(LingLong.Admin.Model.t_reward_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_reward_detail set ");
			strSql.Append("RewardId=@RewardId,");
			strSql.Append("OpenrId=@OpenrId,");
			strSql.Append("DistributionRatio=@DistributionRatio,");
			strSql.Append("UserType=@UserType,");
			strSql.Append("RewardMoney=@RewardMoney,");
			strSql.Append("BenefitMoney=@BenefitMoney");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@RewardId", MySqlDbType.Int32,11),
					new MySqlParameter("@OpenrId", MySqlDbType.LongText),
					new MySqlParameter("@DistributionRatio", MySqlDbType.Float),
					new MySqlParameter("@UserType", MySqlDbType.Int16,4),
					new MySqlParameter("@RewardMoney", MySqlDbType.Decimal,10),
					new MySqlParameter("@BenefitMoney", MySqlDbType.Decimal,10),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.RewardId;
			parameters[1].Value = model.OpenrId;
			parameters[2].Value = model.DistributionRatio;
			parameters[3].Value = model.UserType;
			parameters[4].Value = model.RewardMoney;
			parameters[5].Value = model.BenefitMoney;
			parameters[6].Value = model.ID;

			int rows=DbHelperMySql.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_reward_detail ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			int rows=DbHelperMySql.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_reward_detail ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperMySql.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LingLong.Admin.Model.t_reward_detail GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,RewardId,OpenrId,DistributionRatio,UserType,RewardMoney,BenefitMoney from t_reward_detail ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			LingLong.Admin.Model.t_reward_detail model=new LingLong.Admin.Model.t_reward_detail();
			DataSet ds=DbHelperMySql.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LingLong.Admin.Model.t_reward_detail DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.t_reward_detail model=new LingLong.Admin.Model.t_reward_detail();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["RewardId"]!=null && row["RewardId"].ToString()!="")
				{
					model.RewardId=int.Parse(row["RewardId"].ToString());
				}
				if(row["OpenrId"]!=null)
				{
					model.OpenrId=row["OpenrId"].ToString();
				}
				if(row["DistributionRatio"]!=null && row["DistributionRatio"].ToString()!="")
				{
					model.DistributionRatio=decimal.Parse(row["DistributionRatio"].ToString());
				}
				if(row["UserType"]!=null && row["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(row["UserType"].ToString());
				}
				if(row["RewardMoney"]!=null && row["RewardMoney"].ToString()!="")
				{
					model.RewardMoney=decimal.Parse(row["RewardMoney"].ToString());
				}
				if(row["BenefitMoney"]!=null && row["BenefitMoney"].ToString()!="")
				{
					model.BenefitMoney=decimal.Parse(row["BenefitMoney"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,RewardId,OpenrId,DistributionRatio,UserType,RewardMoney,BenefitMoney ");
			strSql.Append(" FROM t_reward_detail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySql.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM t_reward_detail " );
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperMySql.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperMySql.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_reward_detail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperMySql.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_reward_detail T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySql.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_reward_detail";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySql.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

