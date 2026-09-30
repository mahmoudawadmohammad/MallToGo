using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace SlamehProject
{
    static class Methods
    {
        #region Properties
        static string name;
        public static Thread th;
        static int userid = 0;
        static int currentid = 1;
        public static Cobone cobone = new Cobone();
        public static int Userid { set { userid = value; } get { return userid; } }
        public static int Currentid { set { currentid = value; } get { return currentid; } }
        //public static string FolderPath { get { return folderPath; } }
        public static string Name { get => name; set => name = value; }
        #endregion

        #region Methods
        private static void OpenProducts() => Application.Run(new Product_Manager_Form());
        private static void OpenLogin() => Application.Run(new Login()); 
        private static void OpenCategories() => Application.Run(new Categories_Page());
        private static void OpenUsers() => Application.Run(new _Users());
        private static void OpenAdminMainPage() => Application.Run(new AdminMainPage());
        private static void OpenAddAccount() => Application.Run(new EditAccountPage('a'));
        private static void OpenEditAccount() => Application.Run(new EditAccountPage('e'));
        private static void OpenEditProfile() => Application.Run(new EditProfile());
        private static void OpenSellPoint() => Application.Run(new SellPoint());
        private static void OpenManageCobones() => Application.Run(new ManageCobones());
        private static void OpenAddCobone() => Application.Run(new Add_Cobone());
        private static void OpenEditCobone() => Application.Run(new Add_Cobone('e'));
        public static String ChangeImage()
        {
            using (OpenFileDialog op = new OpenFileDialog
            { Title = "Select an Image", Filter = "Image Files(*.jpg;*.jpeg;*.png;*.gif;*.tif)|*.jpg;*.jpeg;*.png;*.gif;*.tif|All files (*.*)|*.*" })
            {
                if (op.ShowDialog() == DialogResult.OK)
                {
                    return op.FileName;
                }
            }
            return null;
        }
        public static void Validation(ref BunifuTextBox txt, ref ErrorProvider errorProvider)
        {
            switch (txt.Name)
            {
                case "FirstNametxt":
                    if (String.IsNullOrEmpty(txt.Text))
                    {
                        errorProvider.SetError(txt, "The First Name Can't Be Empty");
                        txt.Focus();
                    }
                    else
                        errorProvider.Clear();
                    break;
                case "LastNametxt":
                    if (String.IsNullOrEmpty(txt.Text))
                    {
                        errorProvider.SetError(txt, "The Last Name Can't Be Empty");
                        txt.Focus();
                    }
                    else
                        errorProvider.Clear();
                    break;
                case "Answertxt":
                    if (String.IsNullOrEmpty(txt.Text))
                    {
                        errorProvider.SetError(txt, "The Answer Can't Be Empty");
                        txt.Focus();
                    }
                    else
                        errorProvider.Clear();
                    break;
                case "Emailtxt":
                    if (String.IsNullOrEmpty(txt.Text))
                    {
                        errorProvider.SetError(txt, "The Email Can't Be Empty");
                        txt.Focus();
                    }
                    else
                    {
                        if (Regex.IsMatch(txt.Text, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
                            errorProvider.Clear();
                        else
                        {
                            errorProvider.SetError(txt, "The Email Is Invalid");
                            txt.Focus();
                        }
                    }
                    break;
                case "Passwordtxt":
                    if (String.IsNullOrEmpty(txt.Text))
                    {
                        errorProvider.SetError(txt, "The Password Can't Be Empty");
                        txt.Focus();
                    }
                    else
                    {
                        var hasNumber = new Regex(@"[0-9]+");
                        var hasUpperChar = new Regex(@"[A-Z]+");
                        var hasLowerChar = new Regex(@"[a-z]+");
                        var hasMinimum8Chars = new Regex(@".{8,}");

                        var isValidated = hasNumber.IsMatch(txt.Text) && hasUpperChar.IsMatch(txt.Text) && hasLowerChar.IsMatch(txt.Text) && hasMinimum8Chars.IsMatch(txt.Text);
                        if (isValidated)
                            errorProvider.Clear();
                        else
                        {
                            errorProvider.SetError(txt, "The Password invalid\nPassword must have Number, UpperCase, LowerCase and more than 8 Charachters");
                            txt.Focus();
                        }
                    }
                    break;
                case "Phonetxt":
                    if (String.IsNullOrEmpty(txt.Text))
                    {
                        errorProvider.SetError(txt, "The Phone Can't Be Empty");
                        txt.Focus();
                    }
                    else
                    {
                        var phone = new Regex(@"(09){1}\d{8}");
                        if (phone.IsMatch(txt.Text))
                            errorProvider.Clear();
                        else
                        {
                            errorProvider.SetError(txt, "The phone Is Invalid\nIt must begin with 09");
                            txt.Focus();
                        }
                    }
                    break;
            }
        }
        public static void Open(string PageName, int id = 0)
        {
            switch (PageName)
            {
                case "Products":
                    Methods.th = new Thread(OpenProducts);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
                case "Categories":
                    Methods.th = new Thread(OpenCategories);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
                case "Users":
                    Methods.th = new Thread(OpenUsers);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
                case "Login":
                    Methods.th = new Thread(OpenLogin);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
                case "Home":
                    Methods.th = new Thread(OpenAdminMainPage);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
                case "Edit Account":
                    Methods.th = new Thread(OpenEditAccount);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
                case "Add Account":
                    Methods.th = new Thread(OpenAddAccount);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
                case "Edit Profile":
                    Methods.th = new Thread(OpenEditProfile);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
                case "Sell Point":
                    Methods.th = new Thread(OpenSellPoint);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
                case "Cobones":
                    Methods.th = new Thread(OpenManageCobones);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
                case "Add Cobone":
                    Methods.th = new Thread(OpenAddCobone);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
                case "Edit Cobone":
                    Methods.th = new Thread(OpenEditCobone);
                    Methods.th.SetApartmentState(ApartmentState.STA);
                    Methods.th.Start();
                    break;
            }
        }

        //this function Convert to Encord your Password 
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        //this function Convert to Decord your Password
        public static string DecodeFrom64(string encodedData)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        public static string RandomString()
        {
            string result = "";
            string Formate = "abcdefghijklmnoqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int small = 10;
            Random rnd = new Random();
            for (int i = 0; i < small; i++)
            {
                result += Formate[rnd.Next(Formate.Length)];
            }
            return result;
        }
        public static void ShowPassword(BunifuTextBox textBox)
        {
            if (textBox.PasswordChar == '*')
                textBox.PasswordChar = '\0';
            else
                textBox.PasswordChar = '*';
        }
        #endregion
    }
}
