using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_admin.Config
{
    class NavigationItem
    {
        public string Code { get; set; }           // Used for access control
        public string Text { get; set; }           // Display name
        public bool IsParent { get; set; }         // Whether this is a top-level node
        public List<NavigationItem> Children { get; set; } = new List<NavigationItem>();
    }
}
