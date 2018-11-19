/**  版本信息模板在安装目录下，可自行修改。
* t_checkcode.cs
*
* 功 能： N/A
* 类 名： t_checkcode
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:48   N/A    初版
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
	/// 数据访问类:t_checkcode
	/// </summary>
	public partial class t_checkcode
	{
        private string databaseprefix; //数据库表名前缀
        public t_checkcode(string _databaseprefix)
		{ databaseprefix = _databaseprefix; }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("ID", "t_checkcode"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_checkcode");
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
		public bool Add(LingLong.Admin.Model.t_checkcode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_checkcode(");
			strSql.Append("PhoneNumber,Code,Type,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@PhoneNumber,@Code,@Type,@CreateTime)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PhoneNumber", MySqlDbType.VarChar,20),
					new MySqlParameter("@Code", MySqlDbType.VarChar,10),
					new MySqlParameter("@Type", MySqlDbType.Int16,4),
					new MySqlParameter("@CreateTime", MySqlDbType.DateTime)};
			parameters[0].Value = model.PhoneNumber;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.CreateTime;

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
		public bool Update(LingLong.Admin.Model.t_checkcode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_checkcode set ");
			strSql.Append("PhoneNumber=@PhoneNumber,");
			strSql.Append("Code=@Code,");
			strSql.Append("Type=@Type,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PhoneNumber", MySqlDbType.VarChar,20),
					new MySqlParameter("@Code", MySqlDbType.VarChar,10),
					new MySqlParameter("@Type", MySqlDbType.Int16,4),
					new MySqlParameter("@CreateTime", MySqlDbType.DateTime),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.PhoneNumber;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.ID;

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
			strSql.Append("delete from t_checkcode ");
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
			strSql.Append("delete from t_checkcode ");
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
		public LingLong.Admin.Model.t_checkcode GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,PhoneNumber,Code,Type,CreateTime from t_checkcode ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			LingLong.Admin.Model.t_checkcode model=new LingLong.Admin.Model.t_checkcode();
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
		public LingLong.Admin.Model.t_checkcode DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.t_checkcode model=new LingLong.Admin.Model.t_checkcode();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PhoneNumber"]!=null)
				{
					model.PhoneNumber=row["PhoneNumber"].ToString();
				}
				if(row["Code"]!=null)
				{
					model.Code=row["Code"].ToString();
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
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
			strSql.Append("select ID,PhoneNumber,Code,Type,CreateTime ");
			strSql.Append(" FROM t_checkcode ");
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
			strSql.Append("select count(1) FROM t_checkcode ");
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
			strSql.Append(")AS Row, T.*  from t_checkcode T ");
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
			parameters[0].Value = "t_checkcode";
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

