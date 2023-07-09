using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Models
{
    public class DangKy
    {
        [Required(ErrorMessage = "Phải nhập họ tên khách hàng")]
        public string Hotenkh { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string RetypePassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Sodienthoai { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
    }
}