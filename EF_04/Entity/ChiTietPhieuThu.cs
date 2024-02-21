using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04.Entity
{
    public class ChiTietPhieuThu
    {
        public int ChiTietPhieuThuId {  get; set; }
        public int NguyenLieuId { get; set; }
        public NguyenLieu NguyenLieu { get; set; }
        public int PhieuThuId { get; set; }
        public PhieuThu PhieuThu { get; set; }
        public int SoLuongBan { get; set; }
    }
}
