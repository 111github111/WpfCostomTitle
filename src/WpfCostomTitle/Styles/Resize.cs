using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfCostomTitle.Styles.Helpers;

namespace WpfCostomTitle.Styles
{
    public class Resize
    {
        // 拖动改变窗口大小代码参考：
        // https://blog.csdn.net/u013113678/article/details/121548138

        public static bool GetIsResizeable(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsResizeableProperty);
        }
        public static void SetIsResizeable(DependencyObject obj, bool value)
        {
            obj.SetValue(IsResizeableProperty, value);
        }
        
        // Using a DependencyProperty as the backing store for IsResizeable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsResizeableProperty =
            DependencyProperty.RegisterAttached("IsResizeable", typeof(bool), typeof(Resize), new PropertyMetadata(false, onPropertyChangedCallback));

        // 1、声明并注册路由事件，使用冒泡策略
        public static readonly RoutedEvent MyClientEvent =
            EventManager.RegisterRoutedEvent("MyClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Resize));


        public static void onPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Rectangle rectangle)
            {
                _window = Window.GetWindow(d);

                
                rectangle.MouseLeftButtonDown += Rectangle_MouseLeftButtonDown;
                _window.MouseLeftButtonUp += Rectangle_MouseLeftButtonUp;
                _window.MouseMove += Rectangle_MouseMove;
            }
        }

        private static Window _window = null;
        private static Rectangle _winRect = null;
        private static Point _winPoint;
        private static Dpi _dpi = null;

        private static Rectangle _downRect = null;
        private static Point _downPoint;
        private static Point _newPoint;
        private static double _xOffect = 0;
        private static double _yOffect = 0;

        private static Task task = null;
        private static bool isRuning = false;
        private static TimeSpan delayTime = TimeSpan.FromMilliseconds(20);

        // 鼠标按下事件
        private static void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 组合情况：
            //   1. 左：左侧、左上、左下
            //   2. 右：右侧、右上、右下
            //   3. 上：上侧
            //   4. 下：下侧

            // 获取显示器分辨率
            _dpi = DpiHelper.GetDpiFromVisual(_window);

            // 获取鼠标相对于窗口的位置
            _downPoint = _window.PointToScreen(e.GetPosition(_window));
            _newPoint.X = _downPoint.X;
            _newPoint.Y = _downPoint.Y;


            // 鼠标相对于窗口边缘的偏移量
            _xOffect = _downPoint.X - _window.Left * _dpi.X;
            _yOffect = _downPoint.Y - _window.Top * _dpi.Y;

            
            if (sender is Rectangle rectangle)
            {
                _downRect = rectangle;
                _winRect = new Rectangle() { Width = _window.Width, Height = _window.Height };
                _winPoint.X = _window.Left;
                _winPoint.Y = _window.Top;


                var rectHorizontal = _downRect.HorizontalAlignment;
                var rectVertical = _downRect.VerticalAlignment;

                isRuning = true;
                task = Task.Run(async () =>
                {
                    while (isRuning)
                    {
                        await Task.Delay(delayTime);

                        try
                        {
                            TaskWindowSizeChange(rectHorizontal, rectVertical);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                });
            }
            else
            {
                _downRect = null;
                _winRect = null;
                _winPoint.X = 0;
                _winPoint.Y = 0;
            }
        }

        // 鼠标弹起
        private static void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isRuning = false;
            task = null;
        }
        



        // 鼠标移动事件
        private static void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            _newPoint = _window.PointToScreen(e.GetPosition(_window));
        }


        // 修改窗体宽高task方法
        private static void TaskWindowSizeChange(HorizontalAlignment rectHorizontal, VerticalAlignment rectVertical)
        {

            if (rectHorizontal == HorizontalAlignment.Left && rectVertical == VerticalAlignment.Top)
            {
                Console.WriteLine("keft - top - " + Random.Shared.NextInt64());
            }

            if (rectHorizontal == HorizontalAlignment.Left && rectVertical == VerticalAlignment.Stretch)
            {
                // var poor = _newPoint.X - _downPoint.X; // 差值
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // 更新完毕
                    // _window.Width = _winRect.Width - poor;
                    _window.Left = (_newPoint.X - _xOffect) / _dpi.X;

                    Console.WriteLine($"_newPoint.X = {_newPoint.X}, _xOffect = {_xOffect}, sub = {_window.Left}");

                    // 重置数据
                    _downPoint.X = _newPoint.X;
                    _downPoint.Y = _newPoint.Y;
                });
            }

            if (rectHorizontal == HorizontalAlignment.Left && rectVertical == VerticalAlignment.Bottom)
            {
                Console.WriteLine("keft - bottom - " + Random.Shared.NextInt64());
            }



            if (rectHorizontal == HorizontalAlignment.Right)
            {

            }

            if (rectHorizontal == HorizontalAlignment.Stretch && rectVertical == VerticalAlignment.Top)
            {

            }

            if (rectHorizontal == HorizontalAlignment.Stretch && rectVertical == VerticalAlignment.Bottom)
            {

            }


        }
    }
}
