using LoongEgg.LoongLog.FX45;
using LoongEgg.MvvmCore.FX45;
using System.Windows;
using System.Windows.Controls;

namespace Demo.Wpf.FX45
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            DataContext = IoC.EnsureCreatAssemblyVM(this.GetType().Assembly, this.GetType().Namespace);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)e.OriginalSource;

            // Create an instance of the window named
            // by the current button.
            System.Type type = this.GetType();
            System.Reflection.Assembly assembly = type.Assembly;
            Window win = (Window)assembly.CreateInstance(
                type.Namespace + "." + cmd.Content.ToString().Replace(" ", string.Empty));

            // Show the window.
            if (win != null)
            {
                //win.ShowDialog(); // 对话框，会挡住程序
                win.Show(); // 额外的新窗口
            }
        }
    }
}
