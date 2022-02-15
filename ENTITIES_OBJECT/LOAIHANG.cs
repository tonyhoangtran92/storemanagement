using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnLTHDT.BUSSINESS_SERVICE
{
    public class LOAIHANG
    {
        public int ID { get; set; }
        public string LoaiHang { get; set; }

        public LOAIHANG(int ID, string LoaiHang)
        {
            this.ID = ID;
            this.LoaiHang = LoaiHang;
        }
    }
}