namespace AvaloniaCostomTitle.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public string Greeting { get; } = "Welcome to Avalonia!";

        public void CutCommand() { }

        public void CopyCommand() { }

        public void PasteCommand() { }
    }
}
