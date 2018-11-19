/**  版本信息模板在安装目录下，可自行修改。
* t_store.cs
*
* 功 能： N/A
* 类 名： t_store
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 23:00:01   N/A    初版
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
	/// 数据访问类:t_store
	/// </summary>
	public partial class t_store
	{
        private string databaseprefix;
        public t_store(string _databaseprefix)
		{ databaseprefix = _databaseprefix; }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("ID", "t_store"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_store");
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
		public bool Add(LingLong.Admin.Model.t_store model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_store(");
			strSql.Append("ApplyOpenId,StoreName,PhoneNumber,StoreImgUrl,Area,City,Province,Address,State,Score,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,PlanId)");
			strSql.Append(" values (");
			strSql.Append("@ApplyOpenId,@StoreName,@PhoneNumber,@StoreImgUrl,@Area,@City,@Province,@Address,@State,@Score,@IsDeleted,@DeleterUserId,@LastModificationTime,@LastModifierUserId,@CreationTime,@PlanId)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ApplyOpenId", MySqlDbType.LongText),
					new MySqlParameter("@StoreName", MySqlDbType.VarChar,50),
					new MySqlParameter("@PhoneNumber", MySqlDbType.VarChar,20),
					new MySqlParameter("@StoreImgUrl", MySqlDbType.LongText),
					new MySqlParameter("@Area", MySqlDbType.LongText),
					new MySqlParameter("@City", MySqlDbType.LongText),
					new MySqlParameter("@Province", MySqlDbType.LongText),
					new MySqlParameter("@Address", MySqlDbType.LongText),
					new MySqlParameter("@State", MySqlDbType.Int16,4),
					new MySqlParameter("@Score", MySqlDbType.Float),
					new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime)};
			parameters[0].Value = model.ApplyOpenId;
			parameters[1].Value = model.StoreName;
			parameters[2].Value = model.PhoneNumber;
			parameters[3].Value = model.StoreImgUrl;
			parameters[4].Value = model.Area;
			parameters[5].Value = model.City;
			parameters[6].Value = model.Province;
			parameters[7].Value = model.Address;
			parameters[8].Value = model.State;
			parameters[9].Value = model.Score;
			parameters[10].Value = model.IsDeleted;
			parameters[11].Value = model.DeleterUserId;
			parameters[12].Value = model.LastModificationTime;
			parameters[13].Value = model.LastModifierUserId;
			parameters[14].Value = model.CreationTime;
            parameters[15].Value = model.PlanId == 0 ? null : model.PlanId;

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
		public bool Update(LingLong.Admin.Model.t_store model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_store set ");
			strSql.Append("ApplyOpenId=@ApplyOpenId,");
			strSql.Append("StoreName=@StoreName,");
			strSql.Append("PhoneNumber=@PhoneNumber,");
			strSql.Append("StoreImgUrl=@StoreImgUrl,");
			strSql.Append("Area=@Area,");
			strSql.Append("City=@City,");
			strSql.Append("Province=@Province,");
			strSql.Append("Address=@Address,");
			strSql.Append("State=@State,");
			strSql.Append("Score=@Score,");            
            strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("DeleterUserId=@DeleterUserId,");
			strSql.Append("LastModificationTime=@LastModificationTime,");
			strSql.Append("LastModifierUserId=@LastModifierUserId,");
			strSql.Append("CreationTime=@CreationTime,");
            strSql.Append("PlanId=@PlanId");
            strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ApplyOpenId", MySqlDbType.LongText),
					new MySqlParameter("@StoreName", MySqlDbType.VarChar,50),
					new MySqlParameter("@PhoneNumber", MySqlDbType.VarChar,20),
					new MySqlParameter("@StoreImgUrl", MySqlDbType.LongText),
					new MySqlParameter("@Area", MySqlDbType.LongText),
					new MySqlParameter("@City", MySqlDbType.LongText),
					new MySqlParameter("@Province", MySqlDbType.LongText),
					new MySqlParameter("@Address", MySqlDbType.LongText),
					new MySqlParameter("@State", MySqlDbType.Int16,4),
					new MySqlParameter("@Score", MySqlDbType.Float),
					new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.ApplyOpenId;
			parameters[1].Value = model.StoreName;
			parameters[2].Value = model.PhoneNumber;
			parameters[3].Value = model.StoreImgUrl;
			parameters[4].Value = model.Area;
			parameters[5].Value = model.City;
			parameters[6].Value = model.Province;
			parameters[7].Value = model.Address;
			parameters[8].Value = model.State;
			parameters[9].Value = model.Score;
			parameters[10].Value = model.IsDeleted;
			parameters[11].Value = model.DeleterUserId;
			parameters[12].Value = model.LastModificationTime;
			parameters[13].Value = model.LastModifierUserId;
			parameters[14].Value = model.CreationTime;
            parameters[15].Value = model.PlanId == 0? null: model.PlanId;
            parameters[16].Value = model.ID;

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
			strSql.Append("delete from t_store ");
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
			strSql.Append("delete from t_store ");
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
		public LingLong.Admin.Model.t_store GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ApplyOpenId,StoreName,PhoneNumber,StoreImgUrl,Area,City,Province,Address,State,Score,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime from t_store ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			LingLong.Admin.Model.t_store model=new LingLong.Admin.Model.t_store();
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
		public LingLong.Admin.Model.t_store DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.t_store model=new LingLong.Admin.Model.t_store();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ApplyOpenId"]!=null)
				{
					model.ApplyOpenId=row["ApplyOpenId"].ToString();
				}
				if(row["StoreName"]!=null)
				{
					model.StoreName=row["StoreName"].ToString();
				}
				if(row["PhoneNumber"]!=null)
				{
					model.PhoneNumber=row["PhoneNumber"].ToString();
				}
				if(row["StoreImgUrl"]!=null)
				{
					model.StoreImgUrl=row["StoreImgUrl"].ToString();
				}
				if(row["Area"]!=null)
				{
					model.Area=row["Area"].ToString();
				}
				if(row["City"]!=null)
				{
					model.City=row["City"].ToString();
				}
				if(row["Province"]!=null)
				{
					model.Province=row["Province"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
				}
				if(row["Score"]!=null && row["Score"].ToString()!="")
				{
					model.Score=decimal.Parse(row["Score"].ToString());
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ApplyOpenId,StoreName,PhoneNumber,StoreImgUrl,Area,City,Province,Address,State,Score,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime ");
			strSql.Append(" FROM t_store ");
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
            strSql.Append("select * FROM " + "t_store");
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
			strSql.Append("select count(1) FROM t_store ");
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
			strSql.Append(")AS Row, T.*  from t_store T ");
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
			parameters[0].Value = "t_store";
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

