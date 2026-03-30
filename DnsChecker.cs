using System;
using System.Diagnostics;

namespace frmdnschange
{
    /// <summary>
    /// DNS checker utilities for verifying DNS configuration
    /// </summary>
    public class DnsChecker
    {
        /// <summary>
        /// Check Cloudflare DNS configuration
        /// Opens 1.1.1.1/help to verify DoH/DoT usage
        /// </summary>
        public static void CheckCloudflare()
        {
            try
            {
                string url = "http://1.1.1.1/help";
                Process.Start(url);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to open Cloudflare check: " + ex.Message);
            }
        }

        /// <summary>
        /// Check AdGuard DNS configuration
        /// Opens adguard-dns.io/en/welcome.html to verify AdGuard DNS usage
        /// </summary>
        public static void CheckAdGuard()
        {
            try
            {
                string url = "https://adguard-dns.io/en/welcome.html";
                Process.Start(url);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to open AdGuard check: " + ex.Message);
            }
        }

        /// <summary>
        /// Check alternative Cloudflare IPv6
        /// </summary>
        public static void CheckCloudflareIPv6()
        {
            try
            {
                string url = "http://[2606:4700:4700::1111]/help";
                Process.Start(url);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to open Cloudflare IPv6 check: " + ex.Message);
            }
        }

        /// <summary>
        /// Open DNS query info page
        /// </summary>
        public static void OpenDnsInfo()
        {
            try
            {
                string url = "https://1.1.1.1/dns-query";
                Process.Start(url);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to open DNS info: " + ex.Message);
            }
        }
    }
}
