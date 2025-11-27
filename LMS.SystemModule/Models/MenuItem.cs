using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.SystemModule.Models
{
    /// <summary>
    /// 菜单主菜单类
    /// </summary>
    public class MyMenuItem
    {
        public string Header { get; private set; }
        public PackIconKind Icon { get; private set; }

        public List<SubItem> SubItems { get; private set; }

        public MyMenuItem(string header, PackIconKind icon, List<SubItem> subItems)
        {
            Header = header;
            Icon = icon;
            SubItems = subItems;
        }
    }
}