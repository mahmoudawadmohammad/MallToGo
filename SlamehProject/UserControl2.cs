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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }
        #region proplist
        private string name;
        private double prise;
        private int amont;
   
        [Category("customprop")]
        public string Name
        {
            get { return name; }
            set { name = value; nameLabel.Text = value; }
        }
        [Category("customprop")]
        public double Prise
        {
            get { return prise; }
            set { prise = value;  }
        }
        [Category("customprop")]
        public int Amont
        {
            get { return amont; }
            set { amont = value; amontLabel.Text = value.ToString(); }
        }


        #endregion

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            SellPoint.remove_the_item(name, prise);
        }
    }
}
