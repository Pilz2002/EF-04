using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04.Entity
{
    public class NguyenLieu
    {
        public int NguyenLieuId { get; set; }
        public int LoaiNguyenLieuId { get; set; }
        public LoaiNguyenLieu LoaiNguyenLieu { get; set; }
        public string TenNguyenLieu { get; set; }
        public int GiaBan {  get; set; }
        public string DonViTinh { get; set; }
        public int SoLuongKho {  get; set; }
    }
}
