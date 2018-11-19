using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LingLong.Admin.Web.admin.reward
{
    public partial class sys_rewardmoney_edit1 : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private static Model.manager managermodel;
        protected int planid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            planid = Convert.ToInt32(DTRequest.GetQueryString("planid"));
            managermodel = GetAdminInfo();
            if (managermodel == null && managermodel.id == 0)
                JscriptMsg("添加信息成功！", "../login.aspx");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.t_reward_goods().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_rewardmoney", DTEnums.ActionEnum.View.ToString()); //检查权限
                                                                                      //Model.manager 
                                                                                      //取得管理员信息
                                                                                      //RoleBind(ddlRoleId, model.role_type);
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.t_reward_goods bll = new BLL.t_reward_goods();
            Model.t_reward_goods model = bll.GetModel(_id);
            txt_PlanId.Text = model.PlanId.ToString();
            //planid = planid;
            //txt_GoodsImgUrl.Text = model.GoodsImgUrl;
            img_GoodsImgUrl.ImageUrl = model.GoodsImgUrl;
            txt_GoodsName.Text = model.GoodsName;
            txt_Money.Text = model.Money.ToString();
            if (model.IsDeleted == 1) rad_IsDeleted02.Checked = true;
            else rad_IsDeleted01.Checked = true;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.t_reward_goods model = new Model.t_reward_goods();
            BLL.t_reward_goods bll = new BLL.t_reward_goods();
            model.PlanId = Convert.ToInt32(txt_PlanId.Text);
            model.Money = Convert.ToDecimal(txt_Money.Text);
            model.IsDeleted = Convert.ToInt32(model.IsDeleted);
            model.GoodsName = txt_GoodsName.Text;
            model.LastModifierUserId = managermodel.id;
            model.LastModificationTime = DateTime.Now;

            model.CreatorUserId = managermodel.id;
            model.CreationTime = DateTime.Now;
            return bll.Add(model);
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            if (id > 0)
            {
                string filename = string.Empty, fileExtension = string.Empty;
                if (pic_upload.HasFile)//验证是否包含文件
                {
                    //取得文件的扩展名,并转换成小写
                    fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();

                    if (IsImage(fileExtension))
                    {
                        //对上传文件的大小进行检测，限定文件最大不超过8M
                        if (pic_upload.PostedFile.ContentLength < 8192000)
                        {
                            string filepath = "C:/WebSite/PublishOutput/Imges/linglong/";
                            if (Directory.Exists(Server.MapPath("/images/")) == false)//如果不存在就创建file文件夹
                            {
                                Directory.CreateDirectory(Server.MapPath("/images/"));
                            }
                            filename = Guid.NewGuid().ToString();
                            string virpath = filepath + filename + fileExtension; //+ "business_banner.png";//CreatePasswordHash(pic_upload.FileName, 4) + fileExtension;//这是存到服务器上的虚拟路径

                            string mappath = Server.MapPath("/images/" + filename + fileExtension);//转换成服务器上的物理路径
                            pic_upload.PostedFile.SaveAs(mappath);//保存图片

                            if (File.Exists(virpath))
                            {
                                File.Delete(virpath);
                            }
                            File.Copy(mappath, virpath, true);
                        }
                        else
                        {
                            img_GoodsImgUrl.ImageUrl = "";
                            lbl_pic.Text = "文件大小超出8M！请重新选择！";
                        }
                    }
                    else
                    {
                        img_GoodsImgUrl.ImageUrl = "";
                        lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
                    }
                }
                // 写数据库
                Model.t_reward_goods model = new Model.t_reward_goods();
                BLL.t_reward_goods bll = new BLL.t_reward_goods();
                Model.t_reward_goods oldmodel = bll.GetModel(_id);

                model.PlanId = Convert.ToInt32(txt_PlanId.Text);
                model.Money = Convert.ToDecimal(txt_Money.Text);
                model.IsDeleted = Convert.ToInt32(model.IsDeleted);
                model.GoodsName = txt_GoodsName.Text;
                model.LastModifierUserId = managermodel.id;
                model.LastModificationTime = DateTime.Now;
                model.GoodsImgUrl = pic_upload.HasFile ? ConfigHelper.GetConfigAppSettings("ApiWebUrl") + "Imges/linglong/" + filename + fileExtension : oldmodel.GoodsImgUrl;
                model.ID = _id;

                lbl_pic.Text = "";
                img_GoodsImgUrl.ImageUrl = pic_upload.HasFile ? ConfigHelper.GetConfigAppSettings("ApiWebUrl") + "Imges/linglong/" + filename + fileExtension : oldmodel.GoodsImgUrl;
                return bll.Update(model);
            }
            else
            {
                if (pic_upload.HasFile)//验证是否包含文件
                {
                    //取得文件的扩展名,并转换成小写
                    string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
                    //验证上传文件是否图片格式
                    //fileOk = IsImage(fileExtension);

                    if (IsImage(fileExtension))
                    {
                        //对上传文件的大小进行检测，限定文件最大不超过8M
                        if (pic_upload.PostedFile.ContentLength < 8192000)
                        {
                            string filepath = "C:/WebSite/PublishOutput/Imges/linglong/";
                            if (Directory.Exists(Server.MapPath("/images/")) == false)//如果不存在就创建file文件夹
                            {
                                Directory.CreateDirectory(Server.MapPath("/images/"));
                            }
                            string filename = Guid.NewGuid().ToString();
                            string virpath = filepath + filename + fileExtension; //+ "business_banner.png";//CreatePasswordHash(pic_upload.FileName, 4) + fileExtension;//这是存到服务器上的虚拟路径

                            string mappath = Server.MapPath("/images/" + filename + fileExtension);//转换成服务器上的物理路径
                            pic_upload.PostedFile.SaveAs(mappath);//保存图片

                            if (File.Exists(virpath))
                            {
                                File.Delete(virpath);
                            }
                            File.Copy(mappath, virpath, true);

                            // 写数据库
                            Model.t_reward_goods model = new Model.t_reward_goods();
                            BLL.t_reward_goods bll = new BLL.t_reward_goods();
                            model.PlanId = Convert.ToInt32(txt_PlanId.Text);
                            model.Money = Convert.ToDecimal(txt_Money.Text);
                            model.IsDeleted = Convert.ToInt32(model.IsDeleted);
                            model.GoodsName = txt_GoodsName.Text;
                            model.LastModifierUserId = managermodel.id;
                            model.LastModificationTime = DateTime.Now;
                            model.GoodsImgUrl = ConfigHelper.GetConfigAppSettings("ApiWebUrl") + "Imges/linglong/" + filename + fileExtension;
                            model.CreatorUserId = managermodel.id;
                            model.CreationTime = DateTime.Now;

                            lbl_pic.Text = "";
                            img_GoodsImgUrl.ImageUrl = ConfigHelper.GetConfigAppSettings("ApiWebUrl") + "Imges/linglong/" + filename + fileExtension;
                            return bll.Add(model);
                        }
                        else
                        {
                            img_GoodsImgUrl.ImageUrl = "";
                            lbl_pic.Text = "文件大小超出8M！请重新选择！";
                            return false;
                        }
                    }
                    else
                    {
                        img_GoodsImgUrl.ImageUrl = "";
                        lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
                        return false;
                    }
                }
                else
                {
                    img_GoodsImgUrl.ImageUrl = "";
                    lbl_pic.Text = "请选择要上传的图片！";
                    return false;
                }
            }


        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("sys_rewardmoney", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改信息成功！", "t_reward_plan_edit.aspx?action=" + DTEnums.ActionEnum.Edit + "&id=" + planid);
            }
            else //添加
            {
                ChkAdminLevel("sys_rewardmoney", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoEdit(0))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加信息成功！", "t_reward_plan_edit.aspx?action=" + DTEnums.ActionEnum.Edit + "&id=" + planid);
            }
        }


        /// <summary>
        /// 验证是否指定的图片格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsImage(string str)
        {
            bool isimage = false;
            string thestr = str.ToLower();
            //限定只能上传jpg和gif图片
            string[] allowExtension = { ".jpg", ".gif", ".bmp", ".png" };
            //对上传的文件的类型进行一个个匹对
            for (int i = 0; i < allowExtension.Length; i++)
            {
                if (thestr == allowExtension[i])
                {
                    isimage = true;
                    break;
                }
            }
            return isimage;
        }
    }
}