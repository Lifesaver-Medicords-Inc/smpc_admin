using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smpc_admin.Pages.AccessControls;
using smpc_admin.Pages.Positions;




namespace smpc_admin.Services
{
    class RoutesService
    {
        Dictionary<string, Control> _pages = new Dictionary<string, Control>()
        {

            {"ADMIN ACCESS CONTROL", new AccessControlForm()},
            {"ADMIN POSITIONS", new PositionsForm()  },
 

        };

        private string _selectedRoute;
        public RoutesService(string selectedRoute)
        {
            this._selectedRoute = selectedRoute;
        }
        public Control GetForm()
        {
            return _pages.TryGetValue(this._selectedRoute, out var pageValue)
                ? pageValue
                : null;
        }

        public String GetTitle()
        {

            return _pages.ContainsKey(_selectedRoute) ? _selectedRoute : string.Empty;
        }
    }
}
