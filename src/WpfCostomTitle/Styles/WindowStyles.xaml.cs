using System.Windows.Input;
using WpfCostomTitle.Styles.Commands;

namespace WpfCostomTitle.Styles
{
    public class WindowStyles
    {
        /// <summary>最小化窗体</summary>
        public static ICommand MinimizeWindowCommand { get; } = new MinimizeCommand();

        /// <summary>最大化窗体</summary>
        public static ICommand MaximizeWindowCommand { get; } = new MaximizeCommand();

        /// <summary>关闭窗体</summary>
        public static ICommand CloseimizeWindowCommand { get; } = new CloseimizeCommand();
    }
}
