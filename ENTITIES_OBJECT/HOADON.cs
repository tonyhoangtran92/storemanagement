using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnLTHDT.BUSSINESS_SERVICE
{
    public class HOADON
    {
        public int ID { get; set; }
        public string LoaiHoaDon { get; set; }
        public DateTime NgayTao { get; set; }

        public HOADON(int ID, string LoaiHoaDon, DateTime NgayTao)
        {
            this.ID = ID;
            this.LoaiHoaDon = LoaiHoaDon;
            this.NgayTao = NgayTao;
        }
    }
}