using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManager(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IResult> AddRole(RegisterDto registerDto, string role)
        {
            var user = _mapper.Map<User>(registerDto);
            var result = await _userManager.AddToRoleAsync(user, role);

            if (result.Succeeded)
                return new SuccessResult("Rol Ekleme İşlemi Başarıyla Gerçekleştirildi.");

            return new ErrorResult("Rol Ekleme Sırasında Beklenmedik Bir Hata ile Karşılaşıldı.");
        }

        public async Task<IResult> CreateUser(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            var result = await _userManager.CreateAsync(user,registerDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult DeleteUser(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            _userRepository.Delete(user);
            _unitOfWork.Commit();
            return new SuccessResult("Kullanıcı Silindi.");
        }

        public async Task<IDataResult<List<UserDto>>> GetAll()
        {
            var userList = _mapper.Map<List<UserDto>>(await _userRepository.GetAll());

            if (userList != null) 
                return new SuccessDataResult<List<UserDto>>(userList);

            return new ErrorDataResult<List<UserDto>>();
        }

        public User GetUserSession()
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = _userManager.FindByNameAsync(userName).Result;
            return user;
        }

        public async Task<IResult> UpdateUser(UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id);
            
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.UserName = userDto.UserName;
            user.NationalityId = userDto.NationalityId;
            user.LicensePlate = userDto.LicensePlate;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return new SuccessResult("Kullanıcı Bilgileri Başarıyla Güncellenmiştir.");
            return new ErrorResult("Güncelleme Sırasında Hata!");
        }

        public async Task<IDataResult<UserDto>> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
                return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(user));

            return new ErrorDataResult<UserDto>();
        }
    }
}
