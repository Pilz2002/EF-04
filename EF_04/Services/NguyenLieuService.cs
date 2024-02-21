using EF_04.Entity;
using EF_04.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04.Services
{
    public class NguyenLieuService : INguyenLieuService
    {
        private readonly AppDbContext dbContext;
        public NguyenLieuService()
        {
            dbContext = new AppDbContext();
        }
        public void ThemNguyenLieu()
        {
            Console.WriteLine("Nhập loại nguyên liệu ID: ");
            int loaiNguyenLieuId = int.Parse(Console.ReadLine());
            var loaiNguyenLieu = dbContext.LoaiNguyenLieu.Find(loaiNguyenLieuId);
            if(loaiNguyenLieu == null)
            {
                Console.WriteLine("Chưa có loại nguyên liệu này");
            }
            else
            {
                Console.WriteLine("Tên nguyên liệu: ");
                string tenNguyenLieu = Console.ReadLine();
                Console.WriteLine("Giá bán: ");
                int giaBan = int.Parse(Console.ReadLine());
                Console.WriteLine("Đơn vị tính: ");
                string donViTinh = Console.ReadLine();
                Console.WriteLine("Số lượng kho: ");
                int soLuongKho = int.Parse(Console.ReadLine());

                NguyenLieu nguyenLieu = new NguyenLieu
                {
                    LoaiNguyenLieuId = loaiNguyenLieuId,
                    TenNguyenLieu = tenNguyenLieu,
                    GiaBan = giaBan,
                    DonViTinh = donViTinh,
                    SoLuongKho= soLuongKho,
                };
                dbContext.Add(nguyenLieu);
                dbContext.SaveChanges();
                Console.WriteLine("Thêm nguyên liệu thành công");
            }
        }
    }
}
