namespace frmdnschange
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSetDns = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCheckCloudflare = new System.Windows.Forms.Button();
            this.btnCheckAdGuard = new System.Windows.Forms.Button();
            this.btnCheckDisableIPv6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetDns
            // 
            this.btnSetDns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSetDns.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSetDns.ForeColor = System.Drawing.Color.White;
            this.btnSetDns.Location = new System.Drawing.Point(12, 50);
            this.btnSetDns.Name = "btnSetDns";
            this.btnSetDns.Size = new System.Drawing.Size(75, 40);
            this.btnSetDns.TabIndex = 1;
            this.btnSetDns.Text = "Enable\r\nAd Blocker";
            this.btnSetDns.UseVisualStyleBackColor = false;
            this.btnSetDns.Click += new System.EventHandler(this.btnSetDns_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtStatus.Location = new System.Drawing.Point(12, 100);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(324, 150);
            this.txtStatus.TabIndex = 5;
            this.txtStatus.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(324, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Surf Without Ads Tool";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCheckCloudflare
            // 
            this.btnCheckCloudflare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCheckCloudflare.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnCheckCloudflare.ForeColor = System.Drawing.Color.White;
            this.btnCheckCloudflare.Location = new System.Drawing.Point(95, 50);
            this.btnCheckCloudflare.Name = "btnCheckCloudflare";
            this.btnCheckCloudflare.Size = new System.Drawing.Size(75, 40);
            this.btnCheckCloudflare.TabIndex = 2;
            this.btnCheckCloudflare.Text = "Check\r\nCloudflare";
            this.btnCheckCloudflare.UseVisualStyleBackColor = false;
            this.btnCheckCloudflare.Click += new System.EventHandler(this.btnCheckCloudflare_Click);
            // 
            // btnCheckAdGuard
            // 
            this.btnCheckAdGuard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCheckAdGuard.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnCheckAdGuard.ForeColor = System.Drawing.Color.White;
            this.btnCheckAdGuard.Location = new System.Drawing.Point(178, 50);
            this.btnCheckAdGuard.Name = "btnCheckAdGuard";
            this.btnCheckAdGuard.Size = new System.Drawing.Size(75, 40);
            this.btnCheckAdGuard.TabIndex = 4;
            this.btnCheckAdGuard.Text = "Check\r\nAdGuard";
            this.btnCheckAdGuard.UseVisualStyleBackColor = false;
            this.btnCheckAdGuard.Click += new System.EventHandler(this.btnCheckAdGuard_Click);
            // 
            // btnCheckDisableIPv6
            // 
            this.btnCheckDisableIPv6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCheckDisableIPv6.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnCheckDisableIPv6.ForeColor = System.Drawing.Color.White;
            this.btnCheckDisableIPv6.Location = new System.Drawing.Point(261, 50);
            this.btnCheckDisableIPv6.Name = "btnCheckDisableIPv6";
            this.btnCheckDisableIPv6.Size = new System.Drawing.Size(75, 40);
            this.btnCheckDisableIPv6.TabIndex = 3;
            this.btnCheckDisableIPv6.Text = "Disable\r\nIPv6";
            this.btnCheckDisableIPv6.UseVisualStyleBackColor = false;
            this.btnCheckDisableIPv6.Click += new System.EventHandler(this.btnCheckDisableIPv6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(348, 262);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnCheckDisableIPv6);
            this.Controls.Add(this.btnCheckAdGuard);
            this.Controls.Add(this.btnCheckCloudflare);
            this.Controls.Add(this.btnSetDns);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Surf Without Ads Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetDns;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCheckCloudflare;
        private System.Windows.Forms.Button btnCheckAdGuard;
        private System.Windows.Forms.Button btnCheckDisableIPv6;
    }
}

