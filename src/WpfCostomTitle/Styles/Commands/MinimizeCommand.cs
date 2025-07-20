using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCostomTitle.Styles.Commands
{
    /// <summary>
    /// 最小化
    /// </summary>
    public class MinimizeCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var win = Window.GetWindow(parameter as Button); // 获取当前按钮所在窗口
            win.WindowState = WindowState.Minimized;
        }
    }
}
