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
    public partial class formDashboard: Form
    {
        public formDashboard()
        {
            InitializeComponent();
        }

        FinancalCrmDbEntities2 db = new FinancalCrmDbEntities2();
        int count = 0;
        private void formDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString();


            var lastBalanceProcess = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault();
            lblIsBanProsessLast.Text = lastBalanceProcess.ToString();


            //chart1 kodları 
            var bankData = db.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach(var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }
            //chart2 kodları
            var billData = db.Bilss.Select(x => new
            {
                x.BillTittle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
                var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTittle, item.BillAmount);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if(count %4==1)
            {
                var ElektirikFaturasi = db.Bilss.Where(x => x.BillTittle == "Elektirik Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTittle.Text = "Elektirik Faturası";
                lblBillAmount.Text = ElektirikFaturasi.ToString();
            }
            if(count %4==2)
            {

                var SuFaturasi = db.Bilss.Where(x => x.BillTittle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTittle.Text = "Su Faturası";
                lblBillAmount.Text = SuFaturasi.ToString();
            }
            if (count % 4 == 3)
            {

                var İnternetFaturasi = db.Bilss.Where(x => x.BillTittle == "İnternet Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTittle.Text = "İnternet Faturası";
                lblBillAmount.Text = İnternetFaturasi.ToString();

            }
            if (count % 4 == 4)
            {
                var GenelHarcamalar = db.Bilss.Where(x => x.BillTittle == "Genel Harcamalar").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTittle.Text = "Genel Harcamalar";
                lblBillAmount.Text = GenelHarcamalar.ToString();
            }


                 


        }
    }
}
