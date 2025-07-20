using System.Runtime.InteropServices;
using System.Drawing;

namespace WpfCostomTitle.Styles.Helpers
{
    public class User32Helper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);
    }
}
