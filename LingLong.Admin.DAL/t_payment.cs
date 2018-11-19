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
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
//using LingLong.Admin.IDAL;
//using Maticsoft.DBUtility;//Please add references
namespace LingLong.Admin.DAL
{
	/// <summary>
	/// 数据访问类:t_payment
	/// </summary>
	public partial class t_payment
	{
        private string databaseprefix; //数据库表名前缀
        public t_payment(string _databaseprefix)
		{ databaseprefix = _databaseprefix; }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("ID", "t_payment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_payment");
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
		public bool Add(LingLong.Admin.Model.t_payment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_payment(");
			strSql.Append("PaymentNo,CustomerId,GoodsId,PaymentTime,Money,State)");
			strSql.Append(" values (");
			strSql.Append("@PaymentNo,@CustomerId,@GoodsId,@PaymentTime,@Money,@State)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PaymentNo", MySqlDbType.VarChar,50),
					new MySqlParameter("@CustomerId", MySqlDbType.Int32,11),
					new MySqlParameter("@GoodsId", MySqlDbType.Int32,11),
					new MySqlParameter("@PaymentTime", MySqlDbType.DateTime),
					new MySqlParameter("@Money", MySqlDbType.Decimal,10),
					new MySqlParameter("@State", MySqlDbType.Int16,4)};
			parameters[0].Value = model.PaymentNo;
			parameters[1].Value = model.CustomerId;
			parameters[2].Value = model.GoodsId;
			parameters[3].Value = model.PaymentTime;
			parameters[4].Value = model.Money;
			parameters[5].Value = model.State;

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
		public bool Update(LingLong.Admin.Model.t_payment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_payment set ");
			strSql.Append("PaymentNo=@PaymentNo,");
			strSql.Append("CustomerId=@CustomerId,");
			strSql.Append("GoodsId=@GoodsId,");
			strSql.Append("PaymentTime=@PaymentTime,");
			strSql.Append("Money=@Money,");
			strSql.Append("State=@State");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PaymentNo", MySqlDbType.VarChar,50),
					new MySqlParameter("@CustomerId", MySqlDbType.Int32,11),
					new MySqlParameter("@GoodsId", MySqlDbType.Int32,11),
					new MySqlParameter("@PaymentTime", MySqlDbType.DateTime),
					new MySqlParameter("@Money", MySqlDbType.Decimal,10),
					new MySqlParameter("@State", MySqlDbType.Int16,4),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.PaymentNo;
			parameters[1].Value = model.CustomerId;
			parameters[2].Value = model.GoodsId;
			parameters[3].Value = model.PaymentTime;
			parameters[4].Value = model.Money;
			parameters[5].Value = model.State;
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
			strSql.Append("delete from t_payment ");
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
			strSql.Append("delete from t_payment ");
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
		public LingLong.Admin.Model.t_payment GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,PaymentNo,CustomerId,GoodsId,PaymentTime,Money,State from t_payment ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			LingLong.Admin.Model.t_payment model=new LingLong.Admin.Model.t_payment();
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
		public LingLong.Admin.Model.t_payment DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.t_payment model=new LingLong.Admin.Model.t_payment();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PaymentNo"]!=null)
				{
					model.PaymentNo=row["PaymentNo"].ToString();
				}
				if(row["CustomerId"]!=null && row["CustomerId"].ToString()!="")
				{
					model.CustomerId=int.Parse(row["CustomerId"].ToString());
				}
				if(row["GoodsId"]!=null && row["GoodsId"].ToString()!="")
				{
					model.GoodsId=int.Parse(row["GoodsId"].ToString());
				}
				if(row["PaymentTime"]!=null && row["PaymentTime"].ToString()!="")
				{
					model.PaymentTime=DateTime.Parse(row["PaymentTime"].ToString());
				}
				if(row["Money"]!=null && row["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(row["Money"].ToString());
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
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
			strSql.Append("select ID,PaymentNo,CustomerId,GoodsId,PaymentTime,Money,State ");
			strSql.Append(" FROM t_payment ");
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
			strSql.Append("select count(1) FROM t_payment ");
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
			strSql.Append(")AS Row, T.*  from t_payment T ");
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
			parameters[0].Value = "t_payment";
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

