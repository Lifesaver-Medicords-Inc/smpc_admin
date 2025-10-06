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
using smpc_admin.Pages;

namespace smpc_admin.Pages.Companies
{
    public partial class CompanyAddress : Form
    {
        public event Action<CompanyAddressModel> CreateSuccess;
        public CompanyAddressModel _company_address = new CompanyAddressModel();
        public CompanyAddress(CompanyAddressModel companyAddress)
        {
            InitializeComponent();


            LoadCompanyAddress(companyAddress);
        }

        private void SaveAddress_Click(object sender, EventArgs e)
        {
            _company_address.AddressType = AddressTypeComboBox.Text;
            _company_address.UnitNo = UnitNoTextBox.Text;
            _company_address.BuildingName = BuildingNameTextBox.Text;
            _company_address.StreetName = StreetNameTextBox.Text;
            _company_address.Subdivision = SubdivisionTextBox.Text;
            _company_address.barangay = BarangayTextBox.Text;
            _company_address.City = CityTextBox.Text;
            _company_address.Province = ProvinceTextBox.Text;
            _company_address.Region = RegionTextBox.Text;
            _company_address.Country = CountryTextBox.Text;
            _company_address.PostalCode = int.Parse((PostalTextBox.Text is null)? PostalTextBox.Text: "0");

            CreateSuccess.Invoke(_company_address);

            this.Close();

        }

        private void LoadCompanyAddress(CompanyAddressModel companyAddress)
        {
            if (companyAddress != null)
            {
                AddressTypeComboBox.Text = companyAddress.AddressType;
                UnitNoTextBox.Text = companyAddress.UnitNo;
                BuildingNameTextBox.Text = companyAddress.BuildingName;
                StreetNameTextBox.Text = companyAddress.BuildingName;
                SubdivisionTextBox.Text = companyAddress.Subdivision;
                BarangayTextBox.Text = companyAddress.Subdivision;
                CityTextBox.Text = companyAddress.City;
                ProvinceTextBox.Text = companyAddress.Province;
                RegionTextBox.Text = companyAddress.Region;
                CountryTextBox.Text = companyAddress.Country;
                PostalTextBox.Text = companyAddress.PostalCode.ToString();
            }
        }
    }
}
