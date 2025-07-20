using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCostomTitle.Styles.Commands
{
    /// <summary>
    /// 最大化
    /// </summary>
    public class MaximizeCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var win = Window.GetWindow(parameter as Button);
            win.WindowState = (win.WindowState == WindowState.Maximized)
                ? WindowState.Normal
                : WindowState.Maximized;
        }
    }
}
