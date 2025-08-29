using smpc_admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_admin.Config
{

   class NavigationConfig
    {
        public static List<NavigationItem> Items { get; } = new List<NavigationItem>
        {
            new NavigationItem
            {
                Code = "ADMIN TOOLS",
                Text = "Admin Tools",
                IsParent = true,
                Children = new List<NavigationItem>
                {
                    new NavigationItem
                    {
                        Code = "ADMIN ACCESS CONTROL",
                        Text = "Access Control",
                        IsParent = false,

                    },
                    new NavigationItem
                    {
                        Code = "ADMIN POSITIONS",
                        Text = "Positions",
                        IsParent = false
                    },
                }
            }
        };

        // ✅ Get all codes
        public static List<string> GetAllCodes(List<NavigationItem> items)
        {
            var codes = new List<string>();

            foreach (var item in items)
            {
                codes.Add(item.Code);

                if (item.Children != null && item.Children.Any())
                {
                    codes.AddRange(GetAllCodes(item.Children));
                }
            }

            return codes;
        }

        // ✅ Get all texts
        public static List<string> GetAllTexts(List<NavigationItem> items)
        {
            var texts = new List<string>();

            foreach (var item in items)
            {
                texts.Add(item.Text);

                if (item.Children != null && item.Children.Any())
                {
                    texts.AddRange(GetAllTexts(item.Children));
                }
            }

            return texts;
        }

        // ✅ Get all code-text pairs
        public static List<KeyValuePair<string, string>> GetAllItems(List<NavigationItem> items)
        {
            var list = new List<KeyValuePair<string, string>>();

            foreach (var item in items)
            {
                list.Add(new KeyValuePair<string, string>(item.Code, item.Text));

                if (item.Children != null && item.Children.Any())
                {
                    list.AddRange(GetAllItems(item.Children));
                }
            }

            return list;
        }


        public static void PopulateNavigationTree(TreeNodeCollection targetNodes,
                 IEnumerable<NavigationItem> navigationItems,
                    TreeNode parentNode = null)
        {
            foreach (var item in navigationItems)
            {
                if (!SessionService.HasAccess(item.Code))
                    continue;

                var currentNode = new TreeNode(item.Text)
                {
                    Name = item.Code
                };

                // Recurse into children
                PopulateNavigationTree(currentNode.Nodes, item.Children, currentNode);

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(currentNode);
                }
                else
                {
                    targetNodes.Add(currentNode);
                }
            }
        }

        private TreeNode CreateNodeWithChildren(NavigationItem item)
        {
            if (!SessionService.HasAccess(item.Code))
                return null;

            var node = new TreeNode(item.Text)
            {
                Name = item.Code
            };

            foreach (var child in item.Children)
            {
                var childNode = CreateNodeWithChildren(child);
                if (childNode != null)
                {
                    node.Nodes.Add(childNode);
                }
            }

            return node;
        }
    }
}