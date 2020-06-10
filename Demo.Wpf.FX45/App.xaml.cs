using LoongEgg.LoongLog.FX45;
using System.Windows;

namespace Demo.Wpf.FX45
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Logger.Enable(Loggers.DebugLogger);
        }
    }
}
