﻿using LingLong.Admin.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingLong.Admin.DAL
{
    public partial class t_bannerimage
    {
        public t_bannerimage()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySql.GetMaxID("ID", "t_bannerimage");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_bannerimage");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ID", MySqlDbType.Int32)
            };
            parameters[0].Value = ID;

            return DbHelperMySql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(LingLong.Admin.Model.t_bannerimage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_bannerimage(");
            strSql.Append("BannerTitle,ClickStatus,ImgUrl,ClickTrunOnUrl,UpOnLineTime,DownOnLimeTime,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId)");
            strSql.Append(" values (");
            strSql.Append("@BannerTitle,@ClickStatus,@ImgUrl,@ClickTrunOnUrl,@UpOnLineTime,@DownOnLimeTime,@IsDeleted,@DeleterUserId,@LastModificationTime,@LastModifierUserId,@CreationTime,@CreatorUserId)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@BannerTitle", MySqlDbType.VarChar,256),
                    new MySqlParameter("@ClickStatus", MySqlDbType.Int32,11),
                    new MySqlParameter("@ImgUrl", MySqlDbType.VarChar,2048),
                    new MySqlParameter("@ClickTrunOnUrl", MySqlDbType.VarChar,2048),
                    new MySqlParameter("@UpOnLineTime", MySqlDbType.DateTime),
                    new MySqlParameter("@DownOnLimeTime", MySqlDbType.DateTime),
                    new MySqlParameter("@IsDeleted", MySqlDbType.Int32),
                    new MySqlParameter("@DeleterUserId", MySqlDbType.Int32),
                    new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
                    new MySqlParameter("@LastModifierUserId", MySqlDbType.Int32),
                    new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
                    new MySqlParameter("@CreatorUserId", MySqlDbType.Int32)};
            parameters[0].Value = model.BannerTitle;
            parameters[1].Value = model.ClickStatus;
            parameters[2].Value = model.ImgUrl;
            parameters[3].Value = model.ClickTrunOnUrl;
            parameters[4].Value = model.UpOnLineTime;
            parameters[5].Value = model.DownOnLimeTime;
            parameters[6].Value = model.IsDeleted;
            parameters[7].Value = model.DeleterUserId;
            parameters[8].Value = model.LastModificationTime;
            parameters[9].Value = model.LastModifierUserId;
            parameters[10].Value = model.CreationTime;
            parameters[11].Value = model.CreatorUserId;

            int rows = DbHelperMySql.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(LingLong.Admin.Model.t_bannerimage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_bannerimage set ");
            strSql.Append("BannerTitle=@BannerTitle,");
            strSql.Append("ClickStatus=@ClickStatus,");
            strSql.Append("ImgUrl=@ImgUrl,");
            strSql.Append("ClickTrunOnUrl=@ClickTrunOnUrl,");
            strSql.Append("UpOnLineTime=@UpOnLineTime,");
            strSql.Append("DownOnLimeTime=@DownOnLimeTime,");
            strSql.Append("IsDeleted=@IsDeleted,");
            strSql.Append("DeleterUserId=@DeleterUserId,");
            strSql.Append("LastModificationTime=@LastModificationTime,");
            strSql.Append("LastModifierUserId=@LastModifierUserId,");
            strSql.Append("CreationTime=@CreationTime,");
            strSql.Append("CreatorUserId=@CreatorUserId");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@BannerTitle", MySqlDbType.VarChar,256),
                    new MySqlParameter("@ClickStatus", MySqlDbType.Int32,11),
                    new MySqlParameter("@ImgUrl", MySqlDbType.VarChar,2048),
                    new MySqlParameter("@ClickTrunOnUrl", MySqlDbType.VarChar,2048),
                    new MySqlParameter("@UpOnLineTime", MySqlDbType.DateTime),
                    new MySqlParameter("@DownOnLimeTime", MySqlDbType.DateTime),
                    new MySqlParameter("@IsDeleted", MySqlDbType.Int32),
                    new MySqlParameter("@DeleterUserId", MySqlDbType.Int32),
                    new MySqlParameter("@LastModificationTime", MySqlDbType.DateTime),
                    new MySqlParameter("@LastModifierUserId", MySqlDbType.Int32),
                    new MySqlParameter("@CreationTime", MySqlDbType.DateTime),
                    new MySqlParameter("@CreatorUserId", MySqlDbType.Int32),
                    new MySqlParameter("@ID", MySqlDbType.Int32,11)};
            parameters[0].Value = model.BannerTitle;
            parameters[1].Value = model.ClickStatus;
            parameters[2].Value = model.ImgUrl;
            parameters[3].Value = model.ClickTrunOnUrl;
            parameters[4].Value = model.UpOnLineTime;
            parameters[5].Value = model.DownOnLimeTime;
            parameters[6].Value = model.IsDeleted;
            parameters[7].Value = model.DeleterUserId;
            parameters[8].Value = model.LastModificationTime;
            parameters[9].Value = model.LastModifierUserId;
            parameters[10].Value = model.CreationTime;
            parameters[11].Value = model.CreatorUserId;
            parameters[12].Value = model.ID;

            int rows = DbHelperMySql.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_bannerimage ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ID", MySqlDbType.Int32)
            };
            parameters[0].Value = ID;

            int rows = DbHelperMySql.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_bannerimage ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperMySql.ExecuteSql(strSql.ToString());
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
        public LingLong.Admin.Model.t_bannerimage GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BannerTitle,ClickStatus,ImgUrl,ClickTrunOnUrl,UpOnLineTime,DownOnLimeTime,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId from t_bannerimage ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ID", MySqlDbType.Int32)
            };
            parameters[0].Value = ID;

            LingLong.Admin.Model.t_bannerimage model = new LingLong.Admin.Model.t_bannerimage();
            DataSet ds = DbHelperMySql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public LingLong.Admin.Model.t_bannerimage DataRowToModel(DataRow row)
        {
            LingLong.Admin.Model.t_bannerimage model = new LingLong.Admin.Model.t_bannerimage();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["BannerTitle"] != null)
                {
                    model.BannerTitle = row["BannerTitle"].ToString();
                }
                if (row["ClickStatus"] != null && row["ClickStatus"].ToString() != "")
                {
                    model.ClickStatus = int.Parse(row["ClickStatus"].ToString());
                }
                if (row["ImgUrl"] != null && row["ImgUrl"].ToString() != "")
                {
                    model.ImgUrl = row["ImgUrl"].ToString();
                }
                if (row["ClickTrunOnUrl"] != null)
                {
                    model.ClickTrunOnUrl = row["ClickTrunOnUrl"].ToString();
                }
                if (row["UpOnLineTime"] != null && row["UpOnLineTime"].ToString() != "")
                {
                    model.UpOnLineTime = DateTime.Parse(row["UpOnLineTime"].ToString());
                }
                if (row["DownOnLimeTime"] != null && row["DownOnLimeTime"].ToString() != "")
                {
                    model.DownOnLimeTime = DateTime.Parse(row["DownOnLimeTime"].ToString());
                }
                if (row["IsDeleted"] != null && row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["DeleterUserId"] != null && row["DeleterUserId"].ToString() != "")
                {
                    model.DeleterUserId = long.Parse(row["DeleterUserId"].ToString());
                }
                if (row["LastModificationTime"] != null && row["LastModificationTime"].ToString() != "")
                {
                    model.LastModificationTime = DateTime.Parse(row["LastModificationTime"].ToString());
                }
                if (row["LastModifierUserId"] != null && row["LastModifierUserId"].ToString() != "")
                {
                    model.LastModifierUserId = long.Parse(row["LastModifierUserId"].ToString());
                }
                if (row["CreationTime"] != null && row["CreationTime"].ToString() != "")
                {
                    model.CreationTime = DateTime.Parse(row["CreationTime"].ToString());
                }
                if (row["CreatorUserId"] != null && row["CreatorUserId"].ToString() != "")
                {
                    model.CreatorUserId = long.Parse(row["CreatorUserId"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BannerTitle,ClickStatus,ImgUrl,ClickTrunOnUrl,UpOnLineTime,DownOnLimeTime,IsDeleted,DeleterUserId,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId ");
            strSql.Append(" FROM t_bannerimage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            
            return DbHelperMySql.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM t_bannerimage");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_bannerimage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from t_bannerimage T ");
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
			parameters[0].Value = "t_bannerimage";
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
