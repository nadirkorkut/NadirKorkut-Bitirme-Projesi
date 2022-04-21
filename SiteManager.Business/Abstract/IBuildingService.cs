using SiteManager.Business.DTOs;
using SiteManager.Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.Business.Abstract
{
    public interface IBuildingService
    {
        Task<IDataResult<BuildingDto>> GetById(int id);
        Task<IDataResult<List<BuildingDto>>> GetAll();
        Task<IDataResult<BuildingDto>> Add(BuildingDto dto);
        IResult Delete(int id);
        IDataResult<BuildingDto> Update(BuildingDto dto);
    }
}
