using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using Avalonia.Input;

namespace AvaloniaCostomTitle.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // titleBar.OnPointerMouseHander += TitleBarOnPointerMouseHander;
            // titleBar.Title = " ˝æ›ø‚≈‰÷√";
        }

        private void TitleBarOnPointerMouseHander(object? sender, PointerPressedEventArgs e)
        {
            BeginMoveDrag(e);
        }

        private void FileOpen_OnClick(object? sender, System.EventArgs e)
        {
        }

        private void FileSaveAs_OnClick(object? sender, System.EventArgs e)
        {
        }
    }
}