/**  版本信息模板在安装目录下，可自行修改。
* dt_manager_log.cs
*
* 功 能： N/A
* 类 名： dt_manager_log
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:35   N/A    初版
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
	/// 数据访问类:dt_manager_log
	/// </summary>
	public partial class dt_manager_log
	{
        private string databaseprefix; //数据库表名前缀
        public dt_manager_log(string _databaseprefix)
		{ databaseprefix = _databaseprefix; }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("id", "dt_manager_log"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_manager_log");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return DbHelperMySql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LingLong.Admin.Model.dt_manager_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_manager_log(");
			strSql.Append("user_id,user_name,action_type,remark,user_ip,add_time)");
			strSql.Append(" values (");
			strSql.Append("@user_id,@user_name,@action_type,@remark,@user_ip,@add_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
					new MySqlParameter("@user_name", MySqlDbType.VarChar,100),
					new MySqlParameter("@action_type", MySqlDbType.VarChar,100),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
					new MySqlParameter("@user_ip", MySqlDbType.VarChar,30),
					new MySqlParameter("@add_time", MySqlDbType.DateTime)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.user_name;
			parameters[2].Value = model.action_type;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.user_ip;
			parameters[5].Value = model.add_time;

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
		public bool Update(LingLong.Admin.Model.dt_manager_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_manager_log set ");
			strSql.Append("user_id=@user_id,");
			strSql.Append("user_name=@user_name,");
			strSql.Append("action_type=@action_type,");
			strSql.Append("remark=@remark,");
			strSql.Append("user_ip=@user_ip,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
					new MySqlParameter("@user_name", MySqlDbType.VarChar,100),
					new MySqlParameter("@action_type", MySqlDbType.VarChar,100),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
					new MySqlParameter("@user_ip", MySqlDbType.VarChar,30),
					new MySqlParameter("@add_time", MySqlDbType.DateTime),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.user_name;
			parameters[2].Value = model.action_type;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.user_ip;
			parameters[5].Value = model.add_time;
			parameters[6].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_manager_log ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_manager_log ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public LingLong.Admin.Model.dt_manager_log GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,user_id,user_name,action_type,remark,user_ip,add_time from dt_manager_log ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			LingLong.Admin.Model.dt_manager_log model=new LingLong.Admin.Model.dt_manager_log();
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
		public LingLong.Admin.Model.dt_manager_log DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.dt_manager_log model=new LingLong.Admin.Model.dt_manager_log();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["user_name"]!=null)
				{
					model.user_name=row["user_name"].ToString();
				}
				if(row["action_type"]!=null)
				{
					model.action_type=row["action_type"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["user_ip"]!=null)
				{
					model.user_ip=row["user_ip"].ToString();
				}
				if(row["add_time"]!=null && row["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(row["add_time"].ToString());
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
			strSql.Append("select id,user_id,user_name,action_type,remark,user_ip,add_time ");
			strSql.Append(" FROM dt_manager_log ");
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
			strSql.Append("select count(1) FROM dt_manager_log ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from dt_manager_log T ");
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
			parameters[0].Value = "dt_manager_log";
			parameters[1].Value = "id";
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

