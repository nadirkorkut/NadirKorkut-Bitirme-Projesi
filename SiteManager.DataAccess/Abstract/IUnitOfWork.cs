using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.DataAccess.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAnnouncementRepository Announcements { get; }
        IBuildingRepository Buildings { get; }

        IExpenseRepository Expenses { get; }

        IExpenseTypeRepository ExpenseTypes { get; }

        IFlatRepository Flats { get; }

        IMessageRepository Messages { get; }

        IUserRepository Users { get; }
        Task CommitAsync();
        void Commit();
    }
}
