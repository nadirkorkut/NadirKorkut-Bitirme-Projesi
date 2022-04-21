using SiteManager.Business.DTOs;
using SiteManager.Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.Business.Abstract
{
    public interface IExpenseService
    {
        Task<IDataResult<ExpenseDto>> GetById(int id);
        Task<IDataResult<List<ExpenseDto>>> GetAll();
        Task<IDataResult<CreateExpenseDto>> Add(CreateExpenseDto createDto);
        IResult Delete(int id);
        IDataResult<UpdateExpenseDto> Update(UpdateExpenseDto updateDto);
        Task<IDataResult<List<ExpenseDto>>> GetAllExpenses();
    }
}
