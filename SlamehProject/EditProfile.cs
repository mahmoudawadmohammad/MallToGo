using SlamehProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlamehProject
{
    public partial class EditProfile : Form
    {
        eStoreDBEntities _context = new eStoreDBEntities();
        user User;
        string imagePath = "SlamehProject.Properties.Resources._3d_fluency_businessman_icon";
        public EditProfile()
        {
            InitializeComponent();
        }

        private void ChangeImage_Click(object sender, EventArgs e)
        {
            try
            {
                imagePath = Methods.ChangeImage();
                Accountimage.Image = Image.FromFile(imagePath);
            }
            catch
            {
                Accountimage.Image = Resources._3d_fluency_businessman_icon;
            }
        }

        private void DeleteImage_Click(object sender, EventArgs e)
        {
            Accountimage.Image = Resources._3d_fluency_businessman_icon;
        }

        private void Input_Validating(object sender, CancelEventArgs e)
        {
            Bunifu.UI.WinForms.BunifuTextBox txt = (Bunifu.UI.WinForms.BunifuTextBox)sender;
            Methods.Validation(ref txt,ref errorProvider);
        }

        private void Phonetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Please Just Enter The Number\nYou Entered : " + e.KeyChar, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            if (btn.Name == "Backbtn")
            {
                if (User.Role == "Seller")
                {
                    this.Close();
                    Methods.Open("Sell Point");
                }
                else
                {
                    this.Close();
                    Methods.Open("Home");
                }
            }
            else
            {
                User.First_Name = FirstNametxt.Text;
                User.Last_Name = LastNametxt.Text;
                User.Email = Emailtxt.Text;
                User.Password = Methods.EncodePasswordToBase64(Passwordtxt.Text);
                User.Phone = Phonetxt.Text;
                User.photo = imagePath;
                _context.SaveChangesAsync();
                if (User.Role.ToLower() == "admin")
                {
                    this.Close();
                    Methods.Open("Home");
                }
                else
                {
                    this.Close();
                    Methods.Open("Sell Point");
                }
            }
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            User = _context.users.Find(Methods.Currentid);
            FirstNametxt.Text = User.First_Name;
            LastNametxt.Text = User.Last_Name;
            Emailtxt.Text = User.Email;
            Passwordtxt.Text = Methods.DecodeFrom64(User.Password);
            Phonetxt.Text = User.Phone;
            try
            {
                Accountimage.Image = Image.FromFile(User.photo);
            }
            catch
            {
                Accountimage.Image = Resources._3d_fluency_businessman_icon;
            }

        }

        private void ShowPassword_Click(object sender, EventArgs e) => Methods.ShowPassword(Passwordtxt);
    }
}
