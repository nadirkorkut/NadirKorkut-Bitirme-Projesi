using SiteManager.Business.DTOs;
using SiteManager.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.Business.Abstract
{
    public interface IMessageService
    {
        Task<IDataResult<MessageDto>> GetById(int id);
        Task<IDataResult<List<MessageDto>>> GetAll();
        Task<IDataResult<MessageDto>> Add(MessageDto dto);
        IResult Delete(int id);
        IDataResult<MessageDto> Update(MessageDto dto);
    }
}
