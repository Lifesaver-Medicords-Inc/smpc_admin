using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smpc_admin.Models;
using smpc_admin.Services;
using smpc_admin.Utils;

namespace smpc_admin.Pages.Companies
{
    public partial class CreateCompanyForm : Form
    {
        public event Action<CompanyModel> CreateSuccess;
        public Action<int> DeleteSuccess;
        private CompanyAddressModel _companyAddress;
        private List<CompanyContactModel> _companyContactList = new List<CompanyContactModel>();
        private CompanyModel _company = new CompanyModel();
        private bool IsEdit = false;
        public CreateCompanyForm(CompanyModel company = null)
        {

            InitializeComponent();


            StatusComboBox.SelectedItem = "Active";

            if (company != null)
            {
                IsEdit = true;
                _company = company;
                LoadData();
                LabelCompany.Text = "Edit Company";
                DeleteCompany.Visible = true;
            }
            
        }
        //private void LoadData()
        //{
        //    //BusinessTypeComboBox.DataSource = _company
              
        //}

        private void LoadData()
        {

            CompanyCodeTextBox.Text = _company.CompanyCode;
            CompanyNameTextBox.Text = _company.CompanyName;
            LegalCodeTextBox.Text = _company.LegalName;
            TradeNameTextBox.Text = _company.TradeName;
            BusinessTypeComboBox.Text = _company.BusinessType;
            SecRegistrationNoTextBox.Text = _company.SecRegistrationNo;
            DtiRegistrationNoTextBox.Text = _company.DtiRegistrationNo;
            TinNumberTextBox.Text = _company.tin;
            BirBranchCodeTextBox.Text = _company.BirBranchCode;
            RdoCodeTextBox.Text = _company.RdoCode;
            IndustryTextBox.Text = _company.Industry;
            StatusComboBox.SelectedItem = _company.Status;

            if (_company.IsHeadOffice)
                IsHeadOfficeCheckBox.Checked = true;
            else
                IsHeadOfficeCheckBox.Checked = false;


            foreach (DataGridViewColumn column in CompanyContactDataGridView.Columns)
            {
                if (string.IsNullOrEmpty(column.DataPropertyName))
                {
                    column.DataPropertyName = column.Name;
                }
            }

            foreach (var companyContact in _company.Contacts)
            {
                CompanyContactDataGridView.Rows.Add(companyContact.Id, companyContact.Fullname, companyContact.Designation, companyContact.Email, companyContact.PhoneNumber, companyContact.IsPrimaryContact);
            }

        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            { 
                _company.CompanyCode = CompanyCodeTextBox.Text;
                _company.CompanyName = CompanyNameTextBox.Text;
                _company.LegalName = LegalCodeTextBox.Text;
                _company.TradeName = TradeNameTextBox.Text;
                _company.BusinessType = BusinessTypeComboBox.Text;
                _company.SecRegistrationNo = SecRegistrationNoTextBox.Text;
                _company.DtiRegistrationNo = DtiRegistrationNoTextBox.Text;
                _company.tin = TinNumberTextBox.Text;
                _company.BirBranchCode = BirBranchCodeTextBox.Text;
                _company.RdoCode = RdoCodeTextBox.Text;
                _company.Industry = IndustryTextBox.Text;
                _company.Status = StatusComboBox.SelectedItem.ToString();
                
                if (IsHeadOfficeCheckBox.Checked) 
                    _company.IsHeadOffice = true; 
                else 
                    _company.IsHeadOffice = false;


                //Clear before using again
                _companyContactList.Clear();

                var isPrimaryContact = 0;

                //For Company contract datagridview to list
                foreach (DataGridViewRow dr in CompanyContactDataGridView.Rows)
                {
                    if (dr.IsNewRow) continue;

                    CompanyContactModel item = new CompanyContactModel();

                    if(dr.Cells["Id"].Value != null)
                    {
                        item.Id = int.Parse(dr.Cells["Id"].Value.ToString());
                    }
                    if (dr.Cells["FullName"].Value != null)
                    {
                        item.Fullname = dr.Cells["FullName"].Value.ToString();
                    }
                    if (dr.Cells["Designation"].Value != null)
                    {
                        item.Designation = dr.Cells["Designation"].Value.ToString();
                    }
                    if(dr.Cells["Email"].Value != null)
                    {
                        item.Email = dr.Cells["Email"].Value.ToString();
                    }
                    if(dr.Cells["PhoneNumber"].Value != null)
                    {
                        item.PhoneNumber = dr.Cells["PhoneNumber"].Value.ToString();
                    }
                    if (dr.Cells["IsPrimaryContact"].Value != null)
                    {
                        if (bool.Parse(dr.Cells["IsPrimaryContact"].Value.ToString()))
                        {
                            item.IsPrimaryContact = true;
                            isPrimaryContact++;
                        }
                        else
                            item.IsPrimaryContact = false;                
                    }

                    _companyContactList.Add(item);
                }


                //validation for primary contact
                if (isPrimaryContact > 1)
                    {
                        Utils.Helpers.ShowDialogMessage("Primary Contact is multiple. Please pick only one.");
                        return;

                    }

                _company.Address = _companyAddress;
                _company.Contacts = _companyContactList.ToArray();

                if (!IsEdit)
                {
                    var res = await CompanyService.CreateCompaniesAsync(_company);

                    CreateSuccess?.Invoke(res.Data);
                }
                else
                {
                    var res = await CompanyService.UpdateCompanyAsync(_company);
                    CreateSuccess?.Invoke(res.Data);

                }

                this.Close();
            }
            catch (Exception ex)
            {
                Utils.Helpers.ShowDialogMessage("Failed to create company:" + ex);
            }
        }

        private void AddressTab_Click(object sender, EventArgs e)
        {
            var createDialog = new CompanyAddress(_companyAddress);

            createDialog.CreateSuccess += (companyAddress) =>
            {
                _companyAddress = companyAddress;
            };

            createDialog.ShowDialog();
        }

        private async void DeleteCompany_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this company.", "Sure", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var res = await CompanyService.DeleteCompanyAsync(_company.Id);

                    if (res != null && res.Success)
                    {
                        DeleteSuccess?.Invoke(res.Data.Id);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    Utils.Helpers.ShowDialogMessage("Failed to remove company");
                }
            }
        }

        private void CompanySetup_Click(object sender, EventArgs e)
        {
            var createDialog = new CompanySetup(_company);

            createDialog.CreateSuccess += (company) =>
            {
                _company = company;
            };

            createDialog.ShowDialog();
        }
    }
}
