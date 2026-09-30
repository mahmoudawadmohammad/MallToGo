using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlamehProject
{
    public partial class Login : Form
    {
        eStoreDBEntities _context = new eStoreDBEntities();
        public Login()
        {
            InitializeComponent();
        }
        public void OpenAdminMainPage() => Application.Run(new AdminMainPage());
        public void OpenSellPoint() => Application.Run(new SellPoint());
        private void Validating_Login(object sender, CancelEventArgs e)
        {
            Bunifu.UI.WinForms.BunifuTextBox txt = (Bunifu.UI.WinForms.BunifuTextBox)sender;
            switch (txt.Name)
            {
                case "Emailtxt":
                    if (String.IsNullOrEmpty(Emailtxt.Text))
                    {
                        errorProvider.SetError(Emailtxt, "The Email Can't Be Empty");
                        Emailtxt.Focus();
                    }
                    else
                    {
                        if (Regex.IsMatch(Emailtxt.Text, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
                            errorProvider.Clear();
                        else
                        {
                            errorProvider.SetError(Emailtxt, "The Email Is Invalid");
                            Emailtxt.Focus();
                        }
                    }
                    break;
                case "Passwordtxt":
                    if (String.IsNullOrEmpty(Passwordtxt.Text))
                    {
                        errorProvider.SetError(Passwordtxt, "The Password Can't Be Empty");
                        Passwordtxt.Focus();
                    }
                    else
                        errorProvider.Clear();
                    break;
            }
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            if (!Role.Checked)
            {
                //admin
                string em = Emailtxt.Text;
                string pas = Methods.EncodePasswordToBase64(Passwordtxt.Text);
                user u = _context.users.Where(x => x.Email == em && x.Password == pas).FirstOrDefault();
                if (u != null)
                {
                    Methods.Currentid = u.Users_ID;
                    if (_context.users.Find(u.Users_ID).Role.ToLower() == "admin")
                    {
                        this.Close();
                        Methods.Open("Home");

                    }
                    else
                        MessageBox.Show("you are seller");

                }
                else
                    MessageBox.Show("error");
                

            }
            else
            {
                string em = Emailtxt.Text;
                string pas = Methods.EncodePasswordToBase64(Passwordtxt.Text);
                user u = _context.users.Where(x => x.Email == em && x.Password == pas).FirstOrDefault();
                if (u != null)
                {
                    Methods.Currentid = u.Users_ID;
                    if (_context.users.Find(u.Users_ID).Role.ToLower() == "seller")
                    {
                        this.Close();
                        Methods.Open("Sell Point");

                    }
                    else
                        MessageBox.Show("you are admin");

                }
                else
                    MessageBox.Show("error");
                

            }
        }

        private void ShowPassword_Click(object sender, EventArgs e) => Methods.ShowPassword(Passwordtxt);
    }
}
