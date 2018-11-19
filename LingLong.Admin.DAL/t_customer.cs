/**  版本信息模板在安装目录下，可自行修改。
* t_customer.cs
*
* 功 能： N/A
* 类 名： t_customer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/5 22:59:50   N/A    初版
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
	/// 数据访问类:t_customer
	/// </summary>
	public partial class t_customer
	{
        private string databaseprefix; //数据库表名前缀
        public t_customer(string _databaseprefix)
		{ databaseprefix = _databaseprefix; }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("ID", "t_customer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_customer");
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
		public bool Add(LingLong.Admin.Model.t_customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_customer(");
			strSql.Append("CustomerType,TrueName,Nickname,Gender,AvatarUrl,OpenId,UnionId,AppId,PhoneNumber,City,Province,Country,NativePlace,Height,Birthday,RegisterTime,Wechat,PassWord,Remark,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId)");
			strSql.Append(" values (");
			strSql.Append("@CustomerType,@TrueName,@Nickname,@Gender,@AvatarUrl,@OpenId,@UnionId,@AppId,@PhoneNumber,@City,@Province,@Country,@NativePlace,@Height,@Birthday,@RegisterTime,@Wechat,@PassWord,@Remark,@IsDeleted,@DeleterUserId,@LastModificationTime,@LastModifierUserId,@CreationTime,@CreatorUserId)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CustomerType", MySqlDbType.Int16,4),
					new MySqlParameter("@TrueName", MySqlDbType.VarChar,20),
					new MySqlParameter("@Nickname", MySqlDbType.VarChar,20),
					new MySqlParameter("@Gender", MySqlDbType.Int16,4),
					new MySqlParameter("@AvatarUrl", MySqlDbType.LongText),
					new MySqlParameter("@OpenId", MySqlDbType.LongText),
					new MySqlParameter("@UnionId", MySqlDbType.LongText),
					new MySqlParameter("@AppId", MySqlDbType.LongText),
					new MySqlParameter("@PhoneNumber", MySqlDbType.VarChar,20),
					new MySqlParameter("@City", MySqlDbType.LongText),
					new MySqlParameter("@Province", MySqlDbType.LongText),
					new MySqlParameter("@Country", MySqlDbType.LongText),
					new MySqlParameter("@NativePlace", MySqlDbType.VarChar,50),
					new MySqlParameter("@Height", MySqlDbType.Float),
					new MySqlParameter("@Birthday", MySqlDbType.Date),
					new MySqlParameter("@RegisterTime", MySqlDbType.DateTime),
					new MySqlParameter("@Wechat", MySqlDbType.VarChar,50),
					new MySqlParameter("@PassWord", MySqlDbType.VarChar,50),
					new MySqlParameter("@Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
					new MySqlParameter("@CreatorUserId", MySqlDbType.Int64,20)};
			parameters[0].Value = model.CustomerType;
			parameters[1].Value = model.TrueName;
			parameters[2].Value = model.Nickname;
			parameters[3].Value = model.Gender;
			parameters[4].Value = model.AvatarUrl;
			parameters[5].Value = model.OpenId;
			parameters[6].Value = model.UnionId;
			parameters[7].Value = model.AppId;
			parameters[8].Value = model.PhoneNumber;
			parameters[9].Value = model.City;
			parameters[10].Value = model.Province;
			parameters[11].Value = model.Country;
			parameters[12].Value = model.NativePlace;
			parameters[13].Value = model.Height;
			parameters[14].Value = model.Birthday;
			parameters[15].Value = model.RegisterTime;
			parameters[16].Value = model.Wechat;
			parameters[17].Value = model.PassWord;
			parameters[18].Value = model.Remark;
			parameters[19].Value = model.IsDeleted;
			parameters[20].Value = model.DeleterUserId;
			parameters[21].Value = model.LastModificationTime;
			parameters[22].Value = model.LastModifierUserId;
			parameters[23].Value = model.CreationTime;
			parameters[24].Value = model.CreatorUserId;

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
		public bool Update(LingLong.Admin.Model.t_customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_customer set ");
			strSql.Append("CustomerType=@CustomerType,");
			strSql.Append("TrueName=@TrueName,");
			strSql.Append("Nickname=@Nickname,");
			strSql.Append("Gender=@Gender,");
			strSql.Append("AvatarUrl=@AvatarUrl,");
			strSql.Append("OpenId=@OpenId,");
			strSql.Append("UnionId=@UnionId,");
			strSql.Append("AppId=@AppId,");
			strSql.Append("PhoneNumber=@PhoneNumber,");
			strSql.Append("City=@City,");
			strSql.Append("Province=@Province,");
			strSql.Append("Country=@Country,");
			strSql.Append("NativePlace=@NativePlace,");
			strSql.Append("Height=@Height,");
			strSql.Append("Birthday=@Birthday,");
			strSql.Append("RegisterTime=@RegisterTime,");
			strSql.Append("Wechat=@Wechat,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("DeleterUserId=@DeleterUserId,");
			strSql.Append("LastModificationTime=@LastModificationTime,");
			strSql.Append("LastModifierUserId=@LastModifierUserId,");
			strSql.Append("CreationTime=@CreationTime,");
			strSql.Append("CreatorUserId=@CreatorUserId");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CustomerType", MySqlDbType.Int16,4),
					new MySqlParameter("@TrueName", MySqlDbType.VarChar,20),
					new MySqlParameter("@Nickname", MySqlDbType.VarChar,20),
					new MySqlParameter("@Gender", MySqlDbType.Int16,4),
					new MySqlParameter("@AvatarUrl", MySqlDbType.LongText),
					new MySqlParameter("@OpenId", MySqlDbType.LongText),
					new MySqlParameter("@UnionId", MySqlDbType.LongText),
					new MySqlParameter("@AppId", MySqlDbType.LongText),
					new MySqlParameter("@PhoneNumber", MySqlDbType.VarChar,20),
					new MySqlParameter("@City", MySqlDbType.LongText),
					new MySqlParameter("@Province", MySqlDbType.LongText),
					new MySqlParameter("@Country", MySqlDbType.LongText),
					new MySqlParameter("@NativePlace", MySqlDbType.VarChar,50),
					new MySqlParameter("@Height", MySqlDbType.Float),
					new MySqlParameter("@Birthday", MySqlDbType.Date),
					new MySqlParameter("@RegisterTime", MySqlDbType.DateTime),
					new MySqlParameter("@Wechat", MySqlDbType.VarChar,50),
					new MySqlParameter("@PassWord", MySqlDbType.VarChar,50),
					new MySqlParameter("@Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("@IsDeleted", MySqlDbType.Int16,4),
					new MySqlParameter("@DeleterUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
					new MySqlParameter("@LastModifierUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
					new MySqlParameter("@CreatorUserId", MySqlDbType.Int64,20),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.CustomerType;
			parameters[1].Value = model.TrueName;
			parameters[2].Value = model.Nickname;
			parameters[3].Value = model.Gender;
			parameters[4].Value = model.AvatarUrl;
			parameters[5].Value = model.OpenId;
			parameters[6].Value = model.UnionId;
			parameters[7].Value = model.AppId;
			parameters[8].Value = model.PhoneNumber;
			parameters[9].Value = model.City;
			parameters[10].Value = model.Province;
			parameters[11].Value = model.Country;
			parameters[12].Value = model.NativePlace;
			parameters[13].Value = model.Height;
			parameters[14].Value = model.Birthday;
			parameters[15].Value = model.RegisterTime;
			parameters[16].Value = model.Wechat;
			parameters[17].Value = model.PassWord;
			parameters[18].Value = model.Remark;
			parameters[19].Value = model.IsDeleted;
			parameters[20].Value = model.DeleterUserId;
			parameters[21].Value = model.LastModificationTime;
			parameters[22].Value = model.LastModifierUserId;
			parameters[23].Value = model.CreationTime;
			parameters[24].Value = model.CreatorUserId;
			parameters[25].Value = model.ID;

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
			strSql.Append("delete from t_customer ");
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
			strSql.Append("delete from t_customer ");
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
		public LingLong.Admin.Model.t_customer GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,CustomerType,TrueName,Nickname,Gender,AvatarUrl,OpenId,UnionId,AppId,PhoneNumber,City,Province,Country,NativePlace,Height,Birthday,RegisterTime,Wechat,PassWord,Remark,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId from t_customer ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			LingLong.Admin.Model.t_customer model=new LingLong.Admin.Model.t_customer();
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
		public LingLong.Admin.Model.t_customer DataRowToModel(DataRow row)
		{
			LingLong.Admin.Model.t_customer model=new LingLong.Admin.Model.t_customer();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["CustomerType"]!=null && row["CustomerType"].ToString()!="")
				{
					model.CustomerType=int.Parse(row["CustomerType"].ToString());
				}
				if(row["TrueName"]!=null)
				{
					model.TrueName=row["TrueName"].ToString();
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
				if(row["PhoneNumber"]!=null)
				{
					model.PhoneNumber=row["PhoneNumber"].ToString();
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
				if(row["Wechat"]!=null)
				{
					model.Wechat=row["Wechat"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select ID,CustomerType,TrueName,Nickname,Gender,AvatarUrl,OpenId,UnionId,AppId,PhoneNumber,City,Province,Country,NativePlace,Height,Birthday,RegisterTime,Wechat,PassWord,Remark,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId ");
			strSql.Append(" FROM t_customer ");
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
            strSql.Append("select * FROM " + "t_customer");
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
			strSql.Append("select count(1) FROM t_customer ");
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
			strSql.Append(")AS Row, T.*  from t_customer T ");
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
			parameters[0].Value = "t_customer";
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

