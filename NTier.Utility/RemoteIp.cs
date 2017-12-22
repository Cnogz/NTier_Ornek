using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace NTier.Utility
{
    public static class RemoteIp
    {
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily==AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "Local IP Address Not Found!";
        }

        public static string IpAddress { get { return GetIpAddress(); } }
    }
}
