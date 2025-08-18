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
using Serilog;

namespace smpc_admin.Pages.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private async void submitBtn_Click(object sender, EventArgs e)
        {

            try
            {
                //var employeeId = employeeIdTextbox.Text;
                // var password = passwordTextBox.Text;
                var employeeId = "PURCH-PO-8";
                var password = "PURCH-PO-8";

                if (string.IsNullOrWhiteSpace(employeeId))
                    {
                        MessageBox.Show("Employee ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(password))
                    {
                        MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var credentials = new Dictionary<string, dynamic>{
                        { "employee_id", employeeId},
                        { "password", password},
                    };

                    var res = await AuthService.LoginAsync(credentials);

                    if (res != null && res.Success)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
           
            }catch(Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show("Invalid login credentials");
            }
         
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
