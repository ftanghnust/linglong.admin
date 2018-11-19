using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingLong.Admin.Model
{
    /// <summary>
    /// t_particulars:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_particulars
    {
        public t_particulars()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _textcontent;
        private DateTime? _createtime;
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
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TextContent
        {
            set { _textcontent = value; }
            get { return _textcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }


}
