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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        #region proplist
        private string tage;
        private int id;
        private double prise;
        private int amont;
        private Image iTEM_Image;
         [Category("customprop")]
        public string Tage
        {
            get { return tage; }
            set { tage = value;TITEL.Text = value; }
        }
        [Category("customprop")]
        public double PRISE
        {
            get { return prise; }
            set { prise = value; PRA.Text = value.ToString() + "$"; }
        }
        [Category("customprop")]
        public int Id
        {
            get { return id; }
            set { id = value;  }
        }
        [Category("customprop")]
        public int Amont
        {
            get { return amont; }
            set { amont = value; AMONT_LAB.Text = value.ToString(); }
        }
        [Category("customprop")]
        public Image Img
        {
            get { return iTEM_Image; }
            set { iTEM_Image = value; PIC.Image= value; }
        }

        #endregion
        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            SellPoint.aadd_to_end_list(tage, prise,id);
        }
    }
}
