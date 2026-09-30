using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuButton;
using Bunifu.Framework.UI;
using System.IO;
using SlamehProject.Properties;

namespace SlamehProject
{
    public partial class SellPoint : Form
    {
        List<finalListItem> invois_utem;
        eStoreDBEntities _context = new eStoreDBEntities();

        public delegate bool check(string name);
        public event check eve = (string name) =>
        {
            DialogResult res=MessageBox.Show("you don't have enouph quantity of this product : " + name + " \nwe removed the extera amount of  this product from your invoice","error",MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                return false;
            }
            return true;
        };

        int totalitems = 5, countitems = 0;
        Font smallFont = new Font("Arial", 25, FontStyle.Bold);
        Font middleFont = new Font("Arial", 30, FontStyle.Bold);
        Font bigFont = new Font("Bold", 35, FontStyle.Bold);
        int margin = 50;
        float rowHeight = 60;
        //List<finalListItem> pro = new List<finalListItem>();
        static node first = new node();
        static double total;
        static  int numb_item=0;
        Cobone cob;
        invoice i;
        public SellPoint()
        {
           
            InitializeComponent();
            ITEMLISTER();
            
            //  pro = context.producks.tolist();
           
        }

        private  void ITEMLISTER() 
        {

            //for (int i = 0; i < 2; i++)
            //{
            //    finalListItem er = new finalListItem();
            //    er.Name = "rte";
            //    er.Prise = 200;

            //    pro.Add(er);
            //}

            //for (int i = 0; i < 2; i++)
            //{
            //    finalListItem er = new finalListItem();
            //    er.Name = "tyy";
            //    er.Prise = 200;

            //    pro.Add(er);
            //}

            //for (int i = 0; i < 2; i++)
            //{
            //    finalListItem er = new finalListItem();
            //    er.Name = "ertrrr";
            //    er.Prise = 200;

            //    pro.Add(er);
            //}

            //for (int i = 0; i < 2; i++)
            //{
            //    finalListItem er = new finalListItem();
            //    er.Name = "pop";
            //    er.Prise = 200;

            //    pro.Add(er);
            //}
            flowLayoutPanel1.Controls.Clear();
            List<product> pro = _context.products.ToList();
            UserControl1[] temlst = new UserControl1[pro.Count];
            for (int i = 0; i < pro.Count; i++)
            {
                if (pro[i].Quantity == 0)
                    continue;
                temlst[i] = new UserControl1();
                temlst[i].Tage = pro[i].Name;
                temlst[i].Amont =Convert.ToInt32( pro[i].Quantity);
                temlst[i].PRISE = Convert.ToDouble( pro[i].Price);
                temlst[i].Id = pro[i].Product_ID;
                if (string.IsNullOrWhiteSpace(pro[i].Image))
                    temlst[i].Img = null;
                else
                    temlst[i].Img = Image.FromFile(pro[i].Image);
                
                flowLayoutPanel1.Controls.Add(temlst[i]);
               
            }
        }

        internal static void remove_the_item(string name ,double prise)
        {
            total -= prise;
            numb_item--;

            node move = new node();
            move = first;
            if (move == first && move.Data.Name == name)
            {
                if (move.Data.Amont > 1)
                {
                    move.Data.Amont--;
                    enditem();
                    return;
                }
                else
                {
                    first = first.Next;
                    if (first == null)
                    {
                        first = new node();
                        first.Data = null;
                    }
                    enditem(); return;
                }
            }
            else
            {

                while (true)
                {
                    if (move.Next.Data.Name == name)
                    {
                        
                        if (move.Next.Data.Amont > 1)
                        {
                            move.Next.Data.Amont--;
                            enditem();
                            return;
                        }
                        else
                        {
                            move.Next = move.Next.Next;
                            enditem(); return;
                        }
                    }
                    else
                    {
                       
                        move = move.Next;
                    }
                }
            }
            
        }

        private static void enditem() 
        {
           ItemsPanal.Controls.Clear();

            totalLabel.Text="total :" + total.ToString();
            
            node move = first;
            if (first.Data==null)
            {
                return;
            }
            else { 
                while (move!=null)
            {
                UserControl2 enditems = new UserControl2();
                enditems.Name = move.Data.Name;
                enditems.Prise = move.Data.Prise;
                enditems.Amont = move.Data.Amont;
                ItemsPanal.Controls.Add(enditems);
                    move = move.Next;
            }}
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        public static void aadd_to_end_list(string tage, double prise1, int Id)
        {
            total += prise1;
            numb_item++;
            node move = new node();
            move = first;
            if (first.Data == null)
            {
                first.Data = new finalListItem();
            }
            while (move != null)
            {
                if (move.Data.Name == null)
                {
                    move.Data = new finalListItem();
                    move.Data.Prise = prise1;
                    move.Data.Name = tage;
                    move.Data.Amont = 1;
                    move.Data.Id = Id;

                    enditem();
                    return;
                }
                else

                {
                    if (move.Data.Name == tage)
                    {

                        move.Data.Amont++;

                        enditem();
                        return;
                    }
                    else
                    { move = move.Next; }
                }

            }

            move = first;
            while (true)
            {
                if (move == null)
                {
                    finalListItem tem = new finalListItem
                    {
                        Prise = prise1,
                        Name = tage,
                        Amont = 1
                    };
                    move = first;
                    move.Data = tem;
                    enditem();
                    return;
                }
                else
                if (move.Next == null)
                {
                    move.Next = new node();
                    move.Next.Data = new finalListItem();
                    move.Next.Data.Prise = prise1;
                    move.Next.Data.Name = tage;
                    move.Next.Data.Amont = 1;
                    move.Next.Data.Id = Id;
                    enditem();
                    return;
                }
                else { move = move.Next; }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            List<finalListItem> send = new List<finalListItem>();
            node move = new node();
            move = first;
            while (move != null) 
            {
                send.Add(move.Data);
                move = move.Next;
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            BunifuButton btn = (BunifuButton)sender;
            if (btn.Name == "Logoutbtn")
            {
                ItemsPanal.Controls.Clear();
                this.Close();
                Methods.Open("Login");
            }
            else
            {
                ItemsPanal.Controls.Clear();
                this.Close();
                Methods.Open("Edit Profile");
            }
        }

        private void Pay_Click(object sender, EventArgs e)
        {
            bool tem;
            //============================
            node move = first;
            invois_utem = new List<finalListItem>(numb_item);
            while (move != null)
            {
                product p = _context.products.Find(move.Data.Id);
                if (p.Quantity < move.Data.Amont)
                {

                    move.Data.Amont = Convert.ToInt32(p.Quantity);
                    enditem();
                    tem = eve(p.Name);
                    if (tem)
                        return;
                }
                else
                {
                    p.Quantity -= move.Data.Amont;
                }
                invois_utem.Add(move.Data);
                move = move.Next;
            }
            invoice invoice = new invoice() { DateTime = DateTime.Now };
            i = _context.invoices.Add(invoice);
            _context.SaveChanges();
            foreach(finalListItem item in invois_utem)
            {
                order order = new order();
                order.Invoice_ID = i.Invoice_ID;
                order.Product_ID = item.Id;
                order.Sold_Quantity = item.Amont;
                _context.orders.Add(order);
                _context.SaveChanges();
            }
            totalitems = invois_utem.Count;
            _context.SaveChanges();
            ITEMLISTER();
            printDialog.AllowSelection = true;
            printDialog.AllowSomePages = true;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                Invoice.Print();
            }
            countitems = 0;
        }
        private void Header(PrintPageEventArgs e)
        {
            string title = "Application Name";
            SizeF sizeTitle = e.Graphics.MeasureString(title, middleFont);
            e.Graphics.DrawString(title, middleFont, Brushes.Black, (e.PageBounds.Width - sizeTitle.Width) / 2, margin);
            e.Graphics.DrawString("__________________", bigFont, Brushes.Black, 175, 80);
            e.Graphics.DrawString("Invoice Number : #" + i.Invoice_ID, smallFont, Brushes.Black, margin, 220);
            e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), smallFont, Brushes.Black, margin, 300);
            e.Graphics.DrawString("Time : " + DateTime.Now.ToShortTimeString(), smallFont, Brushes.Black, 565, 300);
        }
        private void Body(PrintPageEventArgs e)
        {
            if (countitems < 8)
            {
                SizeF sizeQ = e.Graphics.MeasureString("Quantity", middleFont);
                e.Graphics.DrawRectangle(Pens.Black, margin, 450, e.PageBounds.Width - margin * 2, 615);
                e.Graphics.DrawLine(Pens.Black, margin, 510, e.PageBounds.Width - margin, 510);
                e.Graphics.DrawString("Item", middleFont, Brushes.Black, 55, 455);
                e.Graphics.DrawLine(Pens.Black, 330, 450, 330, e.PageBounds.Height - 35);
                e.Graphics.DrawString("Quantity", middleFont, Brushes.Black, (e.PageBounds.Width - sizeQ.Width) / 2, 455);
                e.Graphics.DrawLine(Pens.Black, 515, 450, 515, e.PageBounds.Height - 35);
                e.Graphics.DrawString("Total", middleFont, Brushes.Black, 515, 455);
                for (; countitems < 8; countitems++)
                {
                    if (invois_utem.Count == countitems || invois_utem.Count == countitems - 1)
                        continue;
                    string Quantity = invois_utem[countitems].Amont.ToString();
                    SizeF size = e.Graphics.MeasureString(Quantity, smallFont);
                    e.Graphics.DrawString(invois_utem[countitems].Name.ToString(), smallFont, Brushes.Navy, 55, 460 + rowHeight);
                    e.Graphics.DrawString(Quantity, smallFont, Brushes.Navy, (e.PageBounds.Width - size.Width) / 2, 460 + rowHeight);
                    e.Graphics.DrawString(invois_utem[countitems].Prise.ToString(), smallFont, Brushes.Navy, 515, 460 + rowHeight);
                    if (countitems == 8)
                        continue;
                    e.Graphics.DrawLine(Pens.Black, margin, 515 + rowHeight, e.PageBounds.Width - margin, 515 + rowHeight);
                    rowHeight += 55;
                }
            }
            else if (totalitems - countitems > 15)
            {
                float max = totalitems - countitems < 19 ? (float)((totalitems - countitems) * 54.5) : 1030;
                e.Graphics.DrawRectangle(Pens.Black, margin, 35, e.PageBounds.Width - margin * 2, max);
                e.Graphics.DrawLine(Pens.Black, 330, 35, 330, max + 35);
                e.Graphics.DrawLine(Pens.Black, 515, 35, 515, max + 35);
                rowHeight = 5;
                for (int i = 0; i < 18; i++)
                {
                    if (totalitems == countitems)
                        continue;
                    string Quantity = invois_utem[countitems].Amont.ToString();
                    SizeF size = e.Graphics.MeasureString(Quantity, smallFont);
                    e.Graphics.DrawString(invois_utem[countitems].Name.ToString(), smallFont, Brushes.Navy, 55, 30 + rowHeight);
                    e.Graphics.DrawString(Quantity, smallFont, Brushes.Navy, (e.PageBounds.Width - size.Width) / 2, 30 + rowHeight);
                    e.Graphics.DrawString(invois_utem[countitems].Prise.ToString(), smallFont, Brushes.Navy, 515, 30 + rowHeight);
                    if (i == 17 || totalitems - 1 == countitems)
                        continue;
                    e.Graphics.DrawLine(Pens.Black, margin, 80 + rowHeight, e.PageBounds.Width - margin, 80 + rowHeight);
                    rowHeight += 55;
                    countitems++;
                }
            }
            else
            {
                if (totalitems != countitems)
                {
                    float max = (float)((totalitems - countitems) * 54.5);
                    e.Graphics.DrawRectangle(Pens.Black, (float)margin, 35, e.PageBounds.Width - margin * 2, max);
                    e.Graphics.DrawLine(Pens.Black, 330, 35, 330, max + 35);
                    e.Graphics.DrawLine(Pens.Black, 515, 35, 515, max + 35);
                    rowHeight = 5;
                    for (; countitems < totalitems; countitems++)
                    {
                        string Quantity = invois_utem[countitems].Amont.ToString();
                        SizeF size = e.Graphics.MeasureString(Quantity, smallFont);
                        e.Graphics.DrawString(invois_utem[countitems].Name.ToString(), smallFont, Brushes.Navy, 55, 30 + rowHeight);
                        e.Graphics.DrawString(Quantity, smallFont, Brushes.Navy, (e.PageBounds.Width - size.Width) / 2, 30 + rowHeight);
                        e.Graphics.DrawString(invois_utem[countitems].Prise.ToString(), smallFont, Brushes.Navy, 515, 30 + rowHeight);
                        if (countitems == totalitems - 1)
                            continue;
                        e.Graphics.DrawLine(Pens.Black, margin, 80 + rowHeight, e.PageBounds.Width - margin, 80 + rowHeight);
                        rowHeight += 55;
                    }
                    countitems++;
                }
                else
                    countitems++;
            }
            rowHeight = 60;
        }
        private void Footer(PrintPageEventArgs e)
        {
            int p = cob == null ? 0 : cob.percent;
            e.Graphics.DrawLine(Pens.Black, margin, e.PageBounds.Height - 220, e.PageBounds.Width - margin, e.PageBounds.Height - 220);
            e.Graphics.DrawString("Cobone", middleFont, Brushes.Black, 100, e.PageBounds.Height - 210);
            e.Graphics.DrawString("", middleFont, Brushes.Black, 380, e.PageBounds.Height - 210);
            e.Graphics.DrawString(p.ToString(), middleFont, Brushes.Black, 615, e.PageBounds.Height - 210);
            e.Graphics.DrawLine(Pens.Black, margin, e.PageBounds.Height - 150, e.PageBounds.Width - margin, e.PageBounds.Height - 150);
            e.Graphics.DrawString("Total", middleFont, Brushes.Black, 100, e.PageBounds.Height - 140);
            e.Graphics.DrawString(numb_item.ToString(), middleFont, Brushes.Black, 380, e.PageBounds.Height - 140);
            e.Graphics.DrawString(total.ToString(), middleFont, Brushes.Black, 615, e.PageBounds.Height - 140);
            string Footer = "{ Thanks for choosing us ♥ }";
            SizeF sizeFooter = e.Graphics.MeasureString(Footer, bigFont);
            e.Graphics.DrawString(Footer, bigFont, Brushes.Goldenrod, (e.PageBounds.Width - sizeFooter.Width) / 2, e.PageBounds.Height - 65);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string cat = drop_cat.Text;
            int cat_id = 0;
            if (drop_cat.Text != "all")
                if (sh.Text == "")
                {
                    return;
                }
                else { 
                cat_id = _context.categories.Where(a => a.Name.Contains(cat)).FirstOrDefault().Category_ID;
            flowLayoutPanel1.Controls.Clear();
            //Task.Run(() => show_products(cat_id, sh.Text));
            show_products(cat_id, sh.Text);}
        }
        private void show_products(int category_id, string product_name)
        {
            if (category_id == 0)
                foreach (product p in _context.products.Where(x => x.Name.Contains(product_name)))
                {
                    UserControl1 pctrl = new UserControl1();
                    pctrl.Id = p.Product_ID;
                    if (File.Exists(p.Image))
                        pctrl.Img = Image.FromFile(@p.Image);
                    pctrl.Tage = p.Name;
                    pctrl.Amont = Convert.ToInt32(p.Quantity);
                    pctrl.PRISE = Convert.ToDouble( p.Price);

                    flowLayoutPanel1.Invoke(new Action(() => flowLayoutPanel1.Controls.Add(pctrl)));
                }
            else
                foreach (product p in _context.products.Where(x => x.Name.Contains(product_name) && x.Category_ID == category_id))
                {
                    UserControl1 pctrl = new UserControl1();
                    pctrl.Id = p.Product_ID;
                    if (File.Exists(p.Image))
                        pctrl.Img = Image.FromFile(@p.Image);
                    pctrl.Tage = p.Name;
                    pctrl.Amont = Convert.ToInt32(p.Quantity);
                    pctrl.PRISE = Convert.ToDouble(p.Price);

                    flowLayoutPanel1.Invoke(new Action(() => flowLayoutPanel1.Controls.Add(pctrl)));
                }
        }
        private void show_products_only_cat(int category_id)
        {
            if (category_id == 0)
                ITEMLISTER(); 
            else
                foreach (product p in _context.products.Where(x => x.Category_ID== category_id))
                {
                    UserControl1 pctrl = new UserControl1();
                    pctrl.Id = p.Product_ID;
                    if (File.Exists(p.Image))
                    pctrl.Img = Image.FromFile(@p.Image);
                    pctrl.Tage = p.Name;
                    pctrl.Amont = Convert.ToInt32( p.Quantity);
                    pctrl.PRISE = Convert.ToDouble(p.Price);

                    flowLayoutPanel1.Invoke(new Action(() => flowLayoutPanel1.Controls.Add(pctrl)));
                }
        }

        private void SellPoint_Load(object sender, EventArgs e)
        {
            foreach(category ca in _context.categories)
            drop_cat.Items.Add(ca.Name);

        }

        private void drop_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat = drop_cat.Text;
            int cat_id = 0;
            if (drop_cat.Text != "all")
                cat_id = _context.categories.Where(a => a.Name == cat).FirstOrDefault().Category_ID;
            flowLayoutPanel1.Controls.Clear();
            show_products_only_cat(cat_id);
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string str = Cobonetxt.Text;
            cob = _context.Cobones.Where(x => x.cobone_number == str).FirstOrDefault();
            //if (Cobonetxt.Text == cob.num)
            if (cob is null) return;
            if(cob.status.ToLower() == "not used")
            {
                if(cob.Products=="all")
                {
                    total = Convert.ToDouble( total - (cob.percent/100)*total);
                    enditem();
                }
                else
                {
                    node move = first;
                    while(move!=null)
                    {
                        if (move.Data.Name == cob.Products)
                        {
                            int am=   move.Data.Amont;
                            double res = am * (move.Data.Prise);
                            total -= res;
                            res =Convert.ToDouble( res- (res*cob.percent)/100);
                            total += res;
                            enditem();
                        }
                        move= move.Next;
                    }
                }

            }
            else
            {
                MessageBox.Show("cobone is not valid");
                return;
            }
        }

        private void Invoice_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (totalitems < 7)
            {
                Header(e);
                SizeF sizeQ = e.Graphics.MeasureString("Quantity", middleFont);
                e.Graphics.DrawRectangle(Pens.Black, margin, 450, e.PageBounds.Width - margin * 2, 400);
                e.Graphics.DrawLine(Pens.Black, margin, 510, e.PageBounds.Width - margin, 510);
                e.Graphics.DrawString("Item", middleFont, Brushes.Black, 55, 455);
                e.Graphics.DrawLine(Pens.Black, 330, 450, 330, 850);
                e.Graphics.DrawString("Quantity", middleFont, Brushes.Black, (e.PageBounds.Width - sizeQ.Width) / 2, 455);
                e.Graphics.DrawLine(Pens.Black, 515, 450, 515, 850);
                e.Graphics.DrawString("Total", middleFont, Brushes.Black, 515, 455);
                for (int i = 0; i < totalitems; i++)
                {
                    double Quantity = invois_utem[countitems].Amont;
                    SizeF size = e.Graphics.MeasureString(Quantity.ToString(), smallFont);
                    e.Graphics.DrawString(invois_utem[countitems].Name.ToString(), smallFont, Brushes.Navy, 55, 460 + rowHeight);
                    e.Graphics.DrawString(Quantity.ToString(), smallFont, Brushes.Navy, (e.PageBounds.Width - size.Width) / 2, 460 + rowHeight);
                    e.Graphics.DrawString((invois_utem[countitems].Prise * Quantity).ToString(), smallFont, Brushes.Navy, 515, 460 + rowHeight);
                    e.Graphics.DrawLine(Pens.Black, margin, 515 + rowHeight, e.PageBounds.Width - margin, 515 + rowHeight);
                    rowHeight += 55;
                    countitems++;
                }
                Footer(e);
            }
            else
            {
                if (countitems < 8)
                    Header(e);
                Body(e);
                if (totalitems < countitems)
                {
                    Footer(e);
                    e.HasMorePages = false;
                    return;
                }
                e.HasMorePages = true;
                return;
            }
        }
    }
}
