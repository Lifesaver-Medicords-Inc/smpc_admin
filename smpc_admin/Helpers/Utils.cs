using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_admin.Helpers
{
    class Utils
    {
        public static void ShowDialogMessage(string status, string message = "")
        {
            switch (status)
            {
                case "success":
                    MessageBox.Show(message, "SMPC SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "error":
                    MessageBox.Show(message, "SMPC SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    // Handle unexpected status values
                    MessageBox.Show("Unknown status: " + status, "SMPC SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
    }
}
