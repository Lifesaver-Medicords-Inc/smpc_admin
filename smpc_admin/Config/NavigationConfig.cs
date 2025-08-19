using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    }
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
    }
}