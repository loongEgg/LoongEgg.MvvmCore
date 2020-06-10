/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/5/13 14:46:16
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
using LoongEgg.LoongLog.FX45;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoongEgg.MvvmCore.FX45
{
    /// <summary>
    /// 用于程序集反射的ViewModel
    /// </summary>
    public class AssemblyVM : ViewModel, IAssembleConfig
    {
        /// <summary>
        /// 目标程序集
        /// </summary>
        public Assembly Assembly { get; set; }

        /// <summary>
        /// 目标命令空间
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public AssemblyVM(Assembly assembly, string nspace)
        {
            this.Assembly = assembly ?? throw new ArgumentNullException(nameof(Assembly));
            this.Namespace = nspace ?? throw new ArgumentNullException(nameof(nspace));

            // 下面这个Button可以换成任意的类型，比如ToggleButton、RadioButton
            WindowShowCommand = new DelegateCommand<Button>(
                 btn =>
                 {
                     // 可以用Tag来代替Content因为有些Button的Content是图形而不是String
                     Logger.Debug($"Button <{btn.Content.ToString()}> clicked");

                     // 下面这两个Window可以换成任意的类型来响应点击事件
                     Window win = (Window)this.Assembly.CreateInstance(
                         Namespace + "." + btn.Content.ToString().Replace(" ", string.Empty));

                     // Show the window.
                     if (win != null)
                         win.Show(); // 额外的新窗口 
                 }
            );
            Logger.Info($"creat...");

        }
         
        /// <summary>
        /// 打开窗体命令
        /// </summary>
        public ICommand WindowShowCommand { get;set;} 
    }
}
