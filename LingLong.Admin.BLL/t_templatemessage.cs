/**  版本信息模板在安装目录下，可自行修改。
* t_store.cs
*
* 功 能： N/A
* 类 名： t_store
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/6 0:49:19   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
//using Maticsoft.Common;
//using LingLong.Admin.Model;
namespace LingLong.Admin.BLL
{
    /// <summary>
    /// t_store
    /// </summary>
    public partial class t_templatemessage
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.t_templatemessage dal;
        public t_templatemessage()
        {
            dal = new DAL.t_templatemessage(siteConfig.sysdatabaseprefix);
        }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(LingLong.Admin.Model.t_templatemessage model)
        {
            //发送消息
            BLL.t_message meaagebll = new BLL.t_message();
            if (model.Type == 1)
            {
                meaagebll.Add(new Model.t_message
                {
                    StoreId = 1,
                    SendOpenId = "System",
                    SendUserId = 1,
                    AcceptOpenId = model.OpenId,
                    AcceptUserId = 1,
                    Content = model.Message,
                    MessageType = 0,
                    SendTime = DateTime.Now,
                    State = 0,
                    IsDeleted = 0,
                    CreationTime = DateTime.Now
                });
            }
            if (model.Type == 2)
            {
                //客户
                BLL.t_customer customerbll = new BLL.t_customer();
                var result = customerbll.GetList(" IsDeleted=0 and CustomerType=0");
                for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                {
                    var openid = result.Tables[0].Rows[i]["OpenId"].ToString();
                    var id = result.Tables[0].Rows[i]["ID"].ToString();
                    meaagebll.Add(new Model.t_message
                    {
                        StoreId = 1,
                        SendOpenId = "System",
                        SendUserId = 1,
                        AcceptOpenId = openid,
                        AcceptUserId = int.Parse(id),
                        Content = model.Message,
                        MessageType = 0,
                        SendTime = DateTime.Now,
                        State = 0,
                        IsDeleted = 0,
                        CreationTime = DateTime.Now
                    });
                }
            }
            if (model.Type == 3)
            {
                //服务人员 需要门店信息
                BLL.t_business businessbll = new BLL.t_business();
                var result = businessbll.GetListOther("");
                for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                {
                    var openid = result.Tables[0].Rows[i]["OpenId"].ToString();
                    var storeid = result.Tables[0].Rows[i]["StoreId"].ToString(); 
                    var id = result.Tables[0].Rows[i]["BusinessId"].ToString();
                    meaagebll.Add(new Model.t_message
                    {
                        StoreId =int.Parse(storeid),
                        SendOpenId = "System",
                        SendUserId = 1,
                        AcceptOpenId = openid,
                        AcceptUserId = int.Parse(id),
                        Content = model.Message,
                        MessageType = 0,
                        SendTime = DateTime.Now,
                        State = 0,
                        IsDeleted = 0,
                        CreationTime = DateTime.Now
                    });
                }
            }
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(LingLong.Admin.Model.t_templatemessage model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LingLong.Admin.Model.t_templatemessage GetModel(int ID)
        {

            return dal.GetModel(ID);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LingLong.Admin.Model.t_templatemessage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LingLong.Admin.Model.t_templatemessage> DataTableToList(DataTable dt)
        {
            List<LingLong.Admin.Model.t_templatemessage> modelList = new List<LingLong.Admin.Model.t_templatemessage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LingLong.Admin.Model.t_templatemessage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

