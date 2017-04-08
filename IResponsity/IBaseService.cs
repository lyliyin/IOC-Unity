using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AOPAttribute;

namespace IResponsity
{

    [UserHandlerAttribute(Order = 1)]
    [LogHandlerAttribute(Order = 2)]
    public interface IBaseService
    {
        T Insert<T>(T t) where T : class;
        List<T> GetList<T>(Expression<Func<T, bool>> express, int PageIndex, int PageSize) where T : class;
        T GetInfo<T>(Expression<Func<T, bool>> express) where T : class;

        void Delete<T>(T t) where T : class;
    }
}
