using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LoongEgg.MvvmCore.FX45
{
    /// <summary>
    /// 会引发属性改变事件通知的对象
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// 属性发生变化时，向外部关注了这个事件的人“打电话”
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引发属性改变事件
        /// </summary>
        /// <param name="propertyName">改变了的属性的名称</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// 属性设置器，如果设置的确实是一个新值，会引发属性改变事件
        /// </summary>
        ///     <typeparam name="T">目标属性的类型</typeparam>
        ///     <param name="target">待设置的目标</param>
        ///     <param name="value">“新”的值</param>
        ///     <param name="propertyName">[不要设置]待改变的属性的名称</param>
        /// <returns>
        ///     [True ]->新值已设置，并引发了属性改变事件
        ///     [False]->新值未设置，不引发属性改变事件
        /// </returns>
        protected bool SetProperty<T>(ref T target, T value, [CallerMemberName] string propertyName = null) {
            if (EqualityComparer<T>.Default.Equals(target, value))
                return false;

            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
