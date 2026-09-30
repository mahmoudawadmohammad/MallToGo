using SlamehProject.Properties;
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
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using Bunifu.UI.WinForms.BunifuButton;
using Bunifu.UI.WinForms;

namespace SlamehProject
{
    public partial class EditAccountPage : Form
    {
        eStoreDBEntities _context = new eStoreDBEntities();
        user User;
        string imagePath = "SlamehProject.Properties.Resources._3d_fluency_businessman_icon";
        char _mode;
        public EditAccountPage(char mode)
        {
            _mode = mode;
            InitializeComponent();
            if(mode == 'e')
            {
                Title.Text = "Edit Account";
                this.Text = "Edit Account Page";
                Savebtn.Text = "Save";
                Savebtn.IdleIconLeftImage = Resources.icons8_edit_image_24px;
            }
            else
            {
                Title.Text = "Add Account";
                this.Text = "Add Account Page";
                Savebtn.Text = "Add";
                Savebtn.IdleIconLeftImage = Resources.icons8_add_user_male_48px;
            }
        }

        public EditAccountPage()
        {
        }

        private void DeleteImage_Click(object sender, EventArgs e)
        {
            Accountimage.Image = Resources._3d_fluency_businessman_icon;
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

        private void Input_Validating(object sender, CancelEventArgs e)
        {
            BunifuTextBox txt = (BunifuTextBox)sender;
            Methods.Validation(ref txt, ref errorProvider);
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
            if(btn.Name == "Backbtn")
            {
                this.Close();
                Methods.Open("Users");
            }
            else
            {
                if(btn.Text == "Add")
                {
                    if (CheckAll())
                    {
                        User = new user();
                        User.First_Name = FirstNametxt.Text;
                        User.Last_Name = LastNametxt.Text;
                        User.Email = Emailtxt.Text;
                        User.Password = Methods.EncodePasswordToBase64(Passwordtxt.Text);
                        User.Phone = Phonetxt.Text;
                        User.Role = Role.Checked == false ? "Admin" : "Seller";
                        User.photo = imagePath;
                        User.personal_question = Questions.SelectedText + ":" + Answertxt.Text;
                        _context.users.Add(User);
                        _context.SaveChangesAsync();
                        this.Close();
                        Methods.Open("Users");
                    }
                }
                else
                {
                    User.First_Name = FirstNametxt.Text;
                    User.Last_Name = LastNametxt.Text;
                    User.Email = Emailtxt.Text;
                    User.Password = Methods.EncodePasswordToBase64(Passwordtxt.Text);
                    User.Phone = Phonetxt.Text;
                    User.Role = Role.Checked == false ? "Admin" : "Seller";
                    User.photo = imagePath;
                    User.personal_question = Questions.SelectedItem.ToString() + ":" + Answertxt.Text;
                    _context.SaveChangesAsync();
                    this.Close();
                    Methods.Open("Users");
                }
            }
        }

        bool CheckAll()
        {
            bool Status = true;
            if (String.IsNullOrEmpty(FirstNametxt.Text))
            {
                errorProvider.SetError(FirstNametxt, "The First Name Can't Be Empty");
                Status = false;
            }
            else
                errorProvider.Clear();
            if (String.IsNullOrEmpty(LastNametxt.Text))
            {
                errorProvider.SetError(LastNametxt, "The Last Name Can't Be Empty");
                Status = false;
            }
            else
                errorProvider.Clear();
            if (String.IsNullOrEmpty(Emailtxt.Text))
            {
                errorProvider.SetError(Emailtxt, "The Email Can't Be Empty");
                Status = false;
            }
            else
                errorProvider.Clear();
            if (String.IsNullOrEmpty(Passwordtxt.Text))
            {
                errorProvider.SetError(Passwordtxt, "The Password Can't Be Empty");
                Status = false;
            }
            else
                errorProvider.Clear();
            if (String.IsNullOrEmpty(Phonetxt.Text))
            {
                errorProvider.SetError(Phonetxt, "The Phone Can't Be Empty");
                Status = false;
            }
            else
                errorProvider.Clear();
            if (String.IsNullOrEmpty(Answertxt.Text))
            {
                errorProvider.SetError(Answertxt, "The Answer Can't Be Empty");
                Status = false;
            }
            else
                errorProvider.Clear();
            return Status;
        }

        private void EditAccountPage_Load(object sender, EventArgs e)
        {
            if (_mode == 'e')
            {
                User = _context.users.Find(Methods.Userid);
                FirstNametxt.Text = User.First_Name;
                LastNametxt.Text = User.Last_Name;
                Emailtxt.Text = User.Email;
                Passwordtxt.Text = Methods.DecodeFrom64(User.Password);
                Phonetxt.Text = User.Phone;
                Role.Checked = User.Role == "Admin" ? false : true;
                if (User.photo == null)
                    Accountimage.Image = Resources._3d_fluency_businessman_icon;
                else
                    Accountimage.Image = Image.FromFile(User.photo);
                string[] str = User.personal_question.Split(':');
                Questions.SelectedItem = str[0];
                Answertxt.Text = str[1];
            }
        }

        private void ShowPassword_Click(object sender, EventArgs e) => Methods.ShowPassword(Passwordtxt);
    }
}
