using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using System;
using System.Threading.Tasks;

namespace AvaloniaCostomTitle;

public partial class WindowsTitleBar : UserControl
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<WindowsTitleBar, string>(nameof(Title));

    // 用来接收模板的
    public static readonly StyledProperty<ControlTemplate> LeftInnerProperty =
        AvaloniaProperty.Register<WindowsTitleBar, ControlTemplate>(nameof(Title));

    // 用来接收模板的
    public static readonly StyledProperty<ControlTemplate> RightInnerProperty =
        AvaloniaProperty.Register<WindowsTitleBar, ControlTemplate>(nameof(Title));

    /// <summary>
    /// 窗口移动
    /// </summary>
    public event EventHandler<PointerPressedEventArgs>? OnPointerMouseHander;

    public string Title
    {
        get { return GetValue(TitleProperty); }
        set
        {
            SetValue(TitleProperty, value);
            // sys_title.Text = value;
        }
    }

    public ControlTemplate LeftInner
    {
        get { return GetValue(LeftInnerProperty); }
        set { SetValue(LeftInnerProperty, value); }
    }

    public ControlTemplate RightInner
    {
        get { return GetValue(RightInnerProperty); }
        set { SetValue(RightInnerProperty, value); }
    }

    public WindowsTitleBar()
    {
        InitializeComponent();
        SubscribeToWindowState();
    }

    public override void EndInit()
    {
        base.EndInit();

        if (this.IsInitialized)
        {
            this.SizeChanged += WindowsTitleBar_SizeChanged;
            this.myLeftCtx.Template = this.LeftInner;
            this.myRightCtx.Template = this.RightInner;
        }
    }

    private static double rightPanelWidth = 0;
    private static double menuPanelWidth = 0;
    private void WindowsTitleBar_SizeChanged(object? sender, SizeChangedEventArgs e)
    {
        if (rightPanelWidth == 0)
            rightPanelWidth = this.rightPanel.Bounds.Width;

        // 缩小时, 右侧宽度会发生变化，所以只能使用刚打开时的宽度作为有效值
        if (menuPanelWidth == 0)
            menuPanelWidth = this.menuPanel.Bounds.Width;

        // 设置左侧宽度
        var calcWidth = this.Bounds.Width - rightPanelWidth - menuPanelWidth;
        if (calcWidth < 0) calcWidth = 0;
        this.leftPanel.Width = calcWidth;
    }

    private async void SubscribeToWindowState()
    {
        Window hostWindow = (this.VisualRoot as Window)!;
        while (hostWindow == null)
        {
            hostWindow = (this.VisualRoot as Window)!;
            await Task.Delay(50);
        }

        hostWindow.GetObservable(Window.WindowStateProperty).Subscribe(s =>
        {
            if (s != WindowState.Maximized)
            {
                winMaximizeIcon.Data = Geometry.Parse("M2048 2048v-2048h-2048v2048h2048zM1843 1843h-1638v-1638h1638v1638z");
                hostWindow.Padding = new Thickness(0, 0, 0, 0);
                MaximizeToolTip.Content = "Maximize";
            }
            if (s == WindowState.Maximized)
            {
                winMaximizeIcon.Data = Geometry.Parse("M2048 1638h-410v410h-1638v-1638h410v-410h1638v1638zm-614-1024h-1229v1229h1229v-1229zm409-409h-1229v205h1024v1024h205v-1229z");
                hostWindow.Padding = new Thickness(7, 7, 7, 7);
                MaximizeToolTip.Content = "Restore Down";
            }
        });
    }


    private void MinimizeWindow(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Window hostWindow = (this.VisualRoot as Window)!;
        hostWindow.WindowState = WindowState.Minimized;
    }

    private void MaximizeWindow(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Window hostWindow = (this.VisualRoot as Window)!;

        if (hostWindow.WindowState == WindowState.Normal)
        {
            hostWindow.WindowState = WindowState.Maximized;
        }
        else
        {
            hostWindow.WindowState = WindowState.Normal;
        }
    }

    private void CloseWindow2(object sender, RoutedEventArgs e)
    {
        Window hostWindow = (this.VisualRoot as Window)!;
        hostWindow.Close();
    }

    private void FileOpen_OnClick(object? sender, EventArgs e)
    {
    }

    private void FileSaveAs_OnClick(object? sender, EventArgs e)
    {
    }
}