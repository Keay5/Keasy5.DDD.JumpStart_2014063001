using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keasy5.Infrastructure.Transactions
{
    public interface ITransactionCoordinator : IUnitOfWork, IDisposable
    {
    }
}
