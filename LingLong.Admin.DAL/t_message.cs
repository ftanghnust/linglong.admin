/**  版本信息模板在安装目录下，可自行修改。
* t_message.cs
*
* 功 能： N/A
* 类 名： t_message
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:51   N/A    初版
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
	/// 数据访问类:t_message
	/// </summary>
	public partial class t_message
	{
        private string databaseprefix; //数据库表名前缀
        public t_message(string _databaseprefix)
		{ databaseprefix = _databaseprefix; }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("ID", "t_message"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_message");
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
		public bool Add(LingLong.Admin.Model.t_message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_message(");
			strSql.Append("MessageType,StoreId,SendUserId,SendOpenId,AcceptUserId,AcceptOpenId,Content,SendTime,State,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId)");
			strSql.Append(" values (");
			strSql.Append("@MessageType,@StoreId,@SendUserId,@SendOpenId,@AcceptUserId,@AcceptOpenId,@Content,@SendTime,@State,@IsDeleted,@DeleterUserId,@LastModificationTime,@LastModifierUserId,@CreationTime,@CreatorUserId)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@MessageType", MySqlDbType.Int16,4),
					new MySqlParameter("@StoreId", MySqlDbType.Int32,11),
					new MySqlParameter("@SendUserId", MySqlDbType.Int32,11),
					new MySqlParameter("@SendOpenId", MySqlDbType.LongText),
					new MySqlParameter("@AcceptUserId", MySqlDbType.Int32,11),
					new MySqlParameter("@AcceptOpenId", MySqlDbType.LongText),
					new MySqlParameter("@Content", MySqlDbType.LongText),
					new MySqlParameter("@SendTime", MySqlDbType.DateTime),
					new MySqlParameter("@State", MySqlDbType.Int16,4),
					new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
					new MySqlParameter("@CreatorUserId", MySqlDbType.Int64,20)};
			parameters[0].Value = model.MessageType;
			parameters[1].Value = model.StoreId;
			parameters[2].Value = model.SendUserId;
			parameters[3].Value = model.SendOpenId;
			parameters[4].Value = model.AcceptUserId;
			parameters[5].Value = model.AcceptOpenId;
			parameters[6].Value = model.Content;
			parameters[7].Value = model.SendTime;
			parameters[8].Value = model.State;
			parameters[9].Value = model.IsDeleted;
			parameters[10].Value = model.DeleterUserId;
			parameters[11].Value = model.LastModificationTime;
			parameters[12].Value = model.LastModifierUserId;
			parameters[13].Value = model.CreationTime;
			parameters[14].Value = model.CreatorUserId;

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
		public bool Update(LingLong.Admin.Model.t_message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_message set ");
			strSql.Append("MessageType=@MessageType,");
			strSql.Append("StoreId=@StoreId,");
			strSql.Append("SendUserId=@SendUserId,");
			strSql.Append("SendOpenId=@SendOpenId,");
			strSql.Append("AcceptUserId=@AcceptUserId,");
			strSql.Append("AcceptOpenId=@AcceptOpenId,");
			strSql.Append("Content=@Content,");
			strSql.Append("SendTime=@SendTime,");
			strSql.Append("State=@State,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("DeleterUserId=@DeleterUserId,");
			strSql.Append("LastModificationTime=@LastModificationTime,");
			strSql.Append("LastModifierUserId=@LastModifierUserId,");
			strSql.Append("CreationTime=@CreationTime,");
			strSql.Append("CreatorUserId=@CreatorUserId");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@MessageType", MySqlDbType.Int16,4),
					new MySqlParameter("@StoreId", MySqlDbType.Int32,11),
					new MySqlParameter("@SendUserId", MySqlDbType.Int32,11),
					new MySqlParameter("@SendOpenId", MySqlDbType.LongText),
					new MySqlParameter("@AcceptUserId", MySqlDbType.Int32,11),
					new MySqlParameter("@AcceptOpenId", MySqlDbType.LongText),
					new MySqlParameter("@Content", MySqlDbType.LongText),
					new MySqlParameter("@SendTime", MySqlDbType.DateTime),
					new MySqlParameter("@State", MySqlDbType.Int16,4),
					new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
					new MySqlParameter("@CreatorUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.MessageType;
			parameters[1].Value = model.StoreId;
			parameters[2].Value = model.SendUserId;
			parameters[3].Value = model.SendOpenId;
			parameters[4].Value = model.AcceptUserId;
			parameters[5].Value = model.AcceptOpenId;
			parameters[6].Value = model.Content;
			parameters[7].Value = model.SendTime;
			parameters[8].Value = model.State;
			parameters[9].Value = model.IsDeleted;
			parameters[10].Value = model.DeleterUserId;
			parameters[11].Value = model.LastModificationTime;
			parameters[12].Value = model.LastModifierUserId;
			parameters[13].Value = model.CreationTime;
			parameters[14].Value = model.CreatorUserId;
			parameters[15].Value = model.ID;

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
			strSql.Append("delete from t_message ");
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
			strSql.Append("delete from t_message ");
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
		public LingLong.Admin.Model.t_message GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,MessageType,StoreId,SendUserId,SendOpenId,AcceptUserId,AcceptOpenId,Content,SendTime,State,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId from t_message ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			LingLong.Admin.Model.t_message model=new LingLong.Admin.Model.t_message();
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
		public LingLong.Admin.Model.t_message DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.t_message model=new LingLong.Admin.Model.t_message();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["MessageType"]!=null && row["MessageType"].ToString()!="")
				{
					model.MessageType=int.Parse(row["MessageType"].ToString());
				}
				if(row["StoreId"]!=null && row["StoreId"].ToString()!="")
				{
					model.StoreId=int.Parse(row["StoreId"].ToString());
				}
				if(row["SendUserId"]!=null && row["SendUserId"].ToString()!="")
				{
					model.SendUserId=int.Parse(row["SendUserId"].ToString());
				}
				if(row["SendOpenId"]!=null)
				{
					model.SendOpenId=row["SendOpenId"].ToString();
				}
				if(row["AcceptUserId"]!=null && row["AcceptUserId"].ToString()!="")
				{
					model.AcceptUserId=int.Parse(row["AcceptUserId"].ToString());
				}
				if(row["AcceptOpenId"]!=null)
				{
					model.AcceptOpenId=row["AcceptOpenId"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["SendTime"]!=null && row["SendTime"].ToString()!="")
				{
					model.SendTime=DateTime.Parse(row["SendTime"].ToString());
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
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
			strSql.Append("select ID,MessageType,StoreId,SendUserId,SendOpenId,AcceptUserId,AcceptOpenId,Content,SendTime,State,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId ");
			strSql.Append(" FROM t_message ");
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
			strSql.Append("select count(1) FROM t_message ");
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
			strSql.Append(")AS Row, T.*  from t_message T ");
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
			parameters[0].Value = "t_message";
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

