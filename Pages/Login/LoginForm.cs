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
using smpc_admin.Utils;
using smpc_admin.Models;
using smpc_admin.Services;
using smpc_admin.Pages.Layout;

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

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                /*
                var access = new List<PositionAccessModel>
                {
                    new PositionAccessModel
                    {
                        Id = 0,
                        PositionId = "1",
                        Code = "ADMIN TOOLS",

                    },
                      new PositionAccessModel
                    {
                        Id = 1,
                        PositionId = "2",
                        Code = "ADMIN ACCESS CONTROL",

                    },
                };

                UserSession.SetCurrentPositionAccess(access);

                */

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

                if (res == null || !res.Success || res.Data == null)
                    {
                         MessageBox.Show("Invalid login credentials");
                         return;
                    }


                var data = res.Data;

                var positionRes = await PositionService.GetPositionAsync(18); //Change actual user position_id

                if(positionRes != null && positionRes.Success)
                {
                   
                    if (positionRes.Data != null && positionRes.Data.Access.Any())
                    {
                        SessionService.SetCurrentPositionAccess(positionRes.Data.Access);
                        SessionService.SetCurrentUser(data);
                        var mainForm = new MainLayoutForm();
                        this.Hide();
                        mainForm.Show();
                    }
                    
                }


            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show("Invalid login credentials");
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
         
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
