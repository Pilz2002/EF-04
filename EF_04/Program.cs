using EF_04.IServices;
using EF_04.Services;

void Main()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.InputEncoding = System.Text.Encoding.UTF8;
    IChiTietPhieuThuService chiTietPhieuThuService = new ChiTietPhieuThuService();
    INguyenLieuService nguyenLieuService = new NguyenLieuService();
    IPhieuThuService phieuThuService = new PhieuThuService();

    Console.WriteLine("------------------------------QUẢN LÝ PHIẾU THU(EF-04)------------------------------");
    Console.WriteLine("1. Thêm nguyên liệu");
    Console.WriteLine("2. Thêm phiếu thu");
    Console.WriteLine("3. Xóa phiếu thu");
    Console.WriteLine("4. Hiển thị thông tin các phiếu thu theo thời gian");
    Console.WriteLine("5. Thoát chương trình");
    Console.WriteLine();
    string choice;
    do
    {
        Console.WriteLine();
        Console.Write("Chọn chức năng(1-6): ");
        choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                nguyenLieuService.ThemNguyenLieu();
                break;
            case "2":
                phieuThuService.ThemPhieuThu();
                break;
            case "3":
                phieuThuService.XoaPhieuThu();
                break;
            case "4":
                phieuThuService.HienThiPhieuThuTheoThoiGian();
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                break;
        }
    } while (choice != "6");
}
Main();