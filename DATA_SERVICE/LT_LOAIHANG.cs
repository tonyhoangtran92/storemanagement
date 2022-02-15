using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnLTHDT.ENTITIES_OBJECT;
using System.IO;

namespace DoAnLTHDT.BUSSINESS_SERVICE
{
    public class LT_LOAIHANG
    {
        public List<LOAIHANG> DocdsLoaiHang()
        {
            List<LOAIHANG> ds = new List<LOAIHANG>();
            StreamReader reader = new StreamReader("D:\\CNTT\\2_SEM2_2020_2021\\LTHDT\\DoAnLTHDT_due3005\\DoAnLTHDT\\data\\dsLoaiHang.txt");
            string h = reader.ReadLine();
            int N = int.Parse(h);
            for (int i = 0; i < N; i++)
            {
                h = reader.ReadLine();
                string[] M = h.Split(',');
                LOAIHANG sp = new LOAIHANG(int.Parse(M[0]),M[1].Trim());
                
                ds.Add(sp);
            }
            reader.Close();

            return ds;
        }

   
        public void LuuTruDanhSach(List<LOAIHANG> ds)
        {
            StreamWriter writer = new StreamWriter("D:\\CNTT\\2_SEM2_2020_2021\\LTHDT\\DoAnLTHDT_due3005\\DoAnLTHDT\\data\\dsLoaiHang.txt");
            writer.WriteLine(ds.Count);
            foreach (var sp in ds)
            {
                writer.WriteLine($"{sp.ID},{sp.LoaiHang}");
            }
            writer.Close();
        }


        public void LuuLoaiHang(LOAIHANG h)
        {
            var ds = DocdsLoaiHang();
            ds.Add(h);
            LuuTruDanhSach(ds);
        }

    }
}