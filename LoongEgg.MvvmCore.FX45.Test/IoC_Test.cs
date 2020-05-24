using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoongEgg.MvvmCore.FX45.Test
{
    [TestClass]
    public class IoC_Test
    {
        class TestViewModel : ViewModel
        {

            public int TestProperty
            {
                get => _TestProperty;
                set => SetProperty(ref _TestProperty, value);
            }
            private int _TestProperty;

            internal static int _Count = 0;

            public TestViewModel()
            {
                _Count += 1;
            }
        }

        [TestMethod]
        public void GetSingleton()
        {
            var vm1 = IoC.GetSingleton<TestViewModel>();
            var vm2 = IoC.GetSingleton<TestViewModel>();

            Assert.AreEqual(1, IoC.GetViewModels().Count);
            Assert.ReferenceEquals(vm1, vm2);
        }
    }
}
