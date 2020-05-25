using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThuVienOnline.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời Nhập UserName")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Mời Nhập PassWord")]
        public string PassWord { set; get; }
        
    }
}