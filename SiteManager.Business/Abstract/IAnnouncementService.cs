using SiteManager.Business.DTOs;
using SiteManager.Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.Business.Abstract
{
    public interface IAnnouncementService
    {
        Task<IDataResult<AnnouncementDto>> GetById(int id);
        Task<IDataResult<List<AnnouncementDto>>> GetAll();
        Task<IDataResult<AnnouncementDto>> Add(AnnouncementDto dto);
        IResult Delete(int id);
        IDataResult<AnnouncementDto> Update(AnnouncementDto dto);
    }
}
