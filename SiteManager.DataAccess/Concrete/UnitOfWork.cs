using SiteManager.DataAccess.Abstract;
using SiteManager.DataAccess.Concrete.EntityFramework.Contexts;
using SiteManager.DataAccess.Concrete.EntityFramework.Repositories;
using System.Threading.Tasks;

namespace SiteManager.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private SiteManagerDbContext _context;
        private EfAnnouncementRepository _announcementRepository;
        private EfBuildingReposiyory _buildingReposiyory;
        private EfExpenseRepository _expenseRepository;
        private EfExpenseTypeRepository _expenseTypeRepository;
        private EfFlatRespository _flatRepository;
        private EfMessageRepository _messageRepository;
        private EfUserRepository _userRepository;

        public UnitOfWork(SiteManagerDbContext context)
        {
            _context = context;
        }

        public IAnnouncementRepository Announcements => _announcementRepository = _announcementRepository ?? new EfAnnouncementRepository(_context);

        public IBuildingRepository Buildings => _buildingReposiyory = _buildingReposiyory ?? new EfBuildingReposiyory(_context);

        public IExpenseRepository Expenses => _expenseRepository = _expenseRepository ?? new EfExpenseRepository(_context);

        public IExpenseTypeRepository ExpenseTypes => _expenseTypeRepository = _expenseTypeRepository ?? new EfExpenseTypeRepository(_context);

        public IFlatRepository Flats => _flatRepository =  _flatRepository ?? new EfFlatRespository(_context);

        public IMessageRepository Messages => _messageRepository = _messageRepository ?? new EfMessageRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new EfUserRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
