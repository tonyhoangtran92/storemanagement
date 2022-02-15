using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnLTHDT.ENTITIES_OBJECT;
using System.IO;

namespace DoAnLTHDT.BUSSINESS_SERVICE
{
    public class LT_HOADON
    {
        public List<HOADON> DocdsHoaDon()
        {
            List<HOADON> ds = new List<HOADON>();
            StreamReader reader = new StreamReader("D:\\CNTT\\2_SEM2_2020_2021\\LTHDT\\DoAnLTHDT_due3005\\DoAnLTHDT\\data\\dsHoaDon.txt");
            string s = reader.ReadLine();
            int N = int.Parse(s);
            for (int i = 0; i < N; i++)
            {
                s = reader.ReadLine();
                string[] M = s.Split(',');
                HOADON h = new HOADON(int.Parse(M[0]),M[1].Trim(),DateTime.Parse(M[2]));

                ds.Add(h);
            }
            reader.Close();

            return ds;
        }


        public void LuuTruDanhSach(List<HOADON> ds)
        {
            StreamWriter writer = new StreamWriter("D:\\CNTT\\2_SEM2_2020_2021\\LTHDT\\DoAnLTHDT_due3005\\DoAnLTHDT\\data\\dsHoaDon.txt");
            writer.WriteLine(ds.Count);
            foreach (var h in ds)
            {
                writer.WriteLine($"{h.ID},{h.LoaiHoaDon},{h.NgayTao}");
            }
            writer.Close();
        }

  
        public void LuuHoaDon(HOADON h)
        {
            var ds = DocdsHoaDon();
            ds.Add(h);
            LuuTruDanhSach(ds);
        }
    }
}