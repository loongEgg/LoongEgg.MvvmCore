using System.Collections.Generic;
using System.Linq;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/5/20 23:28:53
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.MvvmCore
{
    /// <summary>
    /// 依赖注入容器
    /// </summary>
    public static class IoC
    {
        private volatile static Dictionary<string, ViewModel> _Instances = new Dictionary<string, ViewModel>();

        /// <summary>
        /// 获取所有ViewModel的实例
        /// </summary>
        /// <returns>ViewModel集合的副本</returns>
        public static List<ViewModel> GetViewModels() => _Instances.Values.ToList();

        private static readonly object _Lock = new object();
        /// <summary>
        /// 获取指定类型<see cref="ViewModel"/>的单例
        /// </summary>
        /// <typeparam name="T"><see cref="ViewModel"/>的派生类</typeparam>
        /// <returns>指定的ViewModel派生类</returns>
        public static T GetSingleton<T>() where T : ViewModel, new ()
        {
            string name = typeof(T).Name;
            if (!_Instances.Keys.Contains(name))
            {
                lock (_Lock)
                {
                    if (!_Instances.Keys.Contains(name))
                    {
                        _Instances.Add(name, new T());
                    }
                }
            }
            return _Instances[name] as T;
        }
         
    }
}
