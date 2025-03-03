using MyFinancialCrm.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyFinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancalCrmDbEntities2 db = new FinancalCrmDbEntities2();

        private void FrmBanks_Load(object sender, EventArgs e)
        {
            // **Banka Bakiyeleri**
            lblIsBankBalance.Text = db.Banks.Where(x => x.BankTitle == "İşBankası").Select(y => y.BankBalance).FirstOrDefault()?.ToString();
            lblVakifbankBalance.Text = db.Banks.Where(x => x.BankTitle == "VakifBank").Select(y => y.BankBalance).FirstOrDefault()?.ToString();
            lblZiraatBankBalance.Text = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault()?.ToString();

            // **Son 5 Banka Hareketi**
            var bankProcesses = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).ToList();
            Label[] labels = { lblBankProcess1, lblBankProcess2, lblBankProcess3, lblBankProcess4, lblBankProcess5 };

            for (int i = 0; i < bankProcesses.Count; i++)
            {
                labels[i].Text = $"📝 Açıklama: {bankProcesses[i].Description} | 💰 Miktar: {bankProcesses[i].Amount} | 📅 Tarih: {bankProcesses[i].ProcessDate}";
                labels[i].ForeColor = Color.DarkBlue;
                labels[i].Font = new Font("Arial", 10, FontStyle.Bold);
            }
        }

        private void btnBillFrom_Click(object sender, EventArgs e)
        {
            frmBilling frmBilling = new frmBilling();
            frmBilling.Show();
            this.Hide();
        }
    }
}
