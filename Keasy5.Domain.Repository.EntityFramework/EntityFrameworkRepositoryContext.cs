using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keasy5.Domain.Repositories;

namespace Keasy5.Domain.Repository.EntityFramework
{
    public class EntityFrameworkRepositoryContext : RepositoryContext, IEntityFrameworkRepositoryContext
    {
        private readonly ThreadLocal<ByteartRetailDbContext> localCtx = 
            new ThreadLocal<ByteartRetailDbContext>(() => new ByteartRetailDbContext());

        public EntityFrameworkRepositoryContext() { }

        public override void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Set<TAggregateRoot>().Remove(obj);
            Committed = false;
        }

        public override void RegisterModified<TAggregateRoot>(TAggregateRoot obj)
        {
            //BEGIN:Modify code by Keasy5:
            //EntityFramework.dll, v5.0.0.0中State的类型是System.Data.Entity.dll, v4.0.0.0程序集中的System.Data.EntityState类型
            //EntityFramework.dll, v6.0.0.0中State的类型是EntityFramework.dll, v6.0.0.0程序集中的System.Data.EntityState类型
            //由于EF版本的问题,将
            //   localCtx.Value.Entry<TAggregateRoot>(obj).State = System.Data.EntityState.Modified;
            //改为：
            localCtx.Value.Entry<TAggregateRoot>(obj).State = EntityState.Modified;
            //END:Modify code by Keasy5

            Committed = false;
        }

        public override void RegisterNew<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Set<TAggregateRoot>().Add(obj);
            Committed = false;
        }

        public override bool DistributedTransactionSupported
        {
            get { return true; }
        }

        public override void Rollback()
        {
            Committed = false;
        }

        protected override void DoCommit()
        {
            if (!Committed)
            {
                var validationErrors = localCtx.Value.GetValidationErrors();
                var count = localCtx.Value.SaveChanges();
                Committed = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Note by Keasy5:
                //在EFContext销毁前，自动提交事务，以防忘记人工调用Commit()。
                if (!Committed)
                    Commit();
                localCtx.Value.Dispose();
                localCtx.Dispose();
                base.Dispose(disposing);
            }
        }

        #region IEntityFrameworkRepositoryContext Members

        public DbContext Context
        {
            get { return localCtx.Value; }
        }

        #endregion
    }
}
