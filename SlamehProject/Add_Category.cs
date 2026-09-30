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
    public partial class Add_Category : Form
    {
        eStoreDBEntities _context = new eStoreDBEntities();
        category C;
        public Add_Category(char mode, category category = null)
        {
            InitializeComponent();
            if(mode == 'a')
            {
                btn_save_new_category.Visible = true;
                btn_edit_cate.Visible = false;
                lbl_cate.Text = "Create Category";
                txt_add_new_category.PlaceholderText = "Enter The New Category";
                this.Text = "Create Category";
            }
            else
            {
                txt_add_new_category.Text = category.Name;
                btn_edit_cate.Visible = true;
                btn_save_new_category.Visible = false;
                lbl_cate.Text = "Edit Category";
                txt_add_new_category.PlaceholderText = "Enter The Editing Category";
                this.Text = "Edit Category";
                C = category;
            }
        }

        private void btn_save_new_category_Click(object sender, EventArgs e)
        {
            category category = new category { Name = txt_add_new_category.Text};
            _context.categories.Add(category);
            _context.SaveChangesAsync();
            this.Close();
        }

        private void btn_edit_cate_Click(object sender, EventArgs e)
        {
            C.Name = txt_add_new_category.Text;
            _context.SaveChangesAsync();
            this.Close();
        }
    }
}
