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
    public class BuildingManager : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BuildingManager(IBuildingRepository buildingRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<BuildingDto>> Add(BuildingDto dto)
        {
            var building = _mapper.Map<Building>(dto);
            await _buildingRepository.Add(building);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<BuildingDto>(dto);
        }

        public IResult Delete(int id)
        {
            var building = _buildingRepository.GetById(id).Result;
            _buildingRepository.Delete(building);
            _unitOfWork.Commit();
            return new SuccessResult($"{building.BuildingName} Adlı Bina Başarıyla Silinmiştir.");
        }
        public async Task<IDataResult<List<BuildingDto>>> GetAll()
        {
            var building = _mapper.Map<List<BuildingDto>>(await _unitOfWork.Buildings.GetAll());

            if (building != null)
                return new SuccessDataResult<List<BuildingDto>>(building);

            return new ErrorDataResult<List<BuildingDto>>();
        }

        public async Task<IDataResult<BuildingDto>> GetById(int id)
        {
            var building = _mapper.Map<BuildingDto>(await _unitOfWork.Buildings.GetById(id));

            if (building != null)
                return new SuccessDataResult<BuildingDto>(building);

            return new ErrorDataResult<BuildingDto>();
        }

        public IDataResult<BuildingDto> Update(BuildingDto dto)
        {
            var building = _mapper.Map<Building>(dto);
            _buildingRepository.Update(building);
            _unitOfWork.Commit();
            return new SuccessDataResult<BuildingDto>(dto);
        }
    }
}
