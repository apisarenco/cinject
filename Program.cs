using System;

namespace Cinject
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new Kernel();
            kernel.RegisterModule(new MyModule());

            var foo = kernel.Get<IFoo>();
        }
    }

    class MyModule : BaseModule
    {
        public MyModule() : base() {
            this.Map<IFoo>().To<Foo>();
        }
    }

    interface IFoo {

    }

    class Foo {

    }
}
