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
using smpc_admin.Pages.Layout;
using Newtonsoft.Json;

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


                if (res == null || !res.Success)
                    {
                        
                         MessageBox.Show("Invalid login credentials");
                         return;
                    }

                var data = res.Data;

            
                var positionRes = await PositionService.GetPositionAsync(res.Data.PositionId);

                if (positionRes != null && positionRes.Success)
                {
                    if (positionRes.Data != null && positionRes.Data.Access != null)
                    {
                        SessionService.SetCurrentPositionAccess(positionRes.Data.Access);
                        SessionService.SetCurrentUser(data);

                        var mainForm = new MainLayoutForm();
                        this.Hide();
                        mainForm.Show();
                    }
                }


                var permissionsRes = await UserService.GetUserPermissionAsync(res.Data.Id);

                if(permissionsRes != null && permissionsRes.Success)
                {
                    if(permissionsRes.Data != null)
                    {
                        SessionService.SetCurrentUserPermission(permissionsRes.Data);
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
