using System;
using System.Collections.Generic;
using System.Text;
using DoAnLTHDT.DATA_SERVICE;
using DoAnLTHDT.ENTITIES_OBJECT;

namespace DoAnLTHDT.BUSSINESS_SERVICE
{
    public class XL_SANPHAM
    {
        public List<SANPHAM> TimSanPham (string keyword)
        {
            var lt = new LT_SANPHAM();
            var dsSanPham = lt.DocdsSanPham();

            List<SANPHAM> ketqua = new List<SANPHAM>();
            foreach (var sp in dsSanPham)
            {
                if (sp.TenHang.Contains(keyword))
                {
                    ketqua.Add(sp);
                }
            }
            return ketqua;
        }

        public void ThemSanPham (string TenHang, DateTime HanDung, string CongtySX, int NamSanXuat, string LoaiHang)
        {
            var lt = new LT_SANPHAM();
            var dsSanPham = lt.DocdsSanPham();
            int ID = 0;
            for (int i = 0; i<dsSanPham.Count; i++)
            {
                if(ID<dsSanPham[i].ID)
                {
                    ID = dsSanPham[i].ID;
                }
            }
            ID++;
            SANPHAM sp = new SANPHAM(ID, TenHang, HanDung, CongtySX, NamSanXuat, LoaiHang);
            lt.LuuSanPham(sp);
        }

        public void SuaSanPham(SANPHAM sp)
        {
            var lt = new LT_SANPHAM();
            var dsSanPham = lt.DocdsSanPham();
            for(int i = 0; i<dsSanPham.Count; i++)
            {
                if(dsSanPham[i].ID == sp.ID)
                {
                    dsSanPham[i] = sp;
                }
            }
            lt.LuuTruDanhSach(dsSanPham);
        }

        public void XoaSanPham(int ID)
        {
            var lt = new LT_SANPHAM();
            var dsSanPham = lt.DocdsSanPham();
            for(int i = 0; i<dsSanPham.Count; i++)
            {
                if (dsSanPham[i].ID == ID)
                {
                    dsSanPham.Remove(dsSanPham[i]);
                }
            }
            lt.LuuTruDanhSach(dsSanPham);
        }

        public SANPHAM DocSanPham (int ID)
        {
            var lt = new LT_SANPHAM();
            var dsSanPham = lt.DocdsSanPham();
            for(int i = 0; i<dsSanPham.Count; i++)
            {
                if (dsSanPham[i].ID == ID)
                {
                    return dsSanPham[i];
                }
            }
            return null;
        }

        public List<SANPHAM> HangHetHan ()
        {
            var lt = new LT_SANPHAM();
            var dsSanPham = lt.DocdsSanPham();
            List<SANPHAM> ketqua = new List<SANPHAM>();
            foreach (var sp in dsSanPham)
            {
                if (sp.HanDung < DateTime.Now)
                {
                    ketqua.Add(sp);
                }
            }
            return ketqua;
        }

        public int[] HangTonKho()
        {
            var ltSP = new LT_SANPHAM();
            var dsSanPham = ltSP.DocdsSanPham();

            var ltLH = new LT_LOAIHANG();
            var dsLoaiHang = ltLH.DocdsLoaiHang();
            int[] ketqua = new int[dsLoaiHang.Count];

            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                for (int j = 0; j < dsSanPham.Count; j++)
                {
                    if (dsLoaiHang[i].LoaiHang == dsSanPham[j].LoaiHang)
                    {
                        ketqua[i]++;
                    }
                }
            }

            return ketqua;
        }
    }
}
