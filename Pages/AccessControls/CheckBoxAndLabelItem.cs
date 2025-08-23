using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_admin.Pages.AccessControls
{
    public partial class CheckBoxAndLabelItem : UserControl
    {

        public string id { get; private set; }
        public bool IsChecked
        {
            get => CheckBox.Checked;
            set => CheckBox.Checked = value;
        }

        public string LabelText { get; private set; }

        public event EventHandler<bool> OnCheckedChanged;

        public CheckBoxAndLabelItem(string key, string value)
        {
            InitializeComponent();
            LabelText = value;
            Label.Text = value;
            id = key;

        }

        private void CheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            OnCheckedChanged?.Invoke(this, CheckBox.Checked);

        }

    }
}
