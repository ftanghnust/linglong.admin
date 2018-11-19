/**  版本信息模板在安装目录下，可自行修改。
* t_reward_goods.cs
*
* 功 能： N/A
* 类 名： t_reward_goods
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:57   N/A    初版
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
using MySql.Data.MySqlClient;
//using LingLong.Admin.IDAL;
//using Maticsoft.DBUtility;//Please add references
namespace LingLong.Admin.DAL
{
	/// <summary>
	/// 数据访问类:t_reward_goods
	/// </summary>
	public partial class t_reward_goods
	{
        private string databaseprefix;
        public t_reward_goods(string _databaseprefix)
		{ databaseprefix = _databaseprefix; }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("ID", "t_reward_goods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_reward_goods");
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
		public bool Add(LingLong.Admin.Model.t_reward_goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_reward_goods(");
			strSql.Append("PlanId,GoodsImgUrl,GoodsName,Money,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId)");
			strSql.Append(" values (");
			strSql.Append("@PlanId,@GoodsImgUrl,@GoodsName,@Money,@IsDeleted,@DeleterUserId,@LastModificationTime,@LastModifierUserId,@CreationTime,@CreatorUserId)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PlanId", MySqlDbType.Int32,11),
					new MySqlParameter("@GoodsImgUrl", MySqlDbType.LongText),
					new MySqlParameter("@GoodsName", MySqlDbType.VarChar,50),
					new MySqlParameter("@Money", MySqlDbType.Decimal,10),
					new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
					new MySqlParameter("@CreatorUserId", MySqlDbType.Int64,20)};
			parameters[0].Value = model.PlanId;
			parameters[1].Value = model.GoodsImgUrl;
			parameters[2].Value = model.GoodsName;
			parameters[3].Value = model.Money;
			parameters[4].Value = model.IsDeleted;
			parameters[5].Value = model.DeleterUserId;
			parameters[6].Value = model.LastModificationTime;
			parameters[7].Value = model.LastModifierUserId;
			parameters[8].Value = model.CreationTime;
			parameters[9].Value = model.CreatorUserId;

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
		public bool Update(LingLong.Admin.Model.t_reward_goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_reward_goods set ");
			strSql.Append("PlanId=@PlanId,");
			strSql.Append("GoodsImgUrl=@GoodsImgUrl,");
			strSql.Append("GoodsName=@GoodsName,");
			strSql.Append("Money=@Money,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("DeleterUserId=@DeleterUserId,");
			strSql.Append("LastModificationTime=@LastModificationTime,");
			strSql.Append("LastModifierUserId=@LastModifierUserId,");
			strSql.Append("CreationTime=@CreationTime,");
			strSql.Append("CreatorUserId=@CreatorUserId");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PlanId", MySqlDbType.Int32,11),
					new MySqlParameter("@GoodsImgUrl", MySqlDbType.LongText),
					new MySqlParameter("@GoodsName", MySqlDbType.VarChar,50),
					new MySqlParameter("@Money", MySqlDbType.Decimal,10),
					new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
					new MySqlParameter("@CreatorUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.PlanId;
			parameters[1].Value = model.GoodsImgUrl;
			parameters[2].Value = model.GoodsName;
			parameters[3].Value = model.Money;
			parameters[4].Value = model.IsDeleted;
			parameters[5].Value = model.DeleterUserId;
			parameters[6].Value = model.LastModificationTime;
			parameters[7].Value = model.LastModifierUserId;
			parameters[8].Value = model.CreationTime;
			parameters[9].Value = model.CreatorUserId;
			parameters[10].Value = model.ID;

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
			strSql.Append("delete from t_reward_goods ");
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
			strSql.Append("delete from t_reward_goods ");
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
		public LingLong.Admin.Model.t_reward_goods GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,PlanId,GoodsImgUrl,GoodsName,Money,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId from t_reward_goods ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			LingLong.Admin.Model.t_reward_goods model=new LingLong.Admin.Model.t_reward_goods();
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
		public LingLong.Admin.Model.t_reward_goods DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.t_reward_goods model=new LingLong.Admin.Model.t_reward_goods();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PlanId"]!=null && row["PlanId"].ToString()!="")
				{
					model.PlanId=int.Parse(row["PlanId"].ToString());
				}
				if(row["GoodsImgUrl"]!=null)
				{
					model.GoodsImgUrl=row["GoodsImgUrl"].ToString();
				}
				if(row["GoodsName"]!=null)
				{
					model.GoodsName=row["GoodsName"].ToString();
				}
				if(row["Money"]!=null && row["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(row["Money"].ToString());
				}
				if(row["IsDeleted"]!=null && row["IsDeleted"].ToString()!="")
				{
					model.IsDeleted=int.Parse(row["IsDeleted"].ToString());
				}
				if(row["DeleterUserId"]!=null && row["DeleterUserId"].ToString()!="")
				{
					model.DeleterUserId=long.Parse(row["DeleterUserId"].ToString());
				}
				if(row["LastModificationTime"]!=null && row["LastModificationTime"].ToString()!="")
				{
					model.LastModificationTime=DateTime.Parse(row["LastModificationTime"].ToString());
				}
				if(row["LastModifierUserId"]!=null && row["LastModifierUserId"].ToString()!="")
				{
					model.LastModifierUserId=long.Parse(row["LastModifierUserId"].ToString());
				}
				if(row["CreationTime"]!=null && row["CreationTime"].ToString()!="")
				{
					model.CreationTime=DateTime.Parse(row["CreationTime"].ToString());
				}
				if(row["CreatorUserId"]!=null && row["CreatorUserId"].ToString()!="")
				{
					model.CreatorUserId=long.Parse(row["CreatorUserId"].ToString());
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
			strSql.Append("select ID,PlanId,GoodsImgUrl,GoodsName,Money,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId ");
			strSql.Append(" FROM t_reward_goods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySql.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_reward_goods ");
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
			strSql.Append(")AS Row, T.*  from t_reward_goods T ");
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
			parameters[0].Value = "t_reward_goods";
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

