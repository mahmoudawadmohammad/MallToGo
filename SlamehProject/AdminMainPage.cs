using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using SlamehProject.Properties;

namespace SlamehProject
{
    public partial class AdminMainPage : Form
    {
        eStoreDBEntities _context = new eStoreDBEntities();
        public AdminMainPage()
        {
            InitializeComponent();
        }
        private void ScrollDownbtn_Click(object sender, EventArgs e)
        {
            if (ScrollDownBar.Visible)
                ScrollDownBar.Hide();
            else
                ScrollDownBar.Show();
        }
        private void ScrollDown_Up_Click(object sender, EventArgs e)
        {
            ScrollDownBar.Hide();
        }
        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Methods.Open("Login");
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            BunifuButton btn = (BunifuButton)sender;
            switch(btn.Name)
            {
                case "Productsbtn":
                    this.Close();
                    Methods.Open("Products");
                    break;
                case "Categoriesbtn":
                    this.Close();
                    Methods.Open("Categories");
                    break;
                case "Usersbtn":
                    this.Close();
                    Methods.Open("Users");
                    break;
                case "Cobonesbtn":
                    this.Close();
                    Methods.Open("Cobones");
                    break;
            }
        }

        private void AdminMainPage_Load(object sender, EventArgs e)
        {
            user current = _context.users.Find(Methods.Currentid);
            if (current.photo == null)
                Account_Image.Image = AccountImage.Image = Resources._3d_fluency_businessman_icon;
            else if(!current.photo.Contains("Resources._3d_fluency_businessman_icon"))
                Account_Image.Image = AccountImage.Image = Image.FromFile(current.photo);
            AccountName.Text = current.First_Name + " " + current.Last_Name;
            #region totales
            var v = _context.users.Count();
            Total_Users.Text = v.ToString();
            v = _context.products.Count();
            double pcount = Convert.ToDouble(v);
            if (pcount > 10000 && pcount < 1000000)
                Total_Products.Text = (pcount / 1000) + "K";
            if (pcount > 1000000 && pcount < 1000000000)
                Total_Products.Text = (pcount / 1000000) + "M";
            else
                Total_Products.Text = pcount.ToString();
            double totalSales = 0;
            foreach(order o in _context.orders)
            {
                product price = _context.products.FirstOrDefault(p => p.Product_ID == o.Product_ID);
                totalSales += o.Sold_Quantity * Convert.ToDouble(price.Price);
            }
            Total_Sales.Text = totalSales.ToString();
            #endregion
            #region Best Three
            Dictionary<int, double> Pids = new Dictionary<int, double>();
            foreach (order o in _context.orders)
            {
                foreach (order order in _context.orders)
                {
                    Pids[o.Product_ID] = Convert.ToDouble(_context.orders.Where(p => p.Product_ID == o.Product_ID)
                        .Sum(p => p.Sold_Quantity));
                }
            }
            foreach (var Pa in Pids)
            {
                int count = 0;
                foreach (var Child in Pids)
                {
                    if (Pa.Value < Child.Value)
                        count++;
                }
                if (count == 0)
                {
                    product product = _context.products.Find(Pa.Key);
                    Iphoto1.Image = String.IsNullOrWhiteSpace(product.Image)? null : Image.FromFile(product.Image);
                    Iname1.Text = product.Name;
                    Iprice1.Text = product.Price;
                    Isold1.Text = Pa.Value.ToString();
                    double total = Pa.Value * Convert.ToDouble(product.Price);
                    if (total > 10000 && total < 1000000)
                        Itotal1.Text = (total / 1000) + "K";
                    if (total > 1000000)
                        Itotal1.Text = (total / 1000000) + "M";
                    else
                        Itotal1.Text = total.ToString();
                }
                if (count == 1)
                {
                    product product = _context.products.Find(Pa.Key);
                    Iphoto2.Image = String.IsNullOrWhiteSpace(product.Image) ? null : Image.FromFile(product.Image);
                    Iname2.Text = product.Name;
                    Iprice2.Text = product.Price;
                    Isold2.Text = Pa.Value.ToString();
                    double total = Pa.Value * Convert.ToDouble(product.Price);
                    if (total > 10000 && total < 1000000)
                        Itotal2.Text = (total / 1000) + "K";
                    if (total > 1000000)
                        Itotal2.Text = (total / 1000000) + "M";
                    else
                        Itotal2.Text = total.ToString();
                }
                if (count == 2)
                {
                    product product = _context.products.Find(Pa.Key);
                    Iphoto3.Image = String.IsNullOrWhiteSpace(product.Image) ? null : Image.FromFile(product.Image);
                    Iname3.Text = product.Name;
                    Iprice3.Text = product.Price;
                    Isold3.Text = Pa.Value.ToString();
                    double total = Pa.Value * Convert.ToDouble(product.Price);
                    if (total > 10000 && total < 1000000)
                        Itotal3.Text = (total / 1000) + "K";
                    if (total > 1000000)
                        Itotal3.Text = (total / 1000000) + "M";
                    else
                        Itotal3.Text = total.ToString();
                }
            }
            #endregion
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Close();
            Methods.Open("Edit Profile");
        }
    }
}
