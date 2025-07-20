using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HandyDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Github(object sender, RoutedEventArgs e)
        {
            this.txMessage.Text = "github...";
        }

        private void Btn_Settings(object sender, RoutedEventArgs e)
        {
            this.txMessage.Text = "settings...";
        }

        private void Btn_Tool(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            this.txMessage.Text = btn.Content.ToString() + "...";
        }
    }
}