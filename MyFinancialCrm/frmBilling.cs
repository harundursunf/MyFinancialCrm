using MyFinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFinancialCrm
{
    public partial class frmBilling: Form
    {
        public frmBilling()
        {
            InitializeComponent();
        }
        FinancalCrmDbEntities2 db = new FinancalCrmDbEntities2();
        private void frmBilling_Load(object sender, EventArgs e)
        {
            var values = db.Bilss.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnBillingList_Click(object sender, EventArgs e)
        {
            var values = db.Bilss.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            String tittle = txtBillTittle.Text;
            decimal Amount =decimal.Parse( txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bilss bilss = new Bilss();
            bilss.BillTittle = tittle;
            bilss.BillAmount = Amount;
            bilss.BillPeriod = period;
            db.Bilss.Add(bilss);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı bir şkeilde ekklendi");

            var values = db.Bilss.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillİD.Text);
            var removeValue = db.Bilss.Find(id);
         
            if(removeValue==null)
            {
                MessageBox.Show("geçerli bir id numarasını girirniz");
            }else 

            {
                db.Bilss.Remove(removeValue);
                db.SaveChanges();
                MessageBox.Show("başarıyla silindi ");


                var values = db.Bilss.ToList();
                dataGridView1.DataSource = values;
            }
        }

        private void btnUpdateBİll_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillİD.Text);
            String tittle = txtBillTittle.Text;
            decimal Amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            var values = db.Bilss.Find(id);
            values.BillTittle = tittle;
            values.BillAmount = Amount;
            values.BillPeriod = period;
         
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı bir şkeilde ekklendi");

            var values2 = db.Bilss.ToList();
            dataGridView1.DataSource = values2;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }
    }
}
