using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlamehProject
{
    public partial class items : UserControl
    {
        public items()
        {
            InitializeComponent();
        }

        private void items_Load(object sender, EventArgs e)
        {
        
        }
          #region proplist
          private string tage;
          private int id;
          private Image img;
          [Category("customprop")]
          public string Tage
          {
            get { return tage; }
            set { tage = value; titel.Text = value; }
          }

        [Category("customprop")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [Category("customprop")]
        public Image Img
        {
            get { return img; }
            set { img = value; PictureBox.Image = value; }
        }

        #endregion

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Add_Cobone.got_selected(Tage);
        }
    }
}
