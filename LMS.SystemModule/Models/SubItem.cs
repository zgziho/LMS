using System.Windows.Controls;

namespace LMS.SystemModule.Models
{
    /// <summary>
    /// 菜单子菜单类
    /// </summary>
    public class SubItem
    {
        public string Header { get; private set; }
        public UserControl View { get; private set; }

        public SubItem(string header, UserControl view = null)
        {
            Header = header;
            View = view;
        }
    }
}