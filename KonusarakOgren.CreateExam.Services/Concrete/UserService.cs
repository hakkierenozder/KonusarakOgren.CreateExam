using KonusarakOgren.CreateExam.Data.Abstract;
using KonusarakOgren.CreateExam.Entities.Dtos;
using KonusarakOgren.CreateExam.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetUserDto> GetAsync(string email, string password)
        {
            var user = await _unitOfWork.Users.GetAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                return new GetUserDto
                {
                    Email = user.Email,
                    Password = user.Password
                };
            }
            return null;

        }
    }
}
