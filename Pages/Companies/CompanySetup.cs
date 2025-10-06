using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smpc_admin.Models;
using smpc_admin.Services;

namespace smpc_admin.Pages.Companies
{
    public partial class CompanySetup : Form
    {
        public event Action<CompanyModel> CreateSuccess;
        private CompanyModel _company; 
        public CompanySetup(CompanyModel company)
        {
            InitializeComponent();

            _company = company;

            Loadcurrency();

            LoadSetup();
            
        }

        private void LoadSetup()
        {
            BegBalTextBox.Text = _company.BegBal.ToString();
            MonthlyRateTextBox.Text = _company.MonthlyRate.ToString();

            if (_company.StartFiscalYearDate != null && _company.StartFiscalYearDate.ToString() != "")
            {
                DateTime StartFiscalDate = DateTime.Parse(_company.StartFiscalYearDate.ToString());
                StartFiscalDateTimePicker.Value = StartFiscalDate;
            }

            if (_company.EndFiscalYearDate != null && _company.StartFiscalYearDate.ToString() != "")
            {
                DateTime EndFiscalDate = DateTime.Parse(_company.EndFiscalYearDate.ToString());
                EndFiscalDateTimePicker.Value = EndFiscalDate;
            }
        }

        private async void Loadcurrency()
        {
            var CodeExist = "PHP";

            if (_company.CurrencyCode != null && _company.CurrencyCode != "")
                CodeExist = _company.CurrencyCode;

                var allCurrency = await CompanyService.GetCurrencyAsync(CodeExist);
       
            CurrencyCodeComboBox.DataSource = allCurrency.Data;
            CurrencyCodeComboBox.DisplayMember = "Code";     
            CurrencyCodeComboBox.ValueMember = "RateValue";

            if (_company.CurrencyCode != null && _company.CurrencyCode != "")
                CurrencyCodeComboBox.Text = _company.CurrencyCode;
            else
                CurrencyCodeComboBox.Text = CodeExist;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            _company.BegBal = float.Parse(BegBalTextBox.Text);
            _company.MonthlyRate = float.Parse(MonthlyRateTextBox.Text);
            var selected = (CurrencyModel)CurrencyCodeComboBox.SelectedItem;
            _company.CurrencyCode = selected.Code;
            _company.StartFiscalYearDate = StartFiscalDateTimePicker.Value.ToString();
            _company.EndFiscalYearDate = EndFiscalDateTimePicker.Value.ToString();

            CreateSuccess.Invoke(_company);

            this.Close();
        }

        private void CurrencyCodeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var selected = (CurrencyModel)CurrencyCodeComboBox.SelectedItem;
            
            if(selected != null)
            CurrencyRateLabel.Text = selected.RateValue;
        }
    }
}
