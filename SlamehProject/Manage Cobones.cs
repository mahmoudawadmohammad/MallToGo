using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace SlamehProject
{
    public partial class ManageCobones : Form
    {
        static eStoreDBEntities _context;
        public ManageCobones()
        {
            InitializeComponent();
            Full_producr();
        }
        private static void Full_producr()
        {
            // List<int> list = new List<int>();
            _context = new eStoreDBEntities();
            int all = 0;
            foreach (Cobone cobone in _context.Cobones)
            {
                Cobon_cotrole cobon_Cotrole = new Cobon_cotrole(cobone.cobone_number,
                    cobone.Products,
                    cobone.status,
                    cobone.percent,
                    cobone.active_date,
                    cobone.end_date)
                {
                    Id = cobone.Cobone_ID,
                };
                CobonesPanel.Controls.Add(cobon_Cotrole);
                BunifuSeparator sp = new BunifuSeparator { Width = CobonesPanel.Width / 2 };
                sp.Margin = new Padding(CobonesPanel.Width / 4, 0, 0, 0);
                CobonesPanel.Controls.Add(sp);
                all++;
            }
            AllCobones.Text = "All Cobones: " + all.ToString();
            //for (int i = 0; i < 10; i++)
            //{
            //    Cobon_cotrole cobon_Cotrole = new Cobon_cotrole();
            //    cobon_Cotrole.Id= 1;
            //    cobon_Cotrole.Name = " ";
            //    cobon_Cotrole.Present1 = 1;
            //    //cobon_Cotrole.Date_start;
            //    //cobon_Cotrole.Date_End ;
            //    CobonesPanel.Controls.Add(cobon_Cotrole);
            //    BunifuSeparator sp = new BunifuSeparator { Width = CobonesPanel.Width /2};
            //    sp.Margin = new Padding(CobonesPanel.Width / 4,0,0,0);
            //    CobonesPanel.Controls.Add(sp);
            //}
        }
        internal static void Delete(int id)
        {
            Cobone cobone = _context.Cobones.Find(id);
            _context.Cobones.Remove(cobone);
            _context.SaveChanges();
            CobonesPanel.Controls.Clear();
            Full_producr();
        }

        private void TopBar_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if(c.Name == "Backbtn")
            {
                this.Close();
                Methods.Open("Home");
            }
            else
            {
                this.Close();
                Methods.Open("Add Cobone");
            }
        }
    }
}
