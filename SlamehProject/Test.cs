using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlamehProject
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            invoice invoice = new invoice() { DateTime = DateTime.Now };
            eStoreDBEntities _context = new eStoreDBEntities();
            invoice i = _context.invoices.Add(invoice);
            _context.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.Image.Save(@"C:\Users\DELL\Desktop\Test.png",ImageFormat.Png);
        }
    }
}
