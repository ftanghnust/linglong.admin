using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingLong.Admin.Model
{
    public partial class t_bannerimage
    {
        public t_bannerimage()
        { }
        #region Model
        private int _id;
        private string _bannertitle;
        private int? _clickstatus;
        private string _clicktrunonurl;
        private DateTime? _uponlinetime;
        private DateTime? _downonlimetime;
        private int? _isdeleted;
        private long? _deleteruserid;
        private DateTime? _lastmodificationtime;
        private long? _lastmodifieruserid;
        private DateTime? _creationtime;
        private long? _creatoruserid;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BannerTitle
        {
            set { _bannertitle = value; }
            get { return _bannertitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ClickStatus
        {
            set { _clickstatus = value; }
            get { return _clickstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClickTrunOnUrl
        {
            set { _clicktrunonurl = value; }
            get { return _clicktrunonurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpOnLineTime
        {
            set { _uponlinetime = value; }
            get { return _uponlinetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DownOnLimeTime
        {
            set { _downonlimetime = value; }
            get { return _downonlimetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsDeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? DeleterUserId
        {
            set { _deleteruserid = value; }
            get { return _deleteruserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastModificationTime
        {
            set { _lastmodificationtime = value; }
            get { return _lastmodificationtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? LastModifierUserId
        {
            set { _lastmodifieruserid = value; }
            get { return _lastmodifieruserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreationTime
        {
            set { _creationtime = value; }
            get { return _creationtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? CreatorUserId
        {
            set { _creatoruserid = value; }
            get { return _creatoruserid; }
        }
        #endregion Model

        public string ImgUrl { set; get; }
    }

}
