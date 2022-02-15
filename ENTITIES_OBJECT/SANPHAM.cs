using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnLTHDT.ENTITIES_OBJECT
{
    public class SANPHAM
    {
        public int ID { get; set; }
        public string TenHang { get; set; }
        public DateTime HanDung { get; set; }
        public string CongtySX { get; set; }
        public int NamSanXuat { get; set; }
        public string LoaiHang { get; set; }
        
        public SANPHAM (int ID, string TenHang, DateTime HanDung, string CongtySX, int NamSanXuat, string LoaiHang)
        {
            this.ID = ID;
            this.TenHang = TenHang;
            this.HanDung = HanDung;
            this.CongtySX = CongtySX;
            this.NamSanXuat = NamSanXuat;
            this.LoaiHang = LoaiHang;
        }
    }
}
