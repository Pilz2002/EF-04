using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04.Entity
{
    public class PhieuThu
    {
        public int PhieuThuId {  get; set; }
        public DateTime NgayLap { get; set; }   
        public string NhanVienLap {  get; set; }
        public string GhiChu {  get; set; }
        public int ThanhTien { get; set; }

    }
}
