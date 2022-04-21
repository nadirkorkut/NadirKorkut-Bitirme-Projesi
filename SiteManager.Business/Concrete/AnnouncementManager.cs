using AutoMapper;
using SiteManager.Business.Abstract;
using SiteManager.Business.DTOs;
using SiteManager.Core.Utilities.Results;
using SiteManager.DataAccess.Abstract;
using SiteManager.Domain.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.Business.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnnouncementManager(IAnnouncementRepository announcementRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _announcementRepository = announcementRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<AnnouncementDto>> Add(AnnouncementDto dto)
        {
            var announcement = _mapper.Map<Announcement>(dto);
            await _announcementRepository.Add(announcement);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<AnnouncementDto>(dto);
        }

        public IResult Delete(int id)
        {
            var announcement = _announcementRepository.GetById(id).Result;
            _announcementRepository.Delete(announcement);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public async Task<IDataResult<List<AnnouncementDto>>> GetAll()
        {
            var announcement = _mapper.Map<List<AnnouncementDto>>(await _unitOfWork.Announcements.GetAll());

            if (announcement != null)
                return new SuccessDataResult<List<AnnouncementDto>>(announcement);

            return new ErrorDataResult<List<AnnouncementDto>>();
        }

        public async Task<IDataResult<AnnouncementDto>> GetById(int id)
        {
            var announcement = _mapper.Map<AnnouncementDto>(await _unitOfWork.Announcements.GetById(id));

            if (announcement != null)
                return new SuccessDataResult<AnnouncementDto>(announcement);

            return new ErrorDataResult<AnnouncementDto>();
        }

        public IDataResult<AnnouncementDto> Update(AnnouncementDto dto)
        {
            var announcement = _mapper.Map<Announcement>(dto);
            _announcementRepository.Update(announcement);
            _unitOfWork.Commit();
            return new SuccessDataResult<AnnouncementDto>(dto);
        }
    }
}
