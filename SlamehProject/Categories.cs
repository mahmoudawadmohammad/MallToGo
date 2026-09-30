using Bunifu.UI.WinForms.BunifuButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlamehProject
{
    public partial class Categories_Page : Form
    {
        eStoreDBEntities _context = new eStoreDBEntities();
        public Categories_Page()
        {
            InitializeComponent();
        }
        private void _Categories_Load(object sender, EventArgs e)
        {
            
            GView_Categories.Rows.Clear();
            foreach(category category in _context.categories)
            {
                GView_Categories.Rows.Add(category.Category_ID,
                    category.Name,
                    _context.products.Count(cp => cp.Category_ID == category.Category_ID));
            }
        }

        private  void GView_Categories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GView_Categories.Rows[e.RowIndex].Cells[1].Value.ToString() != "Undefined")
            {
                if (GView_Categories.Columns[e.ColumnIndex].Name == "delete")
                {
                    if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (product product in _context.products)
                        {
                            if (product.Category_ID == (int)GView_Categories.Rows[e.RowIndex].Cells[0].Value)
                            {
                                product.Category_ID = 16;
                                 _context.SaveChangesAsync();
                            }
                        }
                        category category = _context.categories.Find(GView_Categories.Rows[e.RowIndex].Cells[0].Value);
                        _context.categories.Remove(category);
                        _context.SaveChanges();
                        GView_Categories.Rows.RemoveAt(e.RowIndex);
                        _Categories_Load(sender, e);
                    }
                }
                else if (GView_Categories.Columns[e.ColumnIndex].Name == "Edit")
                {
                    List<int> ids = new List<int>();
                    foreach (product product in _context.products)
                    {
                        if (product.Category_ID == (int)GView_Categories.Rows[e.RowIndex].Cells[0].Value)
                        {
                            ids.Add(product.Product_ID);
                            product.Category_ID = 16;
                            _context.SaveChangesAsync();
                        }
                    }
                    int cid = int.Parse(GView_Categories.Rows[e.RowIndex].Cells[0].Value.ToString());
                    category category = _context.categories.Find(cid);
                    Add_Category edit = new Add_Category('e', category);
                    edit.ShowDialog();
                    foreach (product product in _context.products)
                    {
                        if (ids.Contains(product.Product_ID))
                        {
                            product.Category_ID = cid;
                            _context.SaveChangesAsync();
                        }
                    }
                    _Categories_Load(sender, e);
                }
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            BunifuButton btn = (BunifuButton)sender;
            if(btn.Name == "Homebtn")
            {
                this.Close();
                Methods.Open("Home");
            }
            else
            {
                Add_Category add_Category = new Add_Category('a');
                add_Category.ShowDialog();
                _Categories_Load(sender, e);
            }
        }

        private void txt_search_category_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
