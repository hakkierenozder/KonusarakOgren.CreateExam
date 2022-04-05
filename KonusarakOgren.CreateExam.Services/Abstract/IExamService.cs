using KonusarakOgren.CreateExam.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Services.Abstract
{
    public interface IExamService
    {
        Task<GetExamDto> GetAsync(int examId);
        Task<IList<ListExamDto>> GetAllAsync();
        Task<GetExamDto> AddAsync(ExamAddDto examAddDto, int userId);
        Task DeleteAsync(int examId);


    }
}
