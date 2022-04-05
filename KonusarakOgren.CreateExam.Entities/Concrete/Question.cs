using KonusarakOgren.CreateExam.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Entities.Concrete
{
    public class Question : BaseEntity, IEntity
    {
        public string Content { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }

        public string CorrectAnswer { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
