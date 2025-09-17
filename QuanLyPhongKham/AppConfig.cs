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
        public static string businesstype => ConfigurationManager.AppSettings["BusinessType"];
        public static string businessname => ConfigurationManager.AppSettings["BusinessName"];
        public static string businessservice => ConfigurationManager.AppSettings["BusinessService"];
        public static string businessphone => ConfigurationManager.AppSettings["BusinessPhone"];
        public static string businessaddress => ConfigurationManager.AppSettings["BusinessAddress"];
        public static string businessfb => ConfigurationManager.AppSettings["BusinessFB"];

    }
}
