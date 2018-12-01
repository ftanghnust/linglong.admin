/**  版本信息模板在安装目录下，可自行修改。
* t_agent.cs
*
* 功 能： N/A
* 类 名： t_agent
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:45   N/A    初版
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
//using Maticsoft.DBUtility;//Please add references
namespace LingLong.Admin.DAL
{
	/// <summary>
	/// 数据访问类:t_agent
	/// </summary>
	public partial class t_agent
	{

        private string databaseprefix; //数据库表名前缀
        public t_agent(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("ID", "t_agent"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_agent");
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
		public bool Add(LingLong.Admin.Model.t_agent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_agent(");
			strSql.Append("IsManage,TrueName,AgentCode,Nickname,Gender,AvatarUrl,PhoneNumber,OpenId,UnionId,AppId,City,Province,Country,NativePlace,Height,Birthday,RegisterTime,State,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId)");
			strSql.Append(" values (");
			strSql.Append("@IsManage,@TrueName,@AgentCode,@Nickname,@Gender,@AvatarUrl,@PhoneNumber,@OpenId,@UnionId,@AppId,@City,@Province,@Country,@NativePlace,@Height,@Birthday,@RegisterTime,@State,@IsDeleted,@DeleterUserId,@LastModificationTime,@LastModifierUserId,@CreationTime,@CreatorUserId)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@IsManage", MySqlDbType.Int16,4),
					new MySqlParameter("@TrueName", MySqlDbType.VarChar,20),
					new MySqlParameter("@AgentCode", MySqlDbType.VarChar,50),
					new MySqlParameter("@Nickname", MySqlDbType.VarChar,20),
					new MySqlParameter("@Gender", MySqlDbType.Int16,4),
					new MySqlParameter("@AvatarUrl", MySqlDbType.LongText),
					new MySqlParameter("@PhoneNumber", MySqlDbType.VarChar,20),
					new MySqlParameter("@OpenId", MySqlDbType.LongText),
					new MySqlParameter("@UnionId", MySqlDbType.LongText),
					new MySqlParameter("@AppId", MySqlDbType.LongText),
					new MySqlParameter("@City", MySqlDbType.LongText),
					new MySqlParameter("@Province", MySqlDbType.LongText),
					new MySqlParameter("@Country", MySqlDbType.LongText),
					new MySqlParameter("@NativePlace", MySqlDbType.VarChar,50),
					new MySqlParameter("@Height", MySqlDbType.Float),
					new MySqlParameter("@Birthday", MySqlDbType.Date),
					new MySqlParameter("@RegisterTime", MySqlDbType.DateTime),
					new MySqlParameter("@State", MySqlDbType.Int16,4),
					new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int16,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
					new MySqlParameter("@CreatorUserId", MySqlDbType.Int16,20)};
			parameters[0].Value = model.IsManage;
			parameters[1].Value = model.TrueName;
			parameters[2].Value = model.AgentCode;
			parameters[3].Value = model.Nickname;
			parameters[4].Value = model.Gender;
			parameters[5].Value = model.AvatarUrl;
			parameters[6].Value = model.PhoneNumber;
			parameters[7].Value = model.OpenId;
			parameters[8].Value = model.UnionId;
			parameters[9].Value = model.AppId;
			parameters[10].Value = model.City;
			parameters[11].Value = model.Province;
			parameters[12].Value = model.Country;
			parameters[13].Value = model.NativePlace;
			parameters[14].Value = model.Height;
			parameters[15].Value = model.Birthday;
			parameters[16].Value = model.RegisterTime;
			parameters[17].Value = model.State;
			parameters[18].Value = model.IsDeleted;
			parameters[19].Value = model.DeleterUserId;
			parameters[20].Value = model.LastModificationTime;
			parameters[21].Value = model.LastModifierUserId;
			parameters[22].Value = model.CreationTime;
			parameters[23].Value = model.CreatorUserId;

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
		public bool Update(LingLong.Admin.Model.t_agent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_agent set ");
			strSql.Append("IsManage=@IsManage,");
			strSql.Append("TrueName=@TrueName,");
			strSql.Append("AgentCode=@AgentCode,");
			strSql.Append("Nickname=@Nickname,");
			strSql.Append("Gender=@Gender,");
			strSql.Append("AvatarUrl=@AvatarUrl,");
			strSql.Append("PhoneNumber=@PhoneNumber,");
			strSql.Append("OpenId=@OpenId,");
			strSql.Append("UnionId=@UnionId,");
			strSql.Append("AppId=@AppId,");
			strSql.Append("City=@City,");
			strSql.Append("Province=@Province,");
			strSql.Append("Country=@Country,");
			strSql.Append("NativePlace=@NativePlace,");
			strSql.Append("Height=@Height,");
			strSql.Append("Birthday=@Birthday,");
			strSql.Append("RegisterTime=@RegisterTime,");
			strSql.Append("State=@State,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("DeleterUserId=@DeleterUserId,");
			strSql.Append("LastModificationTime=@LastModificationTime,");
			strSql.Append("LastModifierUserId=@LastModifierUserId,");
			strSql.Append("CreationTime=@CreationTime,");
			strSql.Append("CreatorUserId=@CreatorUserId");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@IsManage", MySqlDbType.Int16,4),
					new MySqlParameter("@TrueName", MySqlDbType.VarChar,20),
					new MySqlParameter("@AgentCode", MySqlDbType.VarChar,50),
					new MySqlParameter("@Nickname", MySqlDbType.VarChar,20),
					new MySqlParameter("@Gender", MySqlDbType.Int16,4),
					new MySqlParameter("@AvatarUrl", MySqlDbType.LongText),
					new MySqlParameter("@PhoneNumber", MySqlDbType.VarChar,20),
					new MySqlParameter("@OpenId", MySqlDbType.LongText),
					new MySqlParameter("@UnionId", MySqlDbType.LongText),
					new MySqlParameter("@AppId", MySqlDbType.LongText),
					new MySqlParameter("@City", MySqlDbType.LongText),
					new MySqlParameter("@Province", MySqlDbType.LongText),
					new MySqlParameter("@Country", MySqlDbType.LongText),
					new MySqlParameter("@NativePlace", MySqlDbType.VarChar,50),
					new MySqlParameter("@Height", MySqlDbType.Float),
					new MySqlParameter("@Birthday", MySqlDbType.Date),
					new MySqlParameter("@RegisterTime", MySqlDbType.DateTime),
					new MySqlParameter("@State", MySqlDbType.Int16,4),
					new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
					new MySqlParameter("@CreatorUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.IsManage;
			parameters[1].Value = model.TrueName;
			parameters[2].Value = model.AgentCode;
			parameters[3].Value = model.Nickname;
			parameters[4].Value = model.Gender;
			parameters[5].Value = model.AvatarUrl;
			parameters[6].Value = model.PhoneNumber;
			parameters[7].Value = model.OpenId;
			parameters[8].Value = model.UnionId;
			parameters[9].Value = model.AppId;
			parameters[10].Value = model.City;
			parameters[11].Value = model.Province;
			parameters[12].Value = model.Country;
			parameters[13].Value = model.NativePlace;
			parameters[14].Value = model.Height;
			parameters[15].Value = model.Birthday;
			parameters[16].Value = model.RegisterTime;
			parameters[17].Value = model.State;
			parameters[18].Value = model.IsDeleted;
			parameters[19].Value = model.DeleterUserId;
			parameters[20].Value = model.LastModificationTime;
			parameters[21].Value = model.LastModifierUserId;
			parameters[22].Value = model.CreationTime;
			parameters[23].Value = model.CreatorUserId;
			parameters[24].Value = model.ID;

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
			strSql.Append("delete from t_agent ");
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
			strSql.Append("delete from t_agent ");
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
		public LingLong.Admin.Model.t_agent GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,IsManage,TrueName,AgentCode,Nickname,Gender,AvatarUrl,PhoneNumber,OpenId,UnionId,AppId,City,Province,Country,NativePlace,Height,Birthday,RegisterTime,State,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId from t_agent ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			LingLong.Admin.Model.t_agent model=new LingLong.Admin.Model.t_agent();
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
		public LingLong.Admin.Model.t_agent DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.t_agent model=new LingLong.Admin.Model.t_agent();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["IsManage"]!=null && row["IsManage"].ToString()!="")
				{
					model.IsManage=int.Parse(row["IsManage"].ToString());
				}
				if(row["TrueName"]!=null)
				{
					model.TrueName=row["TrueName"].ToString();
				}
				if(row["AgentCode"]!=null)
				{
					model.AgentCode=row["AgentCode"].ToString();
				}
				if(row["Nickname"]!=null)
				{
					model.Nickname=row["Nickname"].ToString();
				}
				if(row["Gender"]!=null && row["Gender"].ToString()!="")
				{
					model.Gender=int.Parse(row["Gender"].ToString());
				}
				if(row["AvatarUrl"]!=null)
				{
					model.AvatarUrl=row["AvatarUrl"].ToString();
				}
				if(row["PhoneNumber"]!=null)
				{
					model.PhoneNumber=row["PhoneNumber"].ToString();
				}
				if(row["OpenId"]!=null)
				{
					model.OpenId=row["OpenId"].ToString();
				}
				if(row["UnionId"]!=null)
				{
					model.UnionId=row["UnionId"].ToString();
				}
				if(row["AppId"]!=null)
				{
					model.AppId=row["AppId"].ToString();
				}
				if(row["City"]!=null)
				{
					model.City=row["City"].ToString();
				}
				if(row["Province"]!=null)
				{
					model.Province=row["Province"].ToString();
				}
				if(row["Country"]!=null)
				{
					model.Country=row["Country"].ToString();
				}
				if(row["NativePlace"]!=null)
				{
					model.NativePlace=row["NativePlace"].ToString();
				}
				if(row["Height"]!=null && row["Height"].ToString()!="")
				{
					model.Height=decimal.Parse(row["Height"].ToString());
				}
				if(row["Birthday"]!=null && row["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(row["Birthday"].ToString());
				}
				if(row["RegisterTime"]!=null && row["RegisterTime"].ToString()!="")
				{
					model.RegisterTime=DateTime.Parse(row["RegisterTime"].ToString());
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
			strSql.Append("select ID,IsManage,TrueName,AgentCode,Nickname,Gender,AvatarUrl,PhoneNumber,OpenId,UnionId,AppId,City,Province,Country,NativePlace,Height,Birthday,RegisterTime,State,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId ");
			strSql.Append(" FROM t_agent ");
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
            strSql.Append("select a.*,IFNULL( b.StoreNum, 0 ) AS StoreNum  FROM " + @"t_agent a

            LEFT JOIN(SELECT COUNT(* ) AS StoreNum, AgentId FROM t_agent_store GROUP BY AgentId) b ON a.ID = b.AgentId ");
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
			strSql.Append("select count(1) FROM t_agent ");
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
			strSql.Append(")AS Row, T.*  from t_agent T ");
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
			parameters[0].Value = "t_agent";
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

