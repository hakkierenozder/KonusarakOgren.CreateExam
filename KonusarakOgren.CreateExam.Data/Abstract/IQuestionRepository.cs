using KonusarakOgren.CreateExam.Entities.Concrete;
using KonusarakOgren.CreateExam.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Data.Abstract
{
    public interface IQuestionRepository : IEntityRepository<Question>
    {
    }
}
