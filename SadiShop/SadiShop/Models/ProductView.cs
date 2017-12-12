using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
 
namespace SadiShop.Models
{
    public class ProductView
    {
        public string tensanpham { get; set; }
        public string tenloai { get; set; }
        public string masanpham { get; set; }
        public string manhasanxuat { get; set; }
        public string thongtin { get; set; }
        public double giaban { get; set; }
        public string hinh1 { get; set; }
        public string hinh2 { get; set; }
        public string hinh3 { get; set; }
        public string hinh4 { get; set; }
        public string hinh5 { get; set; }
    }
}