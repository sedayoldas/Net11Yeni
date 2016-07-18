using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormRepo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        { 
            NWDataContext db = new NWDataContext();

            var sorgu1 = from urun in db.Products
                         where urun.UnitPrice >= decimal.Parse(txtMin.Text) &&
                         urun.UnitPrice <= decimal.Parse(txtMax.Text)
                         orderby urun.UnitPrice ascending 
                         select urun; /* 
                                       select new {
                                       urun.productName,
                                       urun.UnitPrice,
                                       };
                                       */

            var sorgu2 = db.Products.Where(urun => urun.UnitPrice >= decimal.Parse(txtMin.Text) &&
                         urun.UnitPrice <= decimal.Parse(txtMax.Text))
                         .Select(urun => new { urun.ProductName, urun.UnitPrice, urun.QuantityPerUnit }).OrderBy(u=>u.ProductName);

             //var sorgu2 = db.Products.Where(urun => urun.UnitPrice >= decimal.Parse(txtMin.Text) &&
             //            urun.UnitPrice <= decimal.Parse(txtMax.Text)).Select(u=>u);

            //var sorgu2 = db.Products.Where(urun => urun.UnitPrice >= decimal.Parse(txtMin.Text) &&
            //            urun.UnitPrice <= decimal.Parse(txtMax.Text));

            gvProducts.DataSource = sorgu2;
        }
    }
}
