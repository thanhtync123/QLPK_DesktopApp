using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham
{
    public static class CurrentUser
    {
        public static string UserName { get; set; }
        public static string Id { get; set; }

        public static string Signature { get; set; }

        public static string Bank_account { get; set;  }

        public static string Bank_code { get; set; }
    }
}
