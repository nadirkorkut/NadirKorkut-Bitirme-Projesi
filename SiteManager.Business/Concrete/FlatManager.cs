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
    public class FlatManager : IFlatService
    {
        private readonly IFlatRepository _flatRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FlatManager(IFlatRepository flatRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _flatRepository = flatRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateFlatDto>> Add(CreateFlatDto createDto)
        {
            var flat = _mapper.Map<Flat>(createDto);
            await _flatRepository.Add(flat);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<CreateFlatDto>(createDto);
        }

        public IResult Delete(int id)
        {
            var flat = _flatRepository.GetById(id).Result;
            _flatRepository.Delete(flat);
            _unitOfWork.Commit();
            return new SuccessResult($"{flat.FlatNumber} Numaralı Daire Başarıyla Silinmiştir.");
        }

        public async Task<IDataResult<List<FlatDto>>> GetAll()
        {
            var flat = _mapper.Map<List<FlatDto>>(await _unitOfWork.Flats.GetAll());

            if (flat != null)
                return new SuccessDataResult<List<FlatDto>>(flat);

            return new ErrorDataResult<List<FlatDto>>();
        }

        public async Task<IDataResult<List<FlatDto>>> GetAllFlats()
        {
            var flats = await _flatRepository.GetAllFlats();
            var dtos = flats.Select(f => new FlatDto()
            {
                Id = f.Id,
                UserName = f.User.UserName,
                BuildingName = f.Building.BuildingName,
                FlatNumber = f.FlatNumber,
                TypeOfFlat = f.TypeOfFlat,
                IsEmpty = f.IsEmpty
            }).ToList();
            return new SuccessDataResult<List<FlatDto>>(dtos);
        }

        public async Task<IDataResult<FlatDto>> GetById(int id)
        {
            var flat = _mapper.Map<FlatDto>(await _unitOfWork.Flats.GetById(id));

            if (flat != null)
                return new SuccessDataResult<FlatDto>(flat);

            return new ErrorDataResult<FlatDto>();
        }

        public IDataResult<UpdateFlatDto> Update(UpdateFlatDto dto)
        {
            var flat = _mapper.Map<Flat>(dto);
            _flatRepository.Update(flat);
            _unitOfWork.Commit();
            return new SuccessDataResult<UpdateFlatDto>(dto);
        }
    }
}
