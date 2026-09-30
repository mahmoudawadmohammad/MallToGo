using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuButton;

namespace SlamehProject
{
    public partial class _Users : Form
    {
        eStoreDBEntities _context = new eStoreDBEntities();
        public _Users()
        {
            InitializeComponent();
        }
        private void _Users_Load(object sender, EventArgs e)
        {
            GView_Users.Rows.Clear();
            foreach (user user in _context.users)
            {
                Image img;
                if (user.photo == null)
                    img = SlamehProject.Properties.Resources._3d_fluency_businessman_icon;
                else
                    img = System.Drawing.Image.FromFile(user.photo);
                GView_Users.Rows.Add(user.Users_ID, img, user.First_Name + " " + user.Last_Name, user.Role);
            }
        }

        private void GView_Users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GView_Users.Rows[e.RowIndex].Cells[0].Value.ToString() != "1")
            {
                if (GView_Users.Columns[e.ColumnIndex].Name == "Delete")
                {
                    if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = (int)GView_Users.Rows[e.RowIndex].Cells[0].Value;
                        user user = _context.users.SingleOrDefault(us => us.Users_ID == id);
                        _context.users.Remove(user);
                        _context.SaveChanges();
                        GView_Users.Rows.RemoveAt(e.RowIndex);
                        _Users_Load(sender, e);
                    }
                }
                else if (GView_Users.Columns[e.ColumnIndex].Name == "Edit")
                {
                    Methods.Userid = (int)GView_Users.Rows[e.RowIndex].Cells[0].Value;
                    this.Close();
                    Methods.Open("Edit Account");
                }
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            BunifuButton btn = (BunifuButton)sender;
            if (btn.Name == "Homebtn")
            {
                this.Close();
                Methods.Open("Home");
            }
            else
            {
                this.Close();
                Methods.Open("Add Account");
            }
        }
    }
}
