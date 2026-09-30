using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlamehProject
{
    public partial class Product_Control : UserControl
    {
        public void OpenProductForm() => Application.Run(new Product_Form(0));

        private void PSP()
        {
            Product_Manager_Form.pmf_pointer.Close();
            Methods.th = new Thread(OpenProductForm);
            Methods.th.SetApartmentState(ApartmentState.STA);
            Methods.th.Start();
        }

        public Product_Control()
        {
            InitializeComponent();
        }

        private void Product_Control_Click(object sender, EventArgs e)
        {

            Product_Form pf = new Product_Form(Product_ID);
            //if (Product_Manager_Form.pmf_pointer is null) MessageBox.Show("Error , please close the application and open it again","ERROR",MessageBoxButtons.OK);
            Product_Manager_Form.pmf_pointer.Hide();
            pf.Show();
            //PSP();
        }

    }
}
