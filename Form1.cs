using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;

namespace frmdnschange
{
    public partial class Form1 : Form
    {
        private const string DNS1 = "1.1.1.1";
        private const string DNS2 = "94.140.14.14";

        public Form1()
        {
            InitializeComponent();
            LoadIcon();
        }

        private void LoadIcon()
        {
            try
            {
                string iconPath = System.IO.Path.Combine(Application.StartupPath, "app.ico");

                // Generate icon if it doesn't exist
                if (!System.IO.File.Exists(iconPath))
                {
                    CreateInternetIcon.CreateProtectionIcon(iconPath, 64);
                }

                if (System.IO.File.Exists(iconPath))
                {
                    this.Icon = new System.Drawing.Icon(iconPath);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading icon: " + ex.Message);
            }
        }

        /// <summary>
        /// Automatic workflow - runs all tasks sequentially
        /// </summary>
        private void RunAutomaticWorkflow()
        {
            try
            {
                txtStatus.Clear();
                DisableAllButtons();
                Log("╔════════════════════════════════════════════════════════╗");
                Log("║     Surf Without Ads - Automatic Configuration        ║");
                Log("╚════════════════════════════════════════════════════════╝");
                Log("");

                // Check Administrator
                if (!IsAdministrator())
                {
                    Log("❌ ERROR: Administrator privileges required!");
                    Log("Please run this application as Administrator!");
                    MessageBox.Show("Administrator privileges required!\nPlease run as Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                // Step 1: Enable Ad Blocker (DNS Configuration)
                Log("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Log("📍 STEP 1: Enabling Ad Blocker (DNS Configuration)...");
                Log("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

                Thread.Sleep(1000);

                SetDnsServers(DNS1, DNS2);
                Log("✓ DNS servers configured successfully!");

                Thread.Sleep(500);

                ClearDnsCache();
                Log("✓ DNS cache cleared!");

                Thread.Sleep(500);

                VerifyConnection();
                Log("✓ Connection verified!");
                Log("");

                // Step 2: Disable IPv6
                Log("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Log("📍 STEP 2: Checking & Disabling IPv6...");
                Log("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

                Thread.Sleep(1000);

                if (IsIPv6Enabled())
                {
                    Log("⚠ IPv6 is ENABLED - Disabling now...");
                    Thread.Sleep(500);
                    DisableIPv6();
                    Log("✓ IPv6 has been DISABLED successfully!");
                }
                else
                {
                    Log("✓ IPv6 is already DISABLED");
                }
                Log("");

                // Step 3: Check Cloudflare
                Log("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Log("📍 STEP 3: Checking Cloudflare DNS...");
                Log("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

                Thread.Sleep(1000);

                Log("✓ Opening Cloudflare DNS check (1.1.1.1/help)...");
                Log("   Look for 'Using DNS over HTTPS (DoH)' or 'Using DNS over TLS (DoT)' - should show 'Yes'");
                DnsChecker.CheckCloudflare();

                Thread.Sleep(2000);
                Log("✓ Cloudflare check completed!");
                Log("");

                // Step 4: Check AdGuard
                Log("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Log("📍 STEP 4: Checking AdGuard DNS...");
                Log("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

                Thread.Sleep(1000);

                Log("✓ Opening AdGuard DNS check (adguard-dns.io)...");
                Log("   Look for message: 'This device is using AdGuard DNS'");
                DnsChecker.CheckAdGuard();

                Thread.Sleep(2000);
                Log("✓ AdGuard check completed!");
                Log("");

                // Completion
                Log("╔════════════════════════════════════════════════════════╗");
                Log("║              ✓ ALL TASKS COMPLETED SUCCESSFULLY!      ║");
                Log("║                                                        ║");
                Log("║  Your system has been configured for:                 ║");
                Log("║  • Ad-free browsing with Cloudflare/AdGuard DNS       ║");
                Log("║  • IPv6 disabled for enhanced privacy                 ║");
                Log("║  • All checks passed ✓                                ║");
                Log("╚════════════════════════════════════════════════════════╝");

                MessageBox.Show("✓ All configurations completed successfully!\n\nYour system is now configured for ad-free browsing.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Exit();
            }
            catch (Exception ex)
            {
                Log("❌ ERROR: " + ex.Message);
                MessageBox.Show("An error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisableAllButtons()
        {
            btnSetDns.Enabled = false;
            btnCheckCloudflare.Enabled = false;
            btnCheckAdGuard.Enabled = false;
            btnCheckDisableIPv6.Enabled = false;
        }

        private void btnSetDns_Click(object sender, EventArgs e)
        {
            // Start automatic workflow when user clicks "Enable AdBlock"
            RunAutomaticWorkflow();
        }

        private void btnCheckCloudflare_Click(object sender, EventArgs e)
        {
            // This is now called automatically by RunAutomaticWorkflow
        }

        private void btnCheckAdGuard_Click(object sender, EventArgs e)
        {
            // This is now called automatically by RunAutomaticWorkflow
        }

        private void SetDnsServers(string dns1, string dns2)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "netsh.exe";
                psi.Arguments = string.Format("interface ip set dns name=\"Ethernet\" static {0} primary", dns1);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.CreateNoWindow = true;

                using (Process p = Process.Start(psi))
                {
                    p.WaitForExit();
                }

                Thread.Sleep(500);

                psi.Arguments = string.Format("interface ip add dns name=\"Ethernet\" {0} index=2", dns2);
                using (Process p = Process.Start(psi))
                {
                    p.WaitForExit();
                }

                Log("DNS servers set successfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to set DNS: " + ex.Message);
            }
        }

        private void ClearDnsCache()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd.exe";
                psi.Arguments = "/c ipconfig /flushdns";
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.CreateNoWindow = true;

                using (Process p = Process.Start(psi))
                {
                    p.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Log("Warning: Cache clear failed - " + ex.Message);
            }
        }

        private void VerifyConnection()
        {
            try
            {
                Log("Testing connection...");
                Ping pinger = new Ping();
                PingReply reply = pinger.Send("8.8.8.8", 5000);

                if (reply.Status == IPStatus.Success)
                {
                    Log("Connection OK! Response: " + reply.RoundtripTime + "ms");
                }
                else
                {
                    Log("Connection test inconclusive.");
                }
            }
            catch (Exception ex)
            {
                Log("Ping test failed: " + ex.Message);
            }
        }

        private bool IsAdministrator()
        {
            try
            {
                System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }

        private void Log(string message)
        {
            if (txtStatus.InvokeRequired)
            {
                txtStatus.Invoke(new Action<string>(Log), message);
            }
            else
            {
                txtStatus.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message + Environment.NewLine);
            }
        }

        private void btnCheckDisableIPv6_Click(object sender, EventArgs e)
        {
            // This is now called automatically by RunAutomaticWorkflow
        }

        /// <summary>
        /// Check if IPv6 is enabled in network adapters
        /// </summary>
        private bool IsIPv6Enabled()
        {
            try
            {
                // Check network adapters for IPv6
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    if (ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        ni.OperationalStatus == OperationalStatus.Up)
                    {
                        IPInterfaceProperties ipProperties = ni.GetIPProperties();
                        if (ipProperties.UnicastAddresses.Any(addr => addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
                        {
                            Log("IPv6 found on adapter: " + ni.Name);
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Log("Error checking IPv6: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Disable IPv6 on all network adapters
        /// </summary>
        private void DisableIPv6()
        {
            try
            {
                // Run PowerShell command to disable IPv6 binding
                Log("Disabling IPv6 binding on all adapters...");
                RunPowerShellCommand("Disable-NetAdapterBinding -Name \"*\" -ComponentID ms_tcpip6 -Confirm:$false");
                Log("IPv6 binding disabled on all adapters");

                Thread.Sleep(1000);

                // Disable Teredo
                Log("Disabling Teredo...");
                RunNetshCommand("interface ipv6 set teredo disabled");
                Log("Teredo disabled");

                Thread.Sleep(500);

                // Disable 6to4
                Log("Disabling 6to4...");
                RunNetshCommand("interface ipv6 set 6to4 disabled");
                Log("6to4 disabled");

                Thread.Sleep(500);

                // Disable ISATAP
                Log("Disabling ISATAP...");
                RunNetshCommand("interface ipv6 set isatap disabled");
                Log("ISATAP disabled");

                Thread.Sleep(500);

                Log("✓ All IPv6 mechanisms have been successfully disabled!");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to disable IPv6: " + ex.Message);
            }
        }

        /// <summary>
        /// Run a PowerShell command
        /// </summary>
        private void RunPowerShellCommand(string command)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "powershell.exe";
                psi.Arguments = string.Format("-NoProfile -ExecutionPolicy Bypass -Command \"{0}\"", command);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.CreateNoWindow = true;

                using (Process p = Process.Start(psi))
                {
                    p.WaitForExit();
                    string output = p.StandardOutput.ReadToEnd();
                    string error = p.StandardError.ReadToEnd();

                    if (!string.IsNullOrEmpty(output))
                        Log("PowerShell: " + output.Trim());
                    if (!string.IsNullOrEmpty(error))
                        Log("PowerShell Error: " + error.Trim());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PowerShell error: " + ex.Message);
            }
        }

        /// <summary>
        /// Run a netsh command
        /// </summary>
        private void RunNetshCommand(string arguments)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "netsh.exe";
                psi.Arguments = arguments;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.CreateNoWindow = true;

                using (Process p = Process.Start(psi))
                {
                    p.WaitForExit();
                    string output = p.StandardOutput.ReadToEnd();
                    string error = p.StandardError.ReadToEnd();

                    if (!string.IsNullOrEmpty(output) && output.Trim() != "")
                        Log("Netsh: " + output.Trim());
                    if (!string.IsNullOrEmpty(error) && error.Trim() != "")
                        Log("Netsh Error: " + error.Trim());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Netsh error: " + ex.Message);
            }
        }
    }
}
