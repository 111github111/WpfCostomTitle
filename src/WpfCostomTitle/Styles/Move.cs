using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCostomTitle.Styles
{
    /// <summary>
    /// header拖动效果
    /// </summary>
    public class Move
    {
        // 由于style中不能给事件赋值，但是可以在附加属性改变事件中获取控件对象，此时再给控件事件赋值
        public static bool GetIsDragMoveable(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragMoveableProperty);
        }

        public static void SetIsDragMoveable(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragMoveableProperty, value);
        }
        // Using a DependencyProperty as the backing store for IsDragMoveable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDragMoveableProperty =
            DependencyProperty.RegisterAttached("IsDragMoveable", typeof(bool), typeof(Move), new PropertyMetadata(false, onPropertyChangedCallback));

        /// <summary>
        /// 拖动实现
        /// </summary>
        public static void onPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                element.MouseLeftButtonDown += MyElement_MouseLeftButtonDown;
            }
        }

        private static void MyElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // wpf内置鼠标移动
            var myWindow = Window.GetWindow(sender as UIElement);
            myWindow?.DragMove();
        }
    }
}
