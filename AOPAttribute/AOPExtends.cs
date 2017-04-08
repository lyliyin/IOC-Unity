using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using EF;
namespace AOPAttribute
{
    /// <summary>
    /// 实现特性
    /// </summary>
    public class UserHandlerHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Category user = input.Inputs[0] as Category;

            if (user.Id == 0)
            {
                return input.CreateExceptionMethodReturn(new Exception("密码不能为空"));
            }

            IMethodReturn iMethodResult = getNext()(input, getNext);
            return iMethodResult;
        }

        public int Order
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 特性
    /// </summary>
    public class UserHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            ICallHandler handler = new UserHandlerHandler() { Order = this.Order };
            return handler;
        }
    }


    public class LogHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("*************日志特性*********************");
            IMethodReturn iMethodReturn = getNext()(input, getNext);
            return iMethodReturn;
        }

        public int Order { get; set; }
    }

    /// <summary>
    /// 日志特性
    /// </summary>
    public class LogHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            ICallHandler handler = new LogHandler() { Order = this.Order };
            return handler;
        }
    }
}
