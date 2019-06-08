using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public partial class Employee
    {
        public string id { get; set; }
        public string ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string displayName { get; set; }
        public string role { get; set; }
        public string dateOfBirth { get; set; }
        public string identityNumber { get; set; }
        public string phone { get; set; }
    }
}
