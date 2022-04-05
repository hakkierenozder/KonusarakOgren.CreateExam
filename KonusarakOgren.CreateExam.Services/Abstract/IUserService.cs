using KonusarakOgren.CreateExam.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Services.Abstract
{
    public interface IUserService
    {
        Task<GetUserDto> GetAsync(string email,string password);
    }
}
