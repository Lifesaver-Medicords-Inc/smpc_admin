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
    public partial class AccessControlView : UserControl
    {
        private PositionUsers _positionUsersForm;
        private PositionAccess _positionAccessForm;
        public AccessControlView()
        {
            InitializeComponent();
            _positionAccessForm = new PositionAccess();
            _positionAccessForm.Host(this);
            _positionAccessForm.Dock = DockStyle.Fill;
            TopSplitContainer.Panel2.Controls.Add(_positionAccessForm);

            _positionUsersForm = new PositionUsers();
            _positionUsersForm.Dock = DockStyle.Fill;
            AccessViewSplitContainer.Panel2.Controls.Add(_positionUsersForm);
        }

        public async void OnPositionChanged(PositionModel position)
        {
          await _positionUsersForm.LoadPositionUsersAsync(position.Id);
        }
    }
}
