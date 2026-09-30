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
    public partial class Add_Cobone : Form
    {
        eStoreDBEntities _context = new eStoreDBEntities();
        List<finalListItem> pro = new List<finalListItem>();
        static Cobone cobone = new Cobone() { status = "Not Used" };
        string randomCode = Methods.RandomString(); 
        public static int s_id;
        public static string Item;
        //public int id;
        //public string item;
        //public string code;
        //public int dic_per;
        //public DateTime sdate;
        //public DateTime edate;
        //public string Status;
        char _mode;
        public Add_Cobone(char mode = 'a')
        {
            _mode = mode;
            InitializeComponent();
            interacte();
            if(mode != 'a')
            {
                cobone = _context.Cobones.Find(Methods.cobone.Cobone_ID);
                chosed_item.Text = Methods.cobone.Products;
                sDatePicker.Value = Methods.cobone.active_date;
                eDatePicker.Value = Methods.cobone.end_date;
                CobonName.Text = Methods.cobone.cobone_number;
                Slider.Value = Methods.cobone.percent;
                RadialGauge.Value = Methods.cobone.percent;
            }
        }
        private void interacte() 
        {
            finalListItem er = new finalListItem();
            er.Name = "all";
            pro.Add(er);
            foreach (product p in _context.products)
            {
                er = new finalListItem();
                er.Name = p.Name;
                er.Prise = double.Parse(p.Price);
                pro.Add(er);
            }
            items[] temlst = new items[pro.Count];
            for (int i = 0; i < pro.Count; i++)
            {
                temlst[i] = new items();
                temlst[i].Tage = pro[i].Name;
                temlst[i].Id = pro[i].Id;
                //  temlst[i].Img = pro[i].Img;
                flowLayoutPanel1.Controls.Add(temlst[i]);
            }
            sDatePicker.Value = DateTime.Today;
            eDatePicker.Value = DateTime.Today.AddDays(1);
            CobonName.Text = randomCode;
        }

        internal static void got_selected(string tag)
        {
            cobone.Products = tag;
            chosed_item.Text = tag;
        }

        private void sDatePicker_ValueChanged(object sender, EventArgs e)
        {
            cobone.active_date = sDatePicker.Value;
        }

        private void eDatePicker_ValueChanged(object sender, EventArgs e)
        {
            cobone.end_date = eDatePicker.Value;
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            cobone.cobone_number = CobonName.Text;
        }

        private void bunifuHSlider1_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            RadialGauge.Value = Slider.Value;
            cobone.percent = Slider.Value;
        }

        private void Donebtn_Click(object sender, EventArgs e)
        {
            if (cobone.active_date <= cobone.end_date && cobone.active_date >= DateTime.Today)
            {
                if (_mode == 'a')
                {
                    var cid = _context.Cobones.ToList();
                    cobone.Cobone_ID = cid.Count;
                    cobone.cobone_number = CobonName.Text;
                    _context.Cobones.Add(cobone);
                    _context.SaveChanges();
                    this.Close();
                    Methods.Open("Cobones");
                }
                else
                {
                    cobone.cobone_number = CobonName.Text;
                    _context.SaveChanges();
                    this.Close();
                    Methods.Open("Cobones");
                }
            }
            else
                MessageBox.Show("The Activation Date must be Today or Later\nAnd The Expair Date must be Equal or Bigger than Activation Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Random_Click(object sender, EventArgs e)
        {
            CobonName.Text = Methods.RandomString();
        }
    }
}
