using SiteManager.Business.DTOs;
using SiteManager.Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.Business.Abstract
{
    public interface IExpenseTypeService
    {
        Task<IDataResult<ExpenseTypeDto>> GetById(int id);
        Task<IDataResult<List<ExpenseTypeDto>>> GetAll();
        Task<IDataResult<ExpenseTypeDto>> Add(ExpenseTypeDto dto);
        IResult Delete(int id);
        IDataResult<ExpenseTypeDto> Update(ExpenseTypeDto dto);
    }
}
