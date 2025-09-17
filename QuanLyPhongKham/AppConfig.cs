using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham
{
    public static class AppConfig
    {
        public static string AppMode
            => ConfigurationManager.AppSettings["AppMode"] ?? "All";
    }
}
