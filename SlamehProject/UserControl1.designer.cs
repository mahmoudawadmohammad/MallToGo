
namespace SlamehProject
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.TITEL = new Bunifu.UI.WinForms.BunifuLabel();
            this.PRA = new Bunifu.UI.WinForms.BunifuLabel();
            this.PIC = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.AMONT_LAB = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PIC)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.RoyalBlue;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.White;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.RoyalBlue;
            this.bunifuThinButton21.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "add";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.RoyalBlue;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.RoyalBlue;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.RoyalBlue;
            this.bunifuThinButton21.Location = new System.Drawing.Point(386, 14);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(129, 54);
            this.bunifuThinButton21.TabIndex = 4;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // TITEL
            // 
            this.TITEL.AllowParentOverrides = false;
            this.TITEL.AutoEllipsis = false;
            this.TITEL.AutoSize = false;
            this.TITEL.Cursor = System.Windows.Forms.Cursors.Default;
            this.TITEL.CursorType = System.Windows.Forms.Cursors.Default;
            this.TITEL.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TITEL.IsSelectionEnabled = true;
            this.TITEL.Location = new System.Drawing.Point(128, 14);
            this.TITEL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TITEL.Name = "TITEL";
            this.TITEL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TITEL.Size = new System.Drawing.Size(127, 34);
            this.TITEL.TabIndex = 5;
            this.TITEL.Text = "item name";
            this.TITEL.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.TITEL.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // PRA
            // 
            this.PRA.AllowParentOverrides = false;
            this.PRA.AutoEllipsis = false;
            this.PRA.Cursor = System.Windows.Forms.Cursors.Default;
            this.PRA.CursorType = System.Windows.Forms.Cursors.Default;
            this.PRA.Font = new System.Drawing.Font("Showcard Gothic", 18F);
            this.PRA.Location = new System.Drawing.Point(417, 79);
            this.PRA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PRA.Name = "PRA";
            this.PRA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PRA.Size = new System.Drawing.Size(49, 31);
            this.PRA.TabIndex = 3;
            this.PRA.Text = "0.00";
            this.PRA.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.PRA.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.PRA.Click += new System.EventHandler(this.bunifuLabel1_Click);
            // 
            // PIC
            // 
            this.PIC.AllowFocused = false;
            this.PIC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PIC.AutoSizeHeight = true;
            this.PIC.BorderRadius = 48;
            this.PIC.Image = ((System.Drawing.Image)(resources.GetObject("PIC.Image")));
            this.PIC.IsCircle = true;
            this.PIC.Location = new System.Drawing.Point(9, 14);
            this.PIC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PIC.Name = "PIC";
            this.PIC.Size = new System.Drawing.Size(96, 96);
            this.PIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PIC.TabIndex = 2;
            this.PIC.TabStop = false;
            this.PIC.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // AMONT_LAB
            // 
            this.AMONT_LAB.AllowParentOverrides = false;
            this.AMONT_LAB.AutoEllipsis = false;
            this.AMONT_LAB.Cursor = System.Windows.Forms.Cursors.Default;
            this.AMONT_LAB.CursorType = System.Windows.Forms.Cursors.Default;
            this.AMONT_LAB.Font = new System.Drawing.Font("Showcard Gothic", 18F);
            this.AMONT_LAB.Location = new System.Drawing.Point(162, 75);
            this.AMONT_LAB.Margin = new System.Windows.Forms.Padding(2);
            this.AMONT_LAB.Name = "AMONT_LAB";
            this.AMONT_LAB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AMONT_LAB.Size = new System.Drawing.Size(14, 31);
            this.AMONT_LAB.TabIndex = 6;
            this.AMONT_LAB.Text = "0";
            this.AMONT_LAB.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.AMONT_LAB.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AMONT_LAB);
            this.Controls.Add(this.PIC);
            this.Controls.Add(this.TITEL);
            this.Controls.Add(this.bunifuThinButton21);
            this.Controls.Add(this.PRA);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(518, 135);
            ((System.ComponentModel.ISupportInitialize)(this.PIC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private Bunifu.UI.WinForms.BunifuLabel TITEL;
        private Bunifu.UI.WinForms.BunifuLabel PRA;
        private Bunifu.UI.WinForms.BunifuPictureBox PIC;
        private Bunifu.UI.WinForms.BunifuLabel AMONT_LAB;
    }
}
