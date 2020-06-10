/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/5/13 14:46:16
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */

using System.Reflection;

namespace LoongEgg.MvvmCore.FX45
{
    /// <summary>
    /// 配置接口
    /// </summary>
    public interface IAssembleConfig
    {
        /// <summary>
        /// 目标程序集
        /// </summary>
        Assembly Assembly { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        string Namespace { get; set; }
    }
}
