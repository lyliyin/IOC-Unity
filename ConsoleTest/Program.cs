using EF;
using IResponsity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Responsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Configuration.Install;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Category category = new Category()
            {
                CategoryLevel = 1,
                Code = "001",
                Name = "内科",
                ParentCode = "",
                State = 0,
            };


            IBaseService Service = Container.GetInstances().Resolve<IBaseService>();

            Service = Container.GetInstances().Resolve<IBaseService>();
          
            Service.Insert(category);


            Expression<Func<Category, bool>> express = t => t.Id > 1 && t.State > 0;

            Category entity = Service.GetInfo<Category>(express);

            Console.ReadLine();

        }


        //一般放在Golbal 里面
        public class Container
        {
            private static Container _Instances = null;
            private static IUnityContainer _Container = null;

            public static Container GetInstances()
            {
                if (_Instances == null)
                {
                    _Instances = new Container();
                    _Container = new UnityContainer();
                    _Container.RegisterType<IBaseService, BaseServiceImpl>();
                    _Container.AddNewExtension<Interception>().Configure<Interception>().SetInterceptorFor<IBaseService>(new InterfaceInterceptor());
                }

                return _Instances;
            }

            public T Resolve<T>()
            {
                return _Container.Resolve<T>();
            }
        }
    }
}
