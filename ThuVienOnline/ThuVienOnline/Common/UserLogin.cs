using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThuVienOnline
{
    //Lưu những thông tin chung của một User khi login
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
    }
}