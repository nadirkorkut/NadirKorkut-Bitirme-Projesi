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
    public class MessageManager : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageManager(IMessageRepository messageRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<MessageDto>> Add(MessageDto dto)
        {
            var message = _mapper.Map<Message>(dto);
            await _messageRepository.Add(message);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<MessageDto>(dto);
        }

        public IResult Delete(int id)
        {
            var message = _messageRepository.GetById(id).Result;
            _messageRepository.Delete(message);
            _unitOfWork.Commit();
            return new SuccessResult("Mesajınız Başarıyla Silinmiştir.");
        }

        public async Task<IDataResult<List<MessageDto>>> GetAll()
        {
            var message = _mapper.Map<List<MessageDto>>(await _unitOfWork.Messages.GetAll());

            if (message != null)
                return new SuccessDataResult<List<MessageDto>>(message);

            return new ErrorDataResult<List<MessageDto>>();
        }

        public async Task<IDataResult<MessageDto>> GetById(int id)
        {
            var message = _mapper.Map<MessageDto>(await _unitOfWork.Messages.GetById(id));

            if (message != null)
                return new SuccessDataResult<MessageDto>(message);

            return new ErrorDataResult<MessageDto>();
        }

        public IDataResult<MessageDto> Update(MessageDto dto)
        {
            var message = _mapper.Map<Message>(dto);
            _messageRepository.Update(message);
            _unitOfWork.Commit();
            return new SuccessDataResult<MessageDto>(dto);
        }
    }
}
