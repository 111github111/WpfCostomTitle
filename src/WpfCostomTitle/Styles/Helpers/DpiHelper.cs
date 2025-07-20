using System.Windows;
using System.Windows.Media;

namespace WpfCostomTitle.Styles.Helpers
{
    public class DpiHelper
    {
        public static Dpi GetDpiFromVisual(Visual visual)
        {
            var source = PresentationSource.FromVisual(visual);
            if (source?.CompositionTarget != null)
            {
                var dpiX = source.CompositionTarget.TransformToDevice.M11;
                var dpiY = source.CompositionTarget.TransformToDevice.M22;
                return new Dpi(dpiX, dpiY);
            }
            else
            {
                return new Dpi(1, 1);
            }
        }
    }

    public class Dpi
    {
        public Dpi(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}
