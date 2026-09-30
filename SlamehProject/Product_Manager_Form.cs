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
using SlamehProject.Properties;

namespace SlamehProject
{
    public partial class Product_Manager_Form : Form
    {

        public static Product_Manager_Form pmf_pointer;

        eStoreDBEntities _context = new eStoreDBEntities();
        private void load_category()
        {
            foreach (category item in _context.categories)
            {
                categories_comboBox.Items.Add(item.Name);
            }
        }
        private void show_products()
        {
            foreach (product p in _context.products)
            {
                Product_Control pctrl = new Product_Control();
                pctrl.Product_ID = p.Product_ID;
                if (File.Exists(p.Image))
                    pctrl.pictureBox.BackgroundImage = Image.FromFile(@p.Image);
                pctrl.name_label.Text = p.Name;
                pctrl.number_label.Text = p.Price + "$";

                flowLayoutPanel1.Invoke(new Action(() => flowLayoutPanel1.Controls.Add(pctrl)));
            }
        }
        private void show_products_only_cat(int category_id)
        {
            add_plus_icon();
            if (category_id == 0)
                foreach (product p in _context.products)
                {
                    Product_Control pctrl = new Product_Control();
                    pctrl.Product_ID = p.Product_ID;
                    if (File.Exists(p.Image))
                        pctrl.pictureBox.BackgroundImage = Image.FromFile(@p.Image);
                    pctrl.name_label.Text = p.Name;
                    pctrl.number_label.Text = p.Price + "$";

                    flowLayoutPanel1.Invoke(new Action(() => flowLayoutPanel1.Controls.Add(pctrl)));
                }
            else
                foreach (product p in _context.products.Where(x => x.Category_ID == category_id))
                {
                    Product_Control pctrl = new Product_Control();
                    pctrl.Product_ID = p.Product_ID;
                    if (File.Exists(p.Image))
                        pctrl.pictureBox.BackgroundImage = Image.FromFile(@p.Image);
                    pctrl.name_label.Text = p.Name;
                    pctrl.number_label.Text = p.Price + "$";

                    flowLayoutPanel1.Invoke(new Action(() => flowLayoutPanel1.Controls.Add(pctrl)));
                }
        }
        private void show_products(int category_id,string product_name)
        {
            add_plus_icon();
            if (category_id == 0)
                foreach (product p in _context.products.Where(x => x.Name.Contains(product_name)))
                {
                    Product_Control pctrl = new Product_Control();
                    pctrl.Product_ID = p.Product_ID;
                    if (File.Exists(p.Image))
                        pctrl.pictureBox.BackgroundImage = Image.FromFile(@p.Image);
                    pctrl.name_label.Text = p.Name;
                    pctrl.number_label.Text = p.Price + "$";

                    flowLayoutPanel1.Invoke(new Action(() => flowLayoutPanel1.Controls.Add(pctrl)));
                }
            else
                foreach (product p in _context.products.Where(x => x.Name.Contains(product_name) && x.Category_ID == category_id))
                {
                    Product_Control pctrl = new Product_Control();
                    pctrl.Product_ID = p.Product_ID;
                    if (File.Exists(p.Image))
                        pctrl.pictureBox.BackgroundImage = Image.FromFile(@p.Image);
                    pctrl.name_label.Text = p.Name;
                    pctrl.number_label.Text = p.Price + "$";

                    flowLayoutPanel1.Invoke(new Action(() => flowLayoutPanel1.Controls.Add(pctrl)));
                }

        }

        private void add_plus_icon()
        {
            #region add plus icon
            var pro = new Product_Control();
            pro.pictureBox.BackgroundImage = Resources.icons8_add_new_96px;
            pro.name_label.Text = "ADD NEW";
            pro.number_label.Text = "";
            pro.Product_ID = 0;
            //pro.Click += (send, ev) => PSP();
            //flowLayoutPanel1.Controls.Add(pro);
            flowLayoutPanel1.Invoke(new Action(() => flowLayoutPanel1.Controls.Add(pro)));
            #endregion
        }
        public Product_Manager_Form()
        {
            InitializeComponent();
            pmf_pointer = this;
        }

        private void Product_Manager_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Product_Manager_Form_Load(object sender, EventArgs e)
        {
            add_plus_icon();
            load_category();
            Task.Run(show_products);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cat = categories_comboBox.Text;
            int cat_id = 0;
            if (categories_comboBox.Text != "ALL")
                cat_id = _context.categories.Where(a => a.Name == cat).FirstOrDefault().Category_ID;
            flowLayoutPanel1.Controls.Clear();
            Task.Run(() => show_products(cat_id, textBox1.Text));
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            Methods.Open("Home");
        }
  
        private void categories_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat = categories_comboBox.Text;
            int cat_id = 0;
            if (categories_comboBox.Text != "ALL")
                cat_id = _context.categories.Where(a => a.Name == cat).FirstOrDefault().Category_ID;
            flowLayoutPanel1.Controls.Clear();
            Task.Run(() => show_products_only_cat(cat_id));
        }
    }
}