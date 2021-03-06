using KonusarakOgren.CreateExam.Data.Abstract;
using KonusarakOgren.CreateExam.Entities.Concrete;
using KonusarakOgren.CreateExam.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Data.Concrete.EntityFramework.Repositories
{
    public class EfQuestionRepository : EfEntityRepository<Question>, IQuestionRepository
    {
        public EfQuestionRepository(DbContext context) : base(context)
        {
        }
    }
}
