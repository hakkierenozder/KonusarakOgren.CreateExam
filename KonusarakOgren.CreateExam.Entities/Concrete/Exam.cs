using KonusarakOgren.CreateExam.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Entities.Concrete
{
    public class Exam : BaseEntity,IEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public ICollection<Question> Questions { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
