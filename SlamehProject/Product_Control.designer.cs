
namespace SlamehProject
{
    partial class Product_Control
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
            this.number_label = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.name_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // number_label
            // 
            this.number_label.BackColor = System.Drawing.Color.Transparent;
            this.number_label.Font = new System.Drawing.Font("Tahoma", 12F);
            this.number_label.Location = new System.Drawing.Point(3, 177);
            this.number_label.Name = "number_label";
            this.number_label.Size = new System.Drawing.Size(185, 23);
            this.number_label.TabIndex = 2;
            this.number_label.Text = "0";
            this.number_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.number_label.Click += new System.EventHandler(this.Product_Control_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.Location = new System.Drawing.Point(3, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(185, 145);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.Product_Control_Click);
            // 
            // name_label
            // 
            this.name_label.BackColor = System.Drawing.Color.Transparent;
            this.name_label.Font = new System.Drawing.Font("Tahoma", 14F);
            this.name_label.Location = new System.Drawing.Point(3, 152);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(185, 23);
            this.name_label.TabIndex = 4;
            this.name_label.Text = "Melon";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.name_label.Click += new System.EventHandler(this.Product_Control_Click);
            // 
            // Product_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.number_label);
            this.Controls.Add(this.name_label);
            this.Name = "Product_Control";
            this.Size = new System.Drawing.Size(190, 200);
            this.Click += new System.EventHandler(this.Product_Control_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label number_label;
        public System.Windows.Forms.PictureBox pictureBox;
        public System.Windows.Forms.Label name_label;
        public int Product_ID;

    }
}
