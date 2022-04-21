using AutoMapper;
using SiteManager.Business.Abstract;
using SiteManager.Business.DTOs;
using SiteManager.Core.Utilities.Results;
using SiteManager.DataAccess.Abstract;
using SiteManager.Domain.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManager.Business.Concrete
{
    public class ExpenseManager : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseManager(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<CreateExpenseDto>> Add(CreateExpenseDto createDto)
        {
            var expense = _mapper.Map<Expense>(createDto);
            await _expenseRepository.Add(expense);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<CreateExpenseDto>(createDto);
        }

        public IResult Delete(int id)
        {
            var expense = _expenseRepository.GetById(id).Result;
            _expenseRepository.Delete(expense);
            _unitOfWork.Commit();
            return new SuccessResult("Fatura Silme İşleminiz Başarıyla Gerçekleştirilmiştir.");
        }

        public async Task<IDataResult<List<ExpenseDto>>> GetAll()
        {
            var expense = _mapper.Map<List<ExpenseDto>>(await _unitOfWork.Expenses.GetAll());

            if (expense != null)
                return new SuccessDataResult<List<ExpenseDto>>(expense);

            return new ErrorDataResult<List<ExpenseDto>>();
        }

        public async Task<IDataResult<ExpenseDto>> GetById(int id)
        {
            var expense = _mapper.Map<ExpenseDto>(await _unitOfWork.Expenses.GetById(id));

            if (expense != null)
                return new SuccessDataResult<ExpenseDto>(expense);

            return new ErrorDataResult<ExpenseDto>();
        }

        public IDataResult<UpdateExpenseDto> Update(UpdateExpenseDto updateDto)
        {
            var expense = _mapper.Map<Expense>(updateDto);
            _expenseRepository.Update(expense);
            _unitOfWork.Commit();
            return new SuccessDataResult<UpdateExpenseDto>(updateDto);
        }
        public async Task<IDataResult<List<ExpenseDto>>> GetAllExpenses()
        {
            var expenses = await _expenseRepository.GetAllExpenses();
            var dtos = expenses.Select(x => new ExpenseDto
            {
                Id = x.Id,
                UserName = x.Flat.User.UserName,
                FlatNumber = x.Flat.FlatNumber,
                TypeName = x.ExpenseType.TypeName,
                Price = x.Price,
                InvoiceDate = x.InvoiceDate,
                IsPayment = x.IsPayment
            }).ToList();

            return new SuccessDataResult<List<ExpenseDto>>(dtos);
        }
    }
}
