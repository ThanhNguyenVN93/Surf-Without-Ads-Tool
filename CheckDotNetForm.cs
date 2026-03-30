using System;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace frmdnschange
{
    /// <summary>
    /// Startup form to check and install .NET Framework 3.5
    /// </summary>
    public class CheckDotNetForm : Form
    {
        private Label statusLabel;

        public CheckDotNetForm()
        {
            this.Text = "System Requirements Check";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(500, 300);
            this.BackColor = System.Drawing.Color.White;
            this.Load += CheckDotNetFrame_Load;
        }

        private void CheckDotNetFrame_Load(object sender, EventArgs e)
        {
            // Generate app icon
            try
            {
                string iconPath = System.IO.Path.Combine(Application.StartupPath, "app.ico");
                if (!System.IO.File.Exists(iconPath))
                {
                    CreateInternetIcon.CreateProtectionIcon(iconPath, 64);
                }
            }
            catch { }

            CheckDotNetFramework();
        }

        private void CheckDotNetFramework()
        {
            try
            {
                this.Controls.Clear();

                // Add title label
                Label titleLabel = new Label();
                titleLabel.Text = "System Requirements Check";
                titleLabel.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
                titleLabel.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
                titleLabel.AutoSize = false;
                titleLabel.Bounds = new System.Drawing.Rectangle(20, 20, 460, 40);
                this.Controls.Add(titleLabel);

                // Add status label
                statusLabel = new Label();
                statusLabel.Text = "Checking .NET Framework 3.5...";
                statusLabel.AutoSize = false;
                statusLabel.Bounds = new System.Drawing.Rectangle(20, 70, 460, 100);
                statusLabel.Font = new System.Drawing.Font("Segoe UI", 11);
                this.Controls.Add(statusLabel);

                // Check if .NET Framework 3.5 is installed
                if (IsDotNet35Installed())
                {
                    // .NET 3.5 is already installed - set dialog result and close
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    statusLabel.Text = "✗ .NET Framework 3.5 is not installed.\n\nWould you like to enable it now?\n\nThis requires Administrator privileges.";
                    statusLabel.ForeColor = System.Drawing.Color.Red;
                    
                    // Add buttons
                    Button yesButton = new Button();
                    yesButton.Text = "Enable & Install";
                    yesButton.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
                    yesButton.ForeColor = System.Drawing.Color.White;
                    yesButton.Width = 150;
                    yesButton.Height = 40;
                    yesButton.Location = new System.Drawing.Point(100, 220);
                    yesButton.Click += (s, e) => EnableDotNet35();
                    this.Controls.Add(yesButton);
                    
                    Button noButton = new Button();
                    noButton.Text = "Exit";
                    noButton.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
                    noButton.ForeColor = System.Drawing.Color.Black;
                    noButton.Width = 150;
                    noButton.Height = 40;
                    noButton.Location = new System.Drawing.Point(280, 220);
                    noButton.Click += (s, e) => Application.Exit();
                    this.Controls.Add(noButton);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking system requirements:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private bool IsDotNet35Installed()
        {
            try
            {
                // Check registry for .NET Framework 3.5
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5"))
                {
                    if (key != null)
                    {
                        object installed = key.GetValue("Install");
                        if (installed != null && (int)installed == 1)
                        {
                            return true;
                        }
                    }
                }
                
                // Also check v3.0
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.0"))
                {
                    if (key != null)
                    {
                        object installed = key.GetValue("Install");
                        if (installed != null && (int)installed == 1)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void EnableDotNet35()
        {
            try
            {
                // Check if already running as Administrator
                System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                
                if (!principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                {
                    MessageBox.Show("This action requires Administrator privileges.\n\nPlease run this application as Administrator.", "Admin Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    // Try to restart as admin
                    RestartAsAdministrator();
                    Application.Exit();
                    return;
                }

                // Enable .NET Framework 3.5
                MessageBox.Show("Starting .NET Framework 3.5 installation...\n\nThis may take a few minutes.", "Installing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "powershell.exe";
                psi.Arguments = "-NoProfile -ExecutionPolicy Bypass -Command \"Enable-WindowsOptionalFeature -Online -FeatureName NetFx3 -All -NoRestart\"";
                psi.UseShellExecute = true;
                psi.Verb = "runas";
                psi.CreateNoWindow = false;
                
                Process process = Process.Start(psi);
                process.WaitForExit();
                
                // Check if installation was successful
                System.Threading.Thread.Sleep(2000);
                
                if (IsDotNet35Installed())
                {
                    MessageBox.Show("✓ .NET Framework 3.5 has been enabled successfully!\n\nRestarting application...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Restart application
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Installation may require a system restart.\n\nPlease restart your computer and run this application again.", "Restart Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enabling .NET Framework 3.5:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RestartAsAdministrator()
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";
                Process.Start(processInfo);
            }
            catch
            {
                // Already elevated or UAC disabled
            }
        }

            }
        }
