/**  版本信息模板在安装目录下，可自行修改。
* dt_manager.cs
*
* 功 能： N/A
* 类 名： dt_manager
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
	/// 数据访问类:dt_manager
	/// </summary>
	public partial class dt_manager
	{
        private string databaseprefix;
        public dt_manager(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("id", "dt_manager"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_manager");
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
		public bool Add(LingLong.Admin.Model.dt_manager model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_manager(");
			strSql.Append("role_id,role_type,user_name,password,salt,real_name,telephone,email,is_lock,add_time)");
			strSql.Append(" values (");
			strSql.Append("@role_id,@role_type,@user_name,@password,@salt,@real_name,@telephone,@email,@is_lock,@add_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@role_id", MySqlDbType.Int32,11),
					new MySqlParameter("@role_type", MySqlDbType.Int32,11),
					new MySqlParameter("@user_name", MySqlDbType.VarChar,100),
					new MySqlParameter("@password", MySqlDbType.VarChar,100),
					new MySqlParameter("@salt", MySqlDbType.VarChar,20),
					new MySqlParameter("@real_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@telephone", MySqlDbType.VarChar,30),
					new MySqlParameter("@email", MySqlDbType.VarChar,30),
					new MySqlParameter("@is_lock", MySqlDbType.Int32,11),
					new MySqlParameter("@add_time", MySqlDbType.DateTime)};
			parameters[0].Value = model.role_id;
			parameters[1].Value = model.role_type;
			parameters[2].Value = model.user_name;
			parameters[3].Value = model.password;
			parameters[4].Value = model.salt;
			parameters[5].Value = model.real_name;
			parameters[6].Value = model.telephone;
			parameters[7].Value = model.email;
			parameters[8].Value = model.is_lock;
			parameters[9].Value = model.add_time;

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
		public bool Update(LingLong.Admin.Model.dt_manager model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_manager set ");
			strSql.Append("role_id=@role_id,");
			strSql.Append("role_type=@role_type,");
			strSql.Append("user_name=@user_name,");
			strSql.Append("password=@password,");
			strSql.Append("salt=@salt,");
			strSql.Append("real_name=@real_name,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("email=@email,");
			strSql.Append("is_lock=@is_lock,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@role_id", MySqlDbType.Int32,11),
					new MySqlParameter("@role_type", MySqlDbType.Int32,11),
					new MySqlParameter("@user_name", MySqlDbType.VarChar,100),
					new MySqlParameter("@password", MySqlDbType.VarChar,100),
					new MySqlParameter("@salt", MySqlDbType.VarChar,20),
					new MySqlParameter("@real_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@telephone", MySqlDbType.VarChar,30),
					new MySqlParameter("@email", MySqlDbType.VarChar,30),
					new MySqlParameter("@is_lock", MySqlDbType.Int32,11),
					new MySqlParameter("@add_time", MySqlDbType.DateTime),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.role_id;
			parameters[1].Value = model.role_type;
			parameters[2].Value = model.user_name;
			parameters[3].Value = model.password;
			parameters[4].Value = model.salt;
			parameters[5].Value = model.real_name;
			parameters[6].Value = model.telephone;
			parameters[7].Value = model.email;
			parameters[8].Value = model.is_lock;
			parameters[9].Value = model.add_time;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from dt_manager ");
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
			strSql.Append("delete from dt_manager ");
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
		public LingLong.Admin.Model.dt_manager GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,role_id,role_type,user_name,password,salt,real_name,telephone,email,is_lock,add_time from dt_manager ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			LingLong.Admin.Model.dt_manager model=new LingLong.Admin.Model.dt_manager();
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
		public LingLong.Admin.Model.dt_manager DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.dt_manager model=new LingLong.Admin.Model.dt_manager();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["role_id"]!=null && row["role_id"].ToString()!="")
				{
					model.role_id=int.Parse(row["role_id"].ToString());
				}
				if(row["role_type"]!=null && row["role_type"].ToString()!="")
				{
					model.role_type=int.Parse(row["role_type"].ToString());
				}
				if(row["user_name"]!=null)
				{
					model.user_name=row["user_name"].ToString();
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}
				if(row["salt"]!=null)
				{
					model.salt=row["salt"].ToString();
				}
				if(row["real_name"]!=null)
				{
					model.real_name=row["real_name"].ToString();
				}
				if(row["telephone"]!=null)
				{
					model.telephone=row["telephone"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["is_lock"]!=null && row["is_lock"].ToString()!="")
				{
					model.is_lock=int.Parse(row["is_lock"].ToString());
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
			strSql.Append("select id,role_id,role_type,user_name,password,salt,real_name,telephone,email,is_lock,add_time ");
			strSql.Append(" FROM dt_manager ");
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
			strSql.Append("select count(1) FROM dt_manager ");
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
			strSql.Append(")AS Row, T.*  from dt_manager T ");
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
			parameters[0].Value = "dt_manager";
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

