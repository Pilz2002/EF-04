using EF_04.Entity;
using EF_04.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_04.Entity;


namespace EF_04.Services
{
	public class PhieuThuService : IPhieuThuService
	{
		private readonly AppDbContext dbContext;
		private readonly ChiTietPhieuThuService ct;
		public PhieuThuService()
		{
			dbContext = new AppDbContext();
			ct = new ChiTietPhieuThuService();
		}
		public void HienThiPhieuThuTheoThoiGian()
		{
			var phieuThuList = dbContext.PhieuThu.OrderByDescending(x => x.NgayLap).ToList();
			foreach (var temp in phieuThuList)
			{
				Console.WriteLine(temp);
			}
			var phieuThuSanPham = dbContext.PhieuThu
								   .Join(dbContext.ChiTietPhieuThu, pt => pt.PhieuThuId, ctpt => ctpt.PhieuThuId, (pt, ctpt) => new { PhieuThu = pt, ChiTietPhieuThu = ctpt })
								   .Join(dbContext.NguyenLieu, ctpt => ctpt.ChiTietPhieuThu.NguyenLieuId, nl => nl.NguyenLieuId, (ctpt, nl) => new { ChiTietPhieuThu = ctpt, NguyenLieu = nl })
								   .Select(x => new { x.NguyenLieu.TenNguyenLieu, x.ChiTietPhieuThu.ChiTietPhieuThu.SoLuongBan });
			foreach (var temp in phieuThuSanPham)
			{
				Console.WriteLine(temp);
			}

		}
		public void ThemPhieuThu()
		{
			Console.WriteLine("Ngày lập: ");
			DateTime ngayLap = DateTime.Parse(Console.ReadLine());
			Console.WriteLine("Nhân viên lập: ");
			string nhanVienLap = Console.ReadLine();
			Console.WriteLine("Ghi chú: ");
			string ghiChu = Console.ReadLine();
			var phieuThu = new PhieuThu
			{
				NgayLap = ngayLap,
				NhanVienLap = nhanVienLap,
				GhiChu = ghiChu,
				ThanhTien = 0
			};
			dbContext.Add(phieuThu);
			dbContext.SaveChanges();
			Console.WriteLine("Thêm phiếu thu thành công");
			Console.WriteLine("Thêm chi tiết phiếu thu: ");
			
			int id = dbContext.PhieuThu.OrderByDescending(x => x.PhieuThuId).FirstOrDefault().PhieuThuId;

			string c;
			do
			{
				ct.ThemChiTietPhieuThu(id);
				Console.WriteLine("Nhập 0 để dừng thêm chi tiết");
				c = Console.ReadLine();
			} while (c != "0");

		
			var query = dbContext.ChiTietPhieuThu.Include(x => x.NguyenLieu).ToList().FindAll(x => x.PhieuThuId == id);
								   
            foreach (var item in query)
            {
				phieuThu.ThanhTien += (item.SoLuongBan * item.NguyenLieu.GiaBan);
            }
			dbContext.Update(phieuThu);
			dbContext.SaveChanges();
        }

		public void XoaPhieuThu()
		{
			Console.WriteLine("Nhập phiếu thu ID: ");
			int phieuThuId = int.Parse(Console.ReadLine());
			var phieuThuDelete = dbContext.PhieuThu.Find(phieuThuId);
			if (phieuThuDelete != null)
			{
				dbContext.Remove(phieuThuDelete);
				dbContext.SaveChanges();
			}
			else
			{
				Console.WriteLine("Không có phiếu thu cần xóa");
			}
		}
	}
}
