using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace NicoViewUWP.Views
{
    public class TextTestPanel : Panel
    {
        Random random = new Random();

        DateTime lastTime = new DateTime();

        public string Message { get; set; }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (this.Children == null || this.Children.Count == 0) return base.ArrangeOverride(finalSize);

            var rand = random;

            int i = 0;

            var time = DateTime.Now;
            Message = (1000 / (time - lastTime).TotalMilliseconds).ToString();
            lastTime = time;

            foreach (var item in Children)
            {
                item.Measure(finalSize);
                
                item.Arrange(new Rect(time.Millisecond/1000.0 * finalSize.Width, i*1.0/Children.Count * finalSize.Height,item.ActualSize.X , item.ActualSize.Y));
                i++;
            }

            return base.ArrangeOverride(finalSize);
        }
    }
}

