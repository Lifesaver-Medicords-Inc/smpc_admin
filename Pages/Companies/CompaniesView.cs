using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smpc_admin.Services;
using smpc_admin.Models;
using smpc_admin.Utils;

namespace smpc_admin.Pages.Companies
{
    public partial class CompaniesView : UserControl
    {
        private List<CompanyModel> _companies;
        public CompaniesView()
        {
            InitializeComponent();
            LoadCompanies();
        }
        
        private async void LoadCompanies()
        {

            try
            {
                var res = await CompanyService.GetCompaniesAsync();

                if (res != null && res.Success)
                {
                    var companies = res.Data.ToList();

                    _companies = companies;

                    PopulateGrid(companies);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void PopulateGrid(List<CompanyModel> companies)
        {

            CompanyDataGridView.Rows.Clear();

            foreach (var company in companies)
            {
                CompanyDataGridView.Rows.Add(company.CompanyCode, company.CompanyName, company.Id);
            }

        }

        private void NewCompanyBtn_Click(object sender, EventArgs e)
        {
            var createDialog = new CreateCompanyForm();


            createDialog.CreateSuccess += (company) =>
            {
                _companies.Add(company);
                PopulateGrid(_companies);
            };

            createDialog.ShowDialog();
        }

        private void CompanyDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int CompanyId = int.Parse(CompanyDataGridView.Rows[e.RowIndex].Cells["Id"].Value?.ToString());

            var selectedCompany = _companies.FirstOrDefault(u => u.Id == CompanyId);

            if (selectedCompany != null)
            {
                var UpdateCompanyForm = new CreateCompanyForm(selectedCompany);

                UpdateCompanyForm.CreateSuccess += (company) =>
                {
                    _companies = _companies.Where(u => u.Id != company.Id).ToList();

                    _companies.Add(company);

                    PopulateGrid(_companies);

                };
                UpdateCompanyForm.DeleteSuccess += (id) =>
                {
                    _companies = _companies.Where(u => u.Id != id).ToList();

                    PopulateGrid(_companies);
                };

                UpdateCompanyForm.ShowDialog();
            }

        }
    }
}
