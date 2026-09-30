using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SlamehProject
{
    public partial class Product_Form : Form
    {
        public void OpenProductForm() => Application.Run(new Product_Manager_Form());

        private void PSP()
        {
            this.Close();
            Methods.th = new Thread(OpenProductForm);
            Methods.th.SetApartmentState(ApartmentState.STA);
            Methods.th.Start();
        }

        eStoreDBEntities _context = new eStoreDBEntities();

        int ID =0;
        private void load_category()
        {
            foreach (var item in _context.categories)
            {
                comboBox1.Items.Add(item.Name);
            }
        }

        public Product_Form(int id)
        {
            ID = id;
            InitializeComponent();

            load_category();
            if (id == 0) { delete_btn.Enabled = false; return; }
            product p = _context.products.Find(id);
            //product p = _context.products.Where(x=>x.Product_ID==id).FirstOrDefault();
            if (File.Exists(@p.Image))
            {
                product_picture.BackgroundImage = Image.FromFile(@p.Image);
                imagesorce_txtbox.Text = p.Image;
            }
            name_textBox.Text = p.Name;
            //comboBox1.Items.Add= p.Category_ID
            quantity_numericUD.Value = Convert.ToDecimal(p.Quantity);
            price_textBox.Text = p.Price;
            category c = _context.categories.Find(p.Category_ID);
            comboBox1.SelectedItem = c.Name;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            product_picture.BackgroundImage = null;
            imagesorce_txtbox.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                product p = new product();
                p.Name = name_textBox.Text;
                p.Category_ID = _context.categories.Where(x => x.Name == comboBox1.Text).FirstOrDefault().Category_ID;
                p.Image = imagesorce_txtbox.Text;
                p.Quantity = int.Parse(quantity_numericUD.Value.ToString());
                p.Price = price_textBox.Text;

                _context.products.Add(p);
                _context.SaveChanges();
                MessageBox.Show(string.Format("saved  " + p.Name));
            }
            else
            {
                product p = _context.products.Find(ID);
                p.Name = name_textBox.Text;
                //p.Category_ID = int.Parse(comboBox1.SelectedItem.ToString());
                p.Category_ID = _context.categories.Where(x => x.Name == comboBox1.SelectedItem.ToString()).FirstOrDefault().Category_ID;
                p.Image = imagesorce_txtbox.Text;
                p.Quantity = int.Parse(quantity_numericUD.Value.ToString());
                p.Price = price_textBox.Text;
                _context.SaveChanges();
                MessageBox.Show(string.Format("saved  " + p.Name));

            }
        }

        private void Product_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Application.Exit();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            PSP();
        }

        private void addPhoto_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagesorce_txtbox.Text = openFileDialog1.FileName;
                product_picture.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            _context.products.Remove(_context.products.Find(ID));
            _context.SaveChanges();
            back_btn_Click(sender, e);

        }
    }
}
