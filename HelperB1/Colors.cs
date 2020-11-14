using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HelperB1
{
    public static class Colors
    {
        public static int ColorToInt(System.Windows.Media.Brush brush)
        {
            Color color = ((SolidColorBrush)brush).Color;

            //byte a = ((Color)br.GetValue(System.Windows.Media.SolidColorBrush.ColorProperty)).A;
            byte g = ((Color)brush.GetValue(SolidColorBrush.ColorProperty)).G;
            byte r = ((Color)brush.GetValue(SolidColorBrush.ColorProperty)).R;
            byte b = ((Color)brush.GetValue(SolidColorBrush.ColorProperty)).B;

            return r | (g << 8) | (b << 16);
        }
    }
}
