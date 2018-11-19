/**  版本信息模板在安装目录下，可自行修改。
* dt_navigation.cs
*
* 功 能： N/A
* 类 名： dt_navigation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:41   N/A    初版
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
	/// 数据访问类:dt_navigation
	/// </summary>
	public partial class dt_navigation
	{
        private string databaseprefix;
        public dt_navigation(string _databaseprefix)
		{ databaseprefix = _databaseprefix; }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("id", "dt_navigation"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_navigation");
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
		public bool Add(LingLong.Admin.Model.dt_navigation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_navigation(");
			strSql.Append("parent_id,channel_id,nav_type,name,title,sub_title,icon_url,link_url,sort_id,is_lock,remark,action_type,is_sys)");
			strSql.Append(" values (");
			strSql.Append("@parent_id,@channel_id,@nav_type,@name,@title,@sub_title,@icon_url,@link_url,@sort_id,@is_lock,@remark,@action_type,@is_sys)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@parent_id", MySqlDbType.Int32,11),
					new MySqlParameter("@channel_id", MySqlDbType.Int32,11),
					new MySqlParameter("@nav_type", MySqlDbType.VarChar,50),
					new MySqlParameter("@name", MySqlDbType.VarChar,50),
					new MySqlParameter("@title", MySqlDbType.VarChar,100),
					new MySqlParameter("@sub_title", MySqlDbType.VarChar,100),
					new MySqlParameter("@icon_url", MySqlDbType.VarChar,255),
					new MySqlParameter("@link_url", MySqlDbType.VarChar,255),
					new MySqlParameter("@sort_id", MySqlDbType.Int32,11),
					new MySqlParameter("@is_lock", MySqlDbType.Int16,4),
					new MySqlParameter("@remark", MySqlDbType.LongText),
					new MySqlParameter("@action_type", MySqlDbType.LongText),
					new MySqlParameter("@is_sys", MySqlDbType.Int16,4)};
			parameters[0].Value = model.parent_id;
			parameters[1].Value = model.channel_id;
			parameters[2].Value = model.nav_type;
			parameters[3].Value = model.name;
			parameters[4].Value = model.title;
			parameters[5].Value = model.sub_title;
			parameters[6].Value = model.icon_url;
			parameters[7].Value = model.link_url;
			parameters[8].Value = model.sort_id;
			parameters[9].Value = model.is_lock;
			parameters[10].Value = model.remark;
			parameters[11].Value = model.action_type;
			parameters[12].Value = model.is_sys;

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
		public bool Update(LingLong.Admin.Model.dt_navigation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_navigation set ");
			strSql.Append("parent_id=@parent_id,");
			strSql.Append("channel_id=@channel_id,");
			strSql.Append("nav_type=@nav_type,");
			strSql.Append("name=@name,");
			strSql.Append("title=@title,");
			strSql.Append("sub_title=@sub_title,");
			strSql.Append("icon_url=@icon_url,");
			strSql.Append("link_url=@link_url,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("is_lock=@is_lock,");
			strSql.Append("remark=@remark,");
			strSql.Append("action_type=@action_type,");
			strSql.Append("is_sys=@is_sys");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@parent_id", MySqlDbType.Int32,11),
					new MySqlParameter("@channel_id", MySqlDbType.Int32,11),
					new MySqlParameter("@nav_type", MySqlDbType.VarChar,50),
					new MySqlParameter("@name", MySqlDbType.VarChar,50),
					new MySqlParameter("@title", MySqlDbType.VarChar,100),
					new MySqlParameter("@sub_title", MySqlDbType.VarChar,100),
					new MySqlParameter("@icon_url", MySqlDbType.VarChar,255),
					new MySqlParameter("@link_url", MySqlDbType.VarChar,255),
					new MySqlParameter("@sort_id", MySqlDbType.Int32,11),
					new MySqlParameter("@is_lock", MySqlDbType.Int16,4),
					new MySqlParameter("@remark", MySqlDbType.LongText),
					new MySqlParameter("@action_type", MySqlDbType.LongText),
					new MySqlParameter("@is_sys", MySqlDbType.Int16,4),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.parent_id;
			parameters[1].Value = model.channel_id;
			parameters[2].Value = model.nav_type;
			parameters[3].Value = model.name;
			parameters[4].Value = model.title;
			parameters[5].Value = model.sub_title;
			parameters[6].Value = model.icon_url;
			parameters[7].Value = model.link_url;
			parameters[8].Value = model.sort_id;
			parameters[9].Value = model.is_lock;
			parameters[10].Value = model.remark;
			parameters[11].Value = model.action_type;
			parameters[12].Value = model.is_sys;
			parameters[13].Value = model.id;

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
			strSql.Append("delete from dt_navigation ");
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
			strSql.Append("delete from dt_navigation ");
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
		public LingLong.Admin.Model.dt_navigation GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,parent_id,channel_id,nav_type,name,title,sub_title,icon_url,link_url,sort_id,is_lock,remark,action_type,is_sys from dt_navigation ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			LingLong.Admin.Model.dt_navigation model=new LingLong.Admin.Model.dt_navigation();
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
		public LingLong.Admin.Model.dt_navigation DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.dt_navigation model=new LingLong.Admin.Model.dt_navigation();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["parent_id"]!=null && row["parent_id"].ToString()!="")
				{
					model.parent_id=int.Parse(row["parent_id"].ToString());
				}
				if(row["channel_id"]!=null && row["channel_id"].ToString()!="")
				{
					model.channel_id=int.Parse(row["channel_id"].ToString());
				}
				if(row["nav_type"]!=null)
				{
					model.nav_type=row["nav_type"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["sub_title"]!=null)
				{
					model.sub_title=row["sub_title"].ToString();
				}
				if(row["icon_url"]!=null)
				{
					model.icon_url=row["icon_url"].ToString();
				}
				if(row["link_url"]!=null)
				{
					model.link_url=row["link_url"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["is_lock"]!=null && row["is_lock"].ToString()!="")
				{
					model.is_lock=int.Parse(row["is_lock"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["action_type"]!=null)
				{
					model.action_type=row["action_type"].ToString();
				}
				if(row["is_sys"]!=null && row["is_sys"].ToString()!="")
				{
					model.is_sys=int.Parse(row["is_sys"].ToString());
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
			strSql.Append("select id,parent_id,channel_id,nav_type,name,title,sub_title,icon_url,link_url,sort_id,is_lock,remark,action_type,is_sys ");
			strSql.Append(" FROM dt_navigation ");
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
			strSql.Append("select count(1) FROM dt_navigation ");
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
			strSql.Append(")AS Row, T.*  from dt_navigation T ");
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
			parameters[0].Value = "dt_navigation";
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

