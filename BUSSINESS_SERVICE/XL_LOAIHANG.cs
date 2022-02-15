using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnLTHDT.DATA_SERVICE;
using DoAnLTHDT.ENTITIES_OBJECT;

namespace DoAnLTHDT.BUSSINESS_SERVICE
{
    public class XL_LOAIHANG
    {
        public List<LOAIHANG> TimLoaiHang(string keyword)
        {
            var lt = new LT_LOAIHANG();
            var dsLoaiHang = lt.DocdsLoaiHang();
            List<LOAIHANG> ketqua = new List<LOAIHANG>();

            foreach (var h in dsLoaiHang)
            {
                if (h.LoaiHang.Contains(keyword))
                {
                    ketqua.Add(h);
                }
            }
            return ketqua;
        }

        public void ThemLoaiHang(string LoaiHang)
        {
            var lt = new LT_LOAIHANG();
            var dsLoaiHang = lt.DocdsLoaiHang();
            int ID = 0;
            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                if (ID < dsLoaiHang[i].ID)
                {
                    ID = dsLoaiHang[i].ID;
                }
            }
            ID++;
            LOAIHANG sp = new LOAIHANG(ID, LoaiHang);
            lt.LuuLoaiHang(sp);
        }

        public void SuaLoaiHang(LOAIHANG h)
        {
            var lt = new LT_LOAIHANG();
            var dsLoaiHang = lt.DocdsLoaiHang();
            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                if (dsLoaiHang[i].ID == h.ID)
                {
                    dsLoaiHang[i] = h;
                }
            }
            lt.LuuTruDanhSach(dsLoaiHang);
        }

        public void XoaLoaiHang(int ID)
        {
            var ltLH = new LT_LOAIHANG();
            var dsLoaiHang = ltLH.DocdsLoaiHang();

            var ltSP = new LT_SANPHAM();
            var dsSanPham = ltSP.DocdsSanPham();

            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                if (dsLoaiHang[i].ID == ID)
                {
                    bool check = false;
                    for (int j = 0; j < dsSanPham.Count; j++)
                    {
                        if (dsLoaiHang[i].LoaiHang == dsSanPham[j].LoaiHang)
                        {
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        dsLoaiHang.RemoveAt(i);
                    }
                    else
                    {
                        Console.WriteLine("Khong the xoa Loai hang nay");
                    }
                }
            }
            ltLH.LuuTruDanhSach(dsLoaiHang);
        }


        public LOAIHANG DocLoaiHang(int ID)
        {
            var lt = new LT_LOAIHANG();
            var dsLoaiHang = lt.DocdsLoaiHang();
            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                if (dsLoaiHang[i].ID == ID)
                {
                    return dsLoaiHang[i];
                }
            }
            return null;
        }


    }
}