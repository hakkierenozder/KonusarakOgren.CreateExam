using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IExamRepository Exams { get; }
        IQuestionRepository Questions { get; }
        IUserRepository Users { get; }
        Task<int> SaveAsync();
    }
}
