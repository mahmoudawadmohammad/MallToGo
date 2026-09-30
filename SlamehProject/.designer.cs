namespace SlamehProject
{
    partial class ManageCobones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCobones));
            this.panel1 = new System.Windows.Forms.Panel();
            AllCobones = new System.Windows.Forms.Label();
            this.Backbtn = new System.Windows.Forms.PictureBox();
            this.AddCobonebtn = new Bunifu.Framework.UI.BunifuThinButton2();
            CobonesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bunifuVScrollBar2 = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Backbtn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(AllCobones);
            this.panel1.Controls.Add(this.Backbtn);
            this.panel1.Controls.Add(this.AddCobonebtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 56);
            this.panel1.TabIndex = 3;
            // 
            // AllCobones
            // 
            AllCobones.AutoSize = true;
            AllCobones.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AllCobones.Location = new System.Drawing.Point(299, 17);
            AllCobones.Name = "AllCobones";
            AllCobones.Size = new System.Drawing.Size(124, 25);
            AllCobones.TabIndex = 4;
            AllCobones.Text = "All Cobones: ";
            // 
            // Backbtn
            // 
            this.Backbtn.Image = global::SlamehProject.Properties.Resources.icons8_go_back_48px;
            this.Backbtn.Location = new System.Drawing.Point(12, 12);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(30, 30);
            this.Backbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Backbtn.TabIndex = 3;
            this.Backbtn.TabStop = false;
            this.Backbtn.Click += new System.EventHandler(this.TopBar_Click);
            // 
            // AddCobonebtn
            // 
            this.AddCobonebtn.ActiveBorderThickness = 1;
            this.AddCobonebtn.ActiveCornerRadius = 20;
            this.AddCobonebtn.ActiveFillColor = System.Drawing.Color.DeepSkyBlue;
            this.AddCobonebtn.ActiveForecolor = System.Drawing.Color.White;
            this.AddCobonebtn.ActiveLineColor = System.Drawing.Color.DeepSkyBlue;
            this.AddCobonebtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.AddCobonebtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddCobonebtn.BackgroundImage")));
            this.AddCobonebtn.ButtonText = "Add";
            this.AddCobonebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddCobonebtn.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCobonebtn.ForeColor = System.Drawing.Color.RoyalBlue;
            this.AddCobonebtn.IdleBorderThickness = 1;
            this.AddCobonebtn.IdleCornerRadius = 20;
            this.AddCobonebtn.IdleFillColor = System.Drawing.Color.White;
            this.AddCobonebtn.IdleForecolor = System.Drawing.Color.RoyalBlue;
            this.AddCobonebtn.IdleLineColor = System.Drawing.Color.RoyalBlue;
            this.AddCobonebtn.Location = new System.Drawing.Point(678, 6);
            this.AddCobonebtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.AddCobonebtn.Name = "AddCobonebtn";
            this.AddCobonebtn.Size = new System.Drawing.Size(108, 46);
            this.AddCobonebtn.TabIndex = 0;
            this.AddCobonebtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddCobonebtn.Click += new System.EventHandler(this.TopBar_Click);
            // 
            // CobonesPanel
            // 
            CobonesPanel.Location = new System.Drawing.Point(0, 56);
            CobonesPanel.Margin = new System.Windows.Forms.Padding(1);
            CobonesPanel.Name = "CobonesPanel";
            CobonesPanel.Size = new System.Drawing.Size(785, 394);
            CobonesPanel.TabIndex = 4;
            // 
            // bunifuVScrollBar2
            // 
            this.bunifuVScrollBar2.AllowCursorChanges = true;
            this.bunifuVScrollBar2.AllowHomeEndKeysDetection = false;
            this.bunifuVScrollBar2.AllowIncrementalClickMoves = true;
            this.bunifuVScrollBar2.AllowMouseDownEffects = true;
            this.bunifuVScrollBar2.AllowMouseHoverEffects = true;
            this.bunifuVScrollBar2.AllowScrollingAnimations = true;
            this.bunifuVScrollBar2.AllowScrollKeysDetection = true;
            this.bunifuVScrollBar2.AllowScrollOptionsMenu = true;
            this.bunifuVScrollBar2.AllowShrinkingOnFocusLost = false;
            this.bunifuVScrollBar2.BackgroundColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuVScrollBar2.BackgroundImage")));
            this.bunifuVScrollBar2.BindingContainer = CobonesPanel;
            this.bunifuVScrollBar2.BorderColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar2.BorderRadius = 14;
            this.bunifuVScrollBar2.BorderThickness = 1;
            this.bunifuVScrollBar2.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuVScrollBar2.DurationBeforeShrink = 2000;
            this.bunifuVScrollBar2.LargeChange = 10;
            this.bunifuVScrollBar2.Location = new System.Drawing.Point(787, 56);
            this.bunifuVScrollBar2.Margin = new System.Windows.Forms.Padding(1);
            this.bunifuVScrollBar2.Maximum = 100;
            this.bunifuVScrollBar2.Minimum = 0;
            this.bunifuVScrollBar2.MinimumThumbLength = 18;
            this.bunifuVScrollBar2.Name = "bunifuVScrollBar2";
            this.bunifuVScrollBar2.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar2.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.bunifuVScrollBar2.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar2.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar2.ScrollBarColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar2.ShrinkSizeLimit = 3;
            this.bunifuVScrollBar2.Size = new System.Drawing.Size(13, 394);
            this.bunifuVScrollBar2.SmallChange = 1;
            this.bunifuVScrollBar2.TabIndex = 5;
            this.bunifuVScrollBar2.ThumbColor = System.Drawing.Color.Gray;
            this.bunifuVScrollBar2.ThumbLength = 38;
            this.bunifuVScrollBar2.ThumbMargin = 1;
            this.bunifuVScrollBar2.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.bunifuVScrollBar2.Value = 0;
            // 
            // ManageCobones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bunifuVScrollBar2);
            this.Controls.Add(CobonesPanel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ManageCobones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Cobones";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Backbtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuThinButton2 AddCobonebtn;
        private System.Windows.Forms.Panel panel1;
        private static System.Windows.Forms.FlowLayoutPanel CobonesPanel;
        private static System.Windows.Forms.Label AllCobones;
        private Bunifu.UI.WinForms.BunifuVScrollBar bunifuVScrollBar2;
        private System.Windows.Forms.PictureBox Backbtn;
    }
}

