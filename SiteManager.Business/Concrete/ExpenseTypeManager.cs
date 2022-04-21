using AutoMapper;
using SiteManager.Business.Abstract;
using SiteManager.Business.DTOs;
using SiteManager.Core.Utilities.Results;
using SiteManager.DataAccess.Abstract;
using SiteManager.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.Business.Concrete
{
    public class ExpenseTypeManager : IExpenseTypeService
    {
        private readonly IExpenseTypeRepository _expenseTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseTypeManager(IExpenseTypeRepository expenseTypeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _expenseTypeRepository = expenseTypeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<ExpenseTypeDto>> Add(ExpenseTypeDto dto)
        {
            var expenseType = _mapper.Map<ExpenseType>(dto);
            await _expenseTypeRepository.Add(expenseType);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<ExpenseTypeDto>(dto);
        }

        public IResult Delete(int id)
        {
            var expenseType = _expenseTypeRepository.GetById(id).Result;
            _expenseTypeRepository.Delete(expenseType);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public async Task<IDataResult<List<ExpenseTypeDto>>> GetAll()
        {
            var expenseType = _mapper.Map<List<ExpenseTypeDto>>(await _unitOfWork.ExpenseTypes.GetAll());

            if (expenseType != null)
                return new SuccessDataResult<List<ExpenseTypeDto>>(expenseType);

            return new ErrorDataResult<List<ExpenseTypeDto>>();
        }

        public async Task<IDataResult<ExpenseTypeDto>> GetById(int id)
        {
            var expenseType = _mapper.Map<ExpenseTypeDto>(await _unitOfWork.ExpenseTypes.GetById(id));

            if (expenseType != null)
                return new SuccessDataResult<ExpenseTypeDto>(expenseType);

            return new ErrorDataResult<ExpenseTypeDto>();
        }

        public IDataResult<ExpenseTypeDto> Update(ExpenseTypeDto dto)
        {
            var expenseType = _mapper.Map<ExpenseType>(dto);
            _expenseTypeRepository.Update(expenseType);
            _unitOfWork.Commit();
            return new SuccessDataResult<ExpenseTypeDto>(dto);
        }
    }
}
