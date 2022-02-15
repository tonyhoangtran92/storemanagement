using System;
using System.Collections.Generic;
using System.Text;
using DoAnLTHDT.ENTITIES_OBJECT;
using System.IO;

namespace DoAnLTHDT.DATA_SERVICE
{
    public class LT_SANPHAM
    {
        public List <SANPHAM> DocdsSanPham()
        {
            List<SANPHAM> ds = new List<SANPHAM>();
            StreamReader reader = new StreamReader("D:\\CNTT\\2_SEM2_2020_2021\\LTHDT\\DoAnLTHDT_due3005\\DoAnLTHDT\\data\\dsSanPham.txt");
            string s = reader.ReadLine();
            int N = int.Parse(s);
            for (int i = 0; i < N; i++)
            {
                s = reader.ReadLine();
                string[] M = s.Split(',');
                SANPHAM sp = new SANPHAM(int.Parse(M[0]),M[1].Trim(),DateTime.Parse(M[2]),M[3].Trim(),int.Parse(M[4]),M[5].Trim());

                ds.Add(sp);
            }

            reader.Close();

            return ds;
        }

 
   
        public void LuuTruDanhSach(List <SANPHAM> ds)
        {
            StreamWriter writer = new StreamWriter("D:\\CNTT\\2_SEM2_2020_2021\\LTHDT\\DoAnLTHDT_due3005\\DoAnLTHDT\\data\\dsSanPham.txt");
            writer.WriteLine(ds.Count);
            foreach (var sp in ds)
            {
                writer.WriteLine($"{sp.ID},{sp.TenHang},{sp.HanDung},{sp.CongtySX},{sp.NamSanXuat},{sp.LoaiHang}");
            }
            writer.Close();
        }

        public void LuuSanPham(SANPHAM sp)
        {
            var ds = DocdsSanPham();
            ds.Add(sp);
            LuuTruDanhSach(ds);
        }
    }
}
