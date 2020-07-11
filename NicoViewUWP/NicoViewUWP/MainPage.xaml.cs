using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Threading.Tasks;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace NicoViewUWP
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private DispatcherTimer _timer;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            //this._timer = new DispatcherTimer();
            //this._timer.Interval = TimeSpan.FromSeconds(1 / 60.0);
            //_timer.Tick += _timer_Tick;
            //_timer.Start();

            new Action(async () =>
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, async () =>
                {
                    while (true)
                    {
                        text.Text = panel.Message ?? "";
                        panel.InvalidateArrange();
                        await Task.Delay(1);
                    }
                }
                );
            }).Invoke();

            base.OnNavigatedTo(e);
        }

        private void _timer_Tick(object sender, object e)
        {
            text.Text = panel.Message;
            panel.InvalidateArrange();
        }
    }
}
