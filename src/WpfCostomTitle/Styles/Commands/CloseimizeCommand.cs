using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCostomTitle.Styles.Commands
{
    /// <summary>
    /// 关闭
    /// </summary>
    public class CloseimizeCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var win = Window.GetWindow(parameter as Button);
            win.Close();
        }
    }
}
