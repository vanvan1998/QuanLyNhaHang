﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public class Table
    {
        public string number { get; set; }
        public string type { get; set; }
        public int numberOfSeat { get; set; }
        public string status { get; set; }
        public string note { get; set; }
        public string IDCustomer { get; set; }
        public DateTime time { get; set; }
    }
}
