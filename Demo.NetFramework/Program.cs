using LoongEgg.MvvmCore;
using System;
using System.ComponentModel;
using System.Linq;

namespace Demo.NetFramework
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            string name = string.Empty;

            if (args == null || !args.Any()) {
                while (string.IsNullOrEmpty(name)) {
                    Console.WriteLine("hello who are you?");
                    name = Console.ReadLine();
                }
            }
            else {
                name = args[0];
            }
            Console.WriteLine($"Welcome <{name}> to loongegg's magic kindom!");

            var keeper = new Keeper(name);
            var monkey = new Monkey();
            var dog = new Dog();
            var cat = new Cat();
            keeper.PropertyChanged += monkey.Observe;
            keeper.PropertyChanged += dog.Observe;
            keeper.PropertyChanged += cat.Observe;

            while (true) {
                Console.WriteLine($"What food do you want to feed the animal?");
                keeper.Food = Console.ReadLine();
            }
        }

    }

    class Keeper : ObservableObject
    {
        public string Name { get; set; }

        public string Food {
            get => _Food;
            set => SetProperty(ref _Food, value);
        }
        private string _Food = "Peach";

        public Keeper(string name) {
            Name = name;
        }
    }

    abstract class Animal
    {
        public void Observe(object sender, PropertyChangedEventArgs e) {
            if (sender is Keeper k)
                Eat(k.Food);
        }

        public virtual void Eat(string food)
            => Console.WriteLine($"{ this.GetType().Name} eat -> {food}");
    }

    class Monkey : Animal { }
    class Dog : Animal { }
    class Cat : Animal {
        public override void Eat(string food) {
            if (food.ToLower() == "fish") {
                base.Eat(food);
            }
            else {
                 Console.WriteLine("Cat: Stupid human!!!");
            }
        }
    }
}
