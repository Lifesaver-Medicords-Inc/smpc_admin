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


namespace smpc_admin.Pages.AccessControls
{
    public partial class AccessControlForm : UserControl
    {
        private PositionUsersForm _positionUsersForm;
        private PositionAccessForm _positionAccessForm;
        public AccessControlForm()
        {
            InitializeComponent();
            _positionAccessForm = new PositionAccessForm();
            _positionAccessForm.Host(this);
            _positionAccessForm.Dock = DockStyle.Fill; 
            TopSplitContainer.Panel1.Controls.Add(_positionAccessForm);

            _positionUsersForm = new PositionUsersForm();
            _positionUsersForm.Dock = DockStyle.Fill;
            TopSplitContainer.Panel2.Controls.Add(_positionUsersForm);
        }

        public async void OnPositionChanged(PositionModel position)
        {
          await _positionUsersForm.LoadPositionUsersAsync(position.Id);
        }
    }
}
