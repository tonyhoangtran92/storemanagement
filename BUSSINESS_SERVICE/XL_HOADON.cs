using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnLTHDT.DATA_SERVICE;
using DoAnLTHDT.ENTITIES_OBJECT;

namespace DoAnLTHDT.BUSSINESS_SERVICE
{
    public class XL_HOADON
    {
        public List<HOADON> TimHoaDon(string keyword)
        {
            var lt = new LT_HOADON();
            var dsHoaDon = lt.DocdsHoaDon();
            List<HOADON> ketqua = new List<HOADON>();
            foreach (var h in dsHoaDon)
            {
                if (h.LoaiHoaDon.Contains(keyword))
                {
                    ketqua.Add(h);
                }
            }
            return ketqua;
        }

        public void ThemHoaDon(string LoaiHoaDon, DateTime NgayTao)
        {
            var lt = new LT_HOADON();
            var dsHoaDon = lt.DocdsHoaDon();
            int ID = 0;
            for (int i = 0; i < dsHoaDon.Count; i++)
            {
                if (ID < dsHoaDon[i].ID)
                {
                    ID = dsHoaDon[i].ID;
                }
            }
            ID++;
            HOADON h = new HOADON(ID, LoaiHoaDon, NgayTao);
            lt.LuuHoaDon(h);
        }

        public void SuaHoaDon(HOADON h)
        {
            var lt = new LT_HOADON();
            var dsHoaDon = lt.DocdsHoaDon();
            for (int i = 0; i < dsHoaDon.Count; i++)
            {
                if (dsHoaDon[i].ID == h.ID)
                {
                    dsHoaDon[i] = h;
                }
            }
            lt.LuuTruDanhSach(dsHoaDon);
        }

        public void XoaHoaDon(int ID)
        {
            var lt = new LT_HOADON();
            var dsHoaDon = lt.DocdsHoaDon();
            for (int i = 0; i < dsHoaDon.Count; i++)
            {
                if (dsHoaDon[i].ID == ID)
                {
                    dsHoaDon.RemoveAt(i);
                }
            }
            lt.LuuTruDanhSach(dsHoaDon);
        }

        public HOADON DocHoaDon(int ID)
        {
            var lt = new LT_HOADON();
            var dsHoaDon = lt.DocdsHoaDon();
            for (int i = 0; i < dsHoaDon.Count; i++)
            {
                if (dsHoaDon[i].ID == ID)
                {
                    return dsHoaDon[i];
                }
            }
            return null;
        }


    }
}