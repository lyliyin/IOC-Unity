using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Transactions;
using IResponsity;


namespace Responsity
{
    public class BaseServiceImpl : IBaseService
    {
        public T Insert<T>(T t) where T : class
        {
            using (codeFirstEntities entity = new codeFirstEntities())
            {
                entity.Set<T>().Add(t);
                entity.SaveChanges();
                return t;
            }
        }

        //得到单个实体信息
        public T GetInfo<T>(Expression<Func<T, bool>> express) where T : class
        {
            using (codeFirstEntities context = new codeFirstEntities())
            {
                return context.Set<T>().FirstOrDefault<T>(express);
            }
        }

        //得到单个实体信息
        public List<T> GetList<T>(Expression<Func<T, bool>> express, int PageIndex, int PageSize) where T : class
        {
            using (codeFirstEntities context = new codeFirstEntities())
            {
                return context.Set<T>().Where(express).Skip(PageSize * PageSize).Take(PageSize).ToList();
            }
        }


        public TransactionScope Scope()
        {
            return new TransactionScope();
        }

        public void Delete<T>(T t) where T : class
        {
            using (codeFirstEntities context = new codeFirstEntities())
            {
                context.Set<T>().Remove(t);
            }
        }
    }
}
