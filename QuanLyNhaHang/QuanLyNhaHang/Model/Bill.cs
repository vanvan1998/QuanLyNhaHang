using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public class Bill
    {
        public int billNumber { get; set; }
        public int total { get; set; }
        public int tableNumber { get; set; }
        public string time { get; set; } 
        public int count { get; set; }
        public string promotion { get; set; }
        public Customer customer { get; set; }
        public string employeeName { get; set; }
    }
}
