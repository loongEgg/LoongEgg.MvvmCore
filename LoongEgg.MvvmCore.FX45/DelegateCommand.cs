using System;
using System.Windows.Input;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/5/13 14:47:15
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.MvvmCore.FX45
{
    /// <summary>
    /// 仅执行无参数的方法和判断方法的<see cref="ICommand"/>实现
    /// </summary>
    public class DelegateCommand : DelegateCommand<object>
    {
        /// <summary>
        /// 永远可以执行的<see cref="DelegateCommand"/>
        /// </summary>
        /// <param name="executeMethod">一个无参数，无返回值的方法</param>
        public DelegateCommand(Action executeMethod)
            : base(_ => executeMethod()) { }

        /// <summary>
        /// <see cref="DelegateCommand"/>的主构造器
        /// </summary>
        /// <param name="executeMethod">一个无参数，无返回值的方法</param>
        /// <param name="canExecuteMethod">一个无参数，但返回布尔值的方法</param>
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
            : base(_ => executeMethod(), _ => canExecuteMethod()) { }
    }
}
