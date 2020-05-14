using System;
using System.Collections.Generic;
using System.Text;
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
    /// 泛型化的ICommand实现，会调用指定的委托执行命令
    /// A command that calls the specified delegate when the command is executed.
    /// </summary>
    /// <typeparam name="T">Execute和CanExecute的参数类型，要能执行强制转换</typeparam>
    public class DelegateCommand<T> : ICommand
    {
        /*---------------------------------------- Fields ---------------------------------------*/
        /// <summary>
        /// 干活的方法
        /// </summary>
        private readonly Action<T> _ExecuteMethod;
        /// <summary>
        /// 判断可以干活的方法
        /// </summary>
        private readonly Func<T, bool> _CanExecuteMethod;
        /// <summary>
        /// 命令正在执行标记
        /// </summary>
        private bool _IsExecuting = false;

        /*------------------------------------- Constructors ------------------------------------*/
        /// <summary>
        /// 主构造器
        /// </summary>
        /// <param name="executeMethod">干活的方法</param>
        /// <param name="canExecuteMethod">判断可以干活的方法</param>
        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod) {
            _ExecuteMethod = executeMethod ?? throw new ArgumentNullException("execute 不能为空");
            _CanExecuteMethod = canExecuteMethod;
        }

        /// <summary>
        /// 简化判断方法的构造器
        /// </summary>
        /// <param name="execute">干活的方法</param>
        public DelegateCommand(Action<T> execute) : this(execute, null) { }

        /*-------------------------------------- Properties -------------------------------------*/
        /// <summary>
        /// 可执行改变事件
        /// </summary>
        public event EventHandler CanExecuteChanged;


        /*------------------------------------ Public Methods -----------------------------------*/
        /// <summary>
        /// 检查是否可以执行命令
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) {
            if (_CanExecuteMethod != null)
                return !_IsExecuting && _CanExecuteMethod((T)parameter);
            return true;
        }

        /// <summary>
        /// 执行命令操作
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) {
            _IsExecuting = true;
            try {
                RaiseCanExecuteChanged();
                _ExecuteMethod((T)parameter);
            }
            finally {
                _IsExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// 引发可执行改变事件
        /// </summary>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    }
}
