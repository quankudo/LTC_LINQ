using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class NhanVien
    {
        public int id_332 { get; set; }
        public string name_332 { get; set; }
        public int age_332 { get; set; }
        public int salary_332 { get; set; }
        public int idDepartment_332 { get; set; }

        public NhanVien()
        {
            
        }

        public NhanVien(int id_332, string name_332, int age_332, int salary_33, int idDepartment_332)
        {
            this.id_332 = id_332;
            this.name_332 = name_332;
            this.age_332 = age_332;
            this.salary_332 = salary_332;
            this.idDepartment_332 = idDepartment_332;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {id_332} - Tên: {name_332} - Tuổi: {age_332}");
        }
    }
}
