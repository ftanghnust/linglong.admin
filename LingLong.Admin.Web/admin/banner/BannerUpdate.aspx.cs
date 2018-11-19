using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LingLong.Admin.Web.admin.banner
{
    public partial class BannerUpdate : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cacheKey = Request.Url.ToString();
            Cache[cacheKey] = new object();
            Response.AddCacheItemDependency(cacheKey);

            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.t_bannerimage().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_banner", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得管理员信息
                //RoleBind(ddlRoleId, model.role_type);
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 角色类型=================================

        private void ShowInfo(int _id)
        {
            BLL.t_bannerimage bll = new BLL.t_bannerimage();
            Model.t_bannerimage model = bll.GetModel(_id);
            txt_BannerTitle.Text = model.BannerTitle;
            model.ClickStatus = Convert.ToInt32(sel_ClickStatus.SelectedValue);
            sel_ClickStatus.SelectedValue = model.ClickStatus.ToString();
            //txt_TrunUrl.Text = model.ClickTrunOnUrl;
            txt_UpOnLineTime.Text = Convert.ToDateTime(model.UpOnLineTime).ToString("yyyy-MM-dd HH:mm:ss");
            txt_DownOnLimeTime.Text = Convert.ToDateTime(model.DownOnLimeTime).ToString("yyyy-MM-dd HH:mm:ss");
            img_UpdateResult.ImageUrl = model.ImgUrl;
            img_ClickTrunOnUrl.ImageUrl = model.ClickTrunOnUrl;

            btn_upload.Text = "修改";
            //btn_upload.Click += new EventHandler(btn_Update_Click, null);

        }
        #endregion
        protected void btn_upload_Click(object sender, EventArgs e)
        {
            //先把另一个文件上传上去
            string trunonfile = "";
            bool hastrunonfile = false;
            if (file_ClickTrunOnUrl.HasFile) {
                hastrunonfile = true;
                string exten = Path.GetExtension(file_ClickTrunOnUrl.FileName).ToLower();
                if (IsImage(exten))
                {
                    string trunonfilepath = "C:/WebSite/PublishOutput/Imges/linglong/";
                    if (Directory.Exists(Server.MapPath("/images/")) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(Server.MapPath("/images/"));
                    }
                    trunonfile = Guid.NewGuid().ToString();
                    string virpath = trunonfilepath + trunonfile + exten; //+ "business_banner.png";//CreatePasswordHash(pic_upload.FileName, 4) + fileExtension;//这是存到服务器上的虚拟路径

                    string mappath = Server.MapPath("/images/" + trunonfile + exten);//转换成服务器上的物理路径
                    file_ClickTrunOnUrl.PostedFile.SaveAs(mappath);//保存图片

                    if (File.Exists(virpath))
                    {
                        File.Delete(virpath);
                    }
                    File.Copy(mappath, virpath, true);
                    trunonfile = ConfigHelper.GetConfigAppSettings("ApiWebUrl") + "Imges/linglong/" + trunonfile + exten;
                    lab_ClickTrunOnUrl.Text = "";
                }
                else {
                    lab_ClickTrunOnUrl.Text = "跳转图片类型不允许，请换张图片试试！";
                    return;
                }
            }
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
                            img_UpdateResult.ImageUrl = "";
                            lbl_pic.Text = "文件大小超出8M！请重新选择！";
                        }
                    }
                    else
                    {
                        img_UpdateResult.ImageUrl = "";
                        lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
                    }
                }
                // 写数据库
                LingLong.Admin.BLL.t_bannerimage bll = new LingLong.Admin.BLL.t_bannerimage();
                LingLong.Admin.Model.t_bannerimage model = new LingLong.Admin.Model.t_bannerimage();
                LingLong.Admin.Model.t_bannerimage oldmodel = bll.GetModel(id);
                model.BannerTitle = txt_BannerTitle.Text;
                model.ClickStatus = Convert.ToInt32(sel_ClickStatus.SelectedValue);
                model.ClickTrunOnUrl = hastrunonfile ? trunonfile: oldmodel.ClickTrunOnUrl;
                model.UpOnLineTime = Convert.ToDateTime(txt_UpOnLineTime.Text);
                model.DownOnLimeTime = Convert.ToDateTime(txt_DownOnLimeTime.Text);
                model.ImgUrl = pic_upload.HasFile ? ConfigHelper.GetConfigAppSettings("ApiWebUrl") + "Imges/linglong/" + filename + fileExtension : oldmodel.ImgUrl;
                model.IsDeleted = 0;
                model.DeleterUserId = null;
                model.LastModificationTime = null;
                model.LastModifierUserId = null;
                model.CreationTime = DateTime.Now;
                model.CreatorUserId = null;
                model.ID = id;
                bll.Update(model);

                lbl_pic.Text = "";
                img_UpdateResult.ImageUrl = pic_upload.HasFile ? ConfigHelper.GetConfigAppSettings("ApiWebUrl") + "Imges/linglong/" + filename + fileExtension : oldmodel.ImgUrl;
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
                            LingLong.Admin.Model.t_bannerimage model = new LingLong.Admin.Model.t_bannerimage();
                            model.BannerTitle = txt_BannerTitle.Text;
                            model.ClickStatus = Convert.ToInt32(sel_ClickStatus.SelectedValue);
                            model.ClickTrunOnUrl = hastrunonfile ? trunonfile : null;
                            model.UpOnLineTime = Convert.ToDateTime(txt_UpOnLineTime.Text);
                            model.DownOnLimeTime = Convert.ToDateTime(txt_DownOnLimeTime.Text);
                            model.ImgUrl = ConfigHelper.GetConfigAppSettings("ApiWebUrl") + "Imges/linglong/" + filename + fileExtension;
                            model.IsDeleted = 0;
                            model.DeleterUserId = null;
                            model.LastModificationTime = null;
                            model.LastModifierUserId = null;
                            model.CreationTime = DateTime.Now;
                            model.CreatorUserId = null;

                            LingLong.Admin.BLL.t_bannerimage bll = new LingLong.Admin.BLL.t_bannerimage();
                            bll.Add(model);


                            lbl_pic.Text = "";
                            img_UpdateResult.ImageUrl = ConfigHelper.GetConfigAppSettings("ApiWebUrl") + "Imges/linglong/" + filename + fileExtension;
                            //Response.AddHeader("Refresh", "0");
                        }
                        else
                        {
                            img_UpdateResult.ImageUrl = "";
                            lbl_pic.Text = "文件大小超出8M！请重新选择！";
                        }
                    }
                    else
                    {
                        img_UpdateResult.ImageUrl = "";
                        lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
                    }
                }
                else
                {
                    img_UpdateResult.ImageUrl = "";
                    lbl_pic.Text = "请选择要上传的图片！";
                }
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

        /// <summary>
        /// 创建一个指定长度的随机salt值
        /// </summary>
        public string CreateSalt(int saltLenght)
        {
            //生成一个加密的随机数
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[saltLenght];
            rng.GetBytes(buff);
            //返回一个Base64随机数的字符串
            return Convert.ToBase64String(buff);
        }


        /// <summary>
        /// 返回加密后的字符串
        /// </summary>
        public string CreatePasswordHash(string pwd, int saltLenght)
        {
            string strSalt = CreateSalt(saltLenght);
            //把密码和Salt连起来
            string saltAndPwd = String.Concat(pwd, strSalt);
            //对密码进行哈希
            string hashenPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1");
            //转为小写字符并截取前16个字符串
            hashenPwd = hashenPwd.ToLower().Substring(0, 16);
            //返回哈希后的值
            return hashenPwd;
        }

        ////protected void Button1_Click(object sender, EventArgs e)
        ////{
        ////    if (pic_upload.HasFile)//验证是否包含文件
        ////    {
        ////        //取得文件的扩展名,并转换成小写
        ////        string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
        ////        //验证上传文件是否图片格式
        ////        //fileOk = IsImage(fileExtension);

        ////        if (fileExtension == ".jpg")
        ////        {
        ////            //对上传文件的大小进行检测，限定文件最大不超过8M
        ////            if (pic_upload.PostedFile.ContentLength < 8192000)
        ////            {
        ////                string filepath = "C:/WebSite/PublishOutput/Imges/linglong/";
        ////                if (Directory.Exists(Server.MapPath("/images/")) == false)//如果不存在就创建file文件夹
        ////                {
        ////                    Directory.CreateDirectory(Server.MapPath("/images/"));
        ////                }
        ////                string virpath = filepath + "store_img.jpg";//CreatePasswordHash(pic_upload.FileName, 4) + fileExtension;//这是存到服务器上的虚拟路径

        ////                string mappath = Server.MapPath("/images/store_img.jpg");//转换成服务器上的物理路径
        ////                FileUpload1.PostedFile.SaveAs(mappath);//保存图片

        ////                if (File.Exists(virpath))
        ////                {
        ////                    File.Delete(virpath);
        ////                }
        ////                File.Copy(mappath, virpath, true);

        ////                Response.AddHeader("Refresh", "0");
        ////            }
        ////            else
        ////            {
        ////                pic.ImageUrl = "";
        ////                lbl_pic.Text = "文件大小超出8M！请重新选择！";
        ////            }
        ////        }
        ////        else
        ////        {
        ////            pic.ImageUrl = "";
        ////            lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
        ////        }
        ////    }
        ////    else
        ////    {
        ////        pic.ImageUrl = "";
        ////        lbl_pic.Text = "请选择要上传的图片！";
        ////    }
        ////}
    }
}