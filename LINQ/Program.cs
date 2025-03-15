using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<PhongBan> danhSachPhongBan = new List<PhongBan>
            {
                new PhongBan(1, "Phòng Nhân Sự"),
                new PhongBan(2, "Phòng Kế Toán"),
                new PhongBan(3, "Phòng IT"),
                new PhongBan(4, "Phòng Kinh Doanh"),
                new PhongBan(5, "Phòng Marketing")
            };

            List<NhanVien> danhSachNhanVien = new List<NhanVien>
            {
                new NhanVien(1, "Nguyễn Minh Khang", 30, 15000000, 1),
                new NhanVien(2, "Trần Thu Hằng", 28, 12000000, 2),
                new NhanVien(3, "Lê Hoàng Nam", 35, 18000000, 3),
                new NhanVien(4, "Phạm Quỳnh Anh", 26, 10000000, 4),
                new NhanVien(5, "Hoàng Đức Duy", 40, 25000000, 5),
                new NhanVien(6, "Đặng Hải Yến", 32, 16000000, 1),
                new NhanVien(7, "Vũ Trọng Nghĩa", 29, 14000000, 2),
                new NhanVien(8, "Ngô Thanh Tùng", 37, 22000000, 3),
                new NhanVien(9, "Bùi Lan Chi", 27, 11000000, 4),
                new NhanVien(10, "Phan Nhật Huy", 33, 20000000, 5),
                new NhanVien(11, "Lý Tuấn Kiệt", 31, 17000000, 1),
                new NhanVien(12, "Tô Bảo Ngọc", 25, 9000000, 2),
                new NhanVien(13, "Dương Thị Thanh", 36, 19000000, 3),
                new NhanVien(14, "Mai Khánh Linh", 29, 13500000, 4),
                new NhanVien(15, "Cao Gia Bảo", 38, 24000000, 5)
            };

            Display(danhSachNhanVien, danhSachPhongBan);
            GetEmployee(danhSachNhanVien, danhSachPhongBan);
            Console.WriteLine($"Lương trung bình của công ty: {GetAverageSalary(danhSachNhanVien)} nghìn vnd");
            Console.ReadKey();
        }

        public static void Display(List<NhanVien> nhanViens, List<PhongBan> phongBans)
        {
            Console.WriteLine("------------------------Danh sách nhân viên trong công ty------------------------");
            var list = nhanViens.Join(
                phongBans, 
                nv => nv.idDepartment_332,
                pb => pb.id_332, 
                (nv, pb) => new
                {
                    nv.id_332,
                    nv.name_332,
                    nv.age_332,
                    nv.salary_332,
                    TenPhongBan = pb.name_332
                });
            foreach (var item in list)
            {
                Console.WriteLine($"Nhân viên {item.id_332}: {item.name_332} -- phòng ban {item.TenPhongBan}");
            }
        }

        public static void GetEmployee(List<NhanVien> nhanViens, List<PhongBan> phongBans)
        {
            var ls = nhanViens
                .GroupBy(nv=>nv.idDepartment_332)
                .Join(
                phongBans,
                nv => nv.Key,
                pb => pb.id_332,
                (nv, pb) => new
                {
                    TenPhongBan = pb.name_332,
                    TreNhat = nv.OrderBy(n => n.age_332).FirstOrDefault(),
                    GiaNhat = nv.OrderByDescending(n => n.age_332).FirstOrDefault(),
                    TuoiTrungBinh = nv.Average(n => n.age_332)
                });

            Console.WriteLine("Danh sách nhân viên từng phòng theo tuổi:");
            foreach (var phongBan in ls)
            {
                Console.WriteLine($"\nPhòng Ban: {phongBan.TenPhongBan}");
                Console.WriteLine($"- Nhân viên trẻ nhất: {phongBan.TreNhat.name_332}, {phongBan.TreNhat.age_332} tuổi");
                Console.WriteLine($"- Nhân viên già nhất: {phongBan.GiaNhat.name_332}, {phongBan.GiaNhat.age_332} tuổi");
                Console.WriteLine($"- Tuổi trung bình: {phongBan.TuoiTrungBinh:F2}");
            }
        }

        public static double GetAverageSalary(List<NhanVien> nhanViens)
        {
            double sum = 0;
            foreach (var item in nhanViens)
            {
                sum += item.salary_332;
            }
            return sum/nhanViens.Count;
        }
    }
}
