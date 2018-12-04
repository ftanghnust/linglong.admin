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
using System.Data;
using System.Text;
using LingLong.Admin.Common;
using MySql.Data.MySqlClient;
//using LingLong.Admin.IDAL;
//using Maticsoft.DBUtility;//Please add references
namespace LingLong.Admin.DAL
{
	/// <summary>
	/// 数据访问类:t_withdraw
	/// </summary>
	public partial class t_withdraw
	{
        private string databaseprefix;
        public t_withdraw(string _databaseprefix)
		{ databaseprefix = _databaseprefix; }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("ID", "t_withdraw"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_withdraw");
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
		public bool Add(LingLong.Admin.Model.t_withdraw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_withdraw(");
			strSql.Append("StoreId,BillNo,OpenId,WithdrawName,Withdraw,WithdrawTime,State,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId)");
			strSql.Append(" values (");
			strSql.Append("@StoreId,@BillNo,@OpenId,@WithdrawName,@Withdraw,@WithdrawTime,@State,@IsDeleted,@DeleterUserId,@LastModificationTime,@LastModifierUserId,@CreationTime,@CreatorUserId)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@StoreId", MySqlDbType.Int32,11),
			        new MySqlParameter("@BillNo", MySqlDbType.LongText),
                    new MySqlParameter("@OpenId", MySqlDbType.LongText),
					new MySqlParameter("@WithdrawName", MySqlDbType.VarChar,100),
					new MySqlParameter("@Withdraw", MySqlDbType.Decimal,10),
					new MySqlParameter("@WithdrawTime", MySqlDbType.DateTime),
			        new MySqlParameter("@State", MySqlDbType.Int16,4),
                    new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
					new MySqlParameter("@CreatorUserId", MySqlDbType.Int64,20)};
			parameters[0].Value = model.StoreId;
		    parameters[1].Value = model.BillNo;
            parameters[2].Value = model.OpenId;
			parameters[3].Value = model.WithdrawName;
			parameters[4].Value = model.Withdraw;
			parameters[5].Value = model.WithdrawTime;
		    parameters[6].Value = model.State;
            parameters[7].Value = model.IsDeleted;
			parameters[8].Value = model.DeleterUserId;
			parameters[9].Value = model.LastModificationTime;
			parameters[10].Value = model.LastModifierUserId;
			parameters[11].Value = model.CreationTime;
			parameters[12].Value = model.CreatorUserId;

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
		public bool Update(LingLong.Admin.Model.t_withdraw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_withdraw set ");
			strSql.Append("StoreId=@StoreId,");
		    strSql.Append("BillNo=@BillNo,");
            strSql.Append("OpenId=@OpenId,");
			strSql.Append("WithdrawName=@WithdrawName,");
			strSql.Append("Withdraw=@Withdraw,");
			strSql.Append("WithdrawTime=@WithdrawTime,");
		    strSql.Append("State=@State,");
            strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("DeleterUserId=@DeleterUserId,");
			strSql.Append("LastModificationTime=@LastModificationTime,");
			strSql.Append("LastModifierUserId=@LastModifierUserId,");
			strSql.Append("CreationTime=@CreationTime,");
			strSql.Append("CreatorUserId=@CreatorUserId");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@StoreId", MySqlDbType.Int32,11),
			        new MySqlParameter("@BillNo", MySqlDbType.LongText),
                    new MySqlParameter("@OpenId", MySqlDbType.LongText),
					new MySqlParameter("@WithdrawName", MySqlDbType.VarChar,100),
					new MySqlParameter("@Withdraw", MySqlDbType.Decimal,10),
					new MySqlParameter("@WithdrawTime", MySqlDbType.DateTime),
			        new MySqlParameter("@State", MySqlDbType.Int16,4),
                    new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
					new MySqlParameter("@CreatorUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.StoreId;
		    parameters[1].Value = model.BillNo;
            parameters[2].Value = model.OpenId;
			parameters[3].Value = model.WithdrawName;
			parameters[4].Value = model.Withdraw;
			parameters[5].Value = model.WithdrawTime;
		    parameters[6].Value = model.State;
            parameters[7].Value = model.IsDeleted;
			parameters[8].Value = model.DeleterUserId;
			parameters[9].Value = model.LastModificationTime;
			parameters[10].Value = model.LastModifierUserId;
			parameters[11].Value = model.CreationTime;
			parameters[12].Value = model.CreatorUserId;
			parameters[13].Value = model.ID;

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
			strSql.Append("delete from t_withdraw ");
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
			strSql.Append("delete from t_withdraw ");
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
		public LingLong.Admin.Model.t_withdraw GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,StoreId,BillNo,OpenId,WithdrawName,Withdraw,WithdrawTime,State,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId from t_withdraw ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			LingLong.Admin.Model.t_withdraw model=new LingLong.Admin.Model.t_withdraw();
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
		public LingLong.Admin.Model.t_withdraw DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.t_withdraw model=new LingLong.Admin.Model.t_withdraw();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["StoreId"]!=null && row["StoreId"].ToString()!="")
				{
					model.StoreId=int.Parse(row["StoreId"].ToString());
				}
			    if (row["BillNo"] != null)
			    {
			        model.BillNo = row["BillNo"].ToString();
			    }
                if (row["OpenId"]!=null)
				{
					model.OpenId=row["OpenId"].ToString();
				}
				if(row["WithdrawName"]!=null)
				{
					model.WithdrawName=row["WithdrawName"].ToString();
				}
				if(row["Withdraw"]!=null && row["Withdraw"].ToString()!="")
				{
					model.Withdraw=decimal.Parse(row["Withdraw"].ToString());
				}
				if(row["WithdrawTime"]!=null && row["WithdrawTime"].ToString()!="")
				{
					model.WithdrawTime=DateTime.Parse(row["WithdrawTime"].ToString());
				}
			    if (row["State"] != null && row["State"].ToString() != "")
			    {
			        model.State = int.Parse(row["State"].ToString());
			    }
                if (row["IsDeleted"]!=null && row["IsDeleted"].ToString()!="")
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
			strSql.Append("select ID,StoreId,BillNo,OpenId,WithdrawName,Withdraw,WithdrawTime,State,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId ");
			strSql.Append(" FROM t_withdraw ");
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
	        strSql.Append(@"SELECT
	a.*, b.StoreName,
	CASE c.TrueName
WHEN NULL THEN
	c.Nickname
ELSE
	c.TrueName
END AS BusinessName,
 CASE d.TrueName
WHEN NULL THEN
	d.Nickname
ELSE
	d.TrueName
END AS AgentName
FROM
	t_withdraw a
LEFT JOIN t_store b ON a.StoreId = b.ID
LEFT JOIN t_business c ON a.OpenId = c.OpenId
LEFT JOIN t_agent d ON a.OpenId = d.OpenId ");
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
			strSql.Append("select count(1) FROM t_withdraw ");
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
			strSql.Append(")AS Row, T.*  from t_withdraw T ");
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
			parameters[0].Value = "t_withdraw";
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

