using SiteManager.Business.DTOs;
using SiteManager.Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.Business.Abstract
{
    public interface IFlatService
    {
        Task<IDataResult<FlatDto>> GetById(int id);
        Task<IDataResult<List<FlatDto>>> GetAll();
        Task<IDataResult<CreateFlatDto>> Add(CreateFlatDto createDto);
        IResult Delete(int id);
        IDataResult<UpdateFlatDto> Update(UpdateFlatDto dto);
        Task<IDataResult<List<FlatDto>>> GetAllFlats();
    }
}
