using KonusarakOgren.CreateExam.Data.Abstract;
using KonusarakOgren.CreateExam.Data.Concrete.EntityFramework.Contexts;
using KonusarakOgren.CreateExam.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CreateExamContext _context;
        private EfExamRepository _examRepository;
        private EfQuestionRepository _questionRepository;
        private EfUserRepository _userRepository;

        public UnitOfWork(CreateExamContext context)
        {
            _context = context;
        }


        public IExamRepository Exams => _examRepository ??= new EfExamRepository(_context);
        public IQuestionRepository Questions => _questionRepository ??= new EfQuestionRepository(_context);

        public IUserRepository Users => _userRepository ??= new EfUserRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
