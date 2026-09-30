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
    public partial class Cobon_cotrole : UserControl
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int Percent { get; set; }
        public string Item { get; set; }
        public string Status { get; set; }
        public DateTime Date_start { get; set;}

        public DateTime Date_End { get; set; }
        public Cobon_cotrole(string t, string i, string st, int p, DateTime s, DateTime e)
        {
            InitializeComponent();
            Itemlbl.Text = i;
            Precentlbl.Text = p + "%";
            Statuslbl.Text = st;
            Titlelbl.Text = t;
            Start_datebar.Value = s;
            End_datebar.Value = e;
            Title = t;
            Percent = p;
            Item = i;
            Status = st;
            Date_start = s;
            Date_End = e;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            ManageCobones.Delete(Id);
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            Methods.cobone.Cobone_ID = Id;
            Methods.cobone.active_date = Date_start;
            Methods.cobone.cobone_number = Title;
            Methods.cobone.end_date = Date_End;
            Methods.cobone.percent = Percent;
            Methods.cobone.Products = Item;
            Methods.cobone.status = Status;
            Application.Exit();
            Methods.Open("Edit Cobone");
        }
    }
    
}
