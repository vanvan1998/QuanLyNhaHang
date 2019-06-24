using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public class Promotion
    {
        public string id { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public int value { get; set; }
        public string rule { get; set; }
        public bool active { get; set; }
    }
}
