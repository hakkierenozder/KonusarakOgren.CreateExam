using KonusarakOgren.CreateExam.Data.Abstract;
using KonusarakOgren.CreateExam.Entities.Concrete;
using KonusarakOgren.CreateExam.Entities.Dtos;
using KonusarakOgren.CreateExam.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Services.Concrete
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetExamDto> AddAsync(ExamAddDto examAddDto, int userId)
        {
            IList<Question> questions = examAddDto.Questions;
            foreach (var question in questions)
            {
                questions.Add(new Question
                {
                    Content = question.Content,
                    ExamId = question.ExamId,
                    AnswerA = question.AnswerA, 
                    AnswerB = question.AnswerB,
                    AnswerC = question.AnswerC,
                    AnswerD = question.AnswerD,
                    CorrectAnswer = question.CorrectAnswer,
                    
                });
            }
            var exam = new Exam
            {
                Title = examAddDto.Title,
                Content = examAddDto.Content,
                Date = examAddDto.Date,
                UserId = userId,
                Questions = questions
            };
            await _unitOfWork.Exams.AddAsync(exam);
            await _unitOfWork.SaveAsync();

            return new GetExamDto
            {
                Content = exam.Content,
                Questions = exam.Questions.ToList(),
                Title = exam.Title
            };
        }

        public async Task DeleteAsync(int examId)
        {
            var result = await _unitOfWork.Exams.GetAsync(e => e.Id == examId);
            if (result != null)
            {
                await _unitOfWork.Exams.DeleteAsync(result);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<IList<ListExamDto>> GetAllAsync()
        {
            try
            {
                var exams = await _unitOfWork.Exams.GetAllAsync();
                if (exams.Count > -1)
                {
                    IList<ListExamDto> list = new List<ListExamDto>();
                    foreach (var item in exams)
                    {
                        list.Add(new ListExamDto
                        {
                            Id = item.Id,
                            Date = item.Date,
                            Title = item.Title
                        });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
            
            return null;
        }

        public async Task<GetExamDto> GetAsync(int examId)
        {
            var exam = await _unitOfWork.Exams.GetAsync(e => e.Id == examId);
            if (exam != null)
            {
                exam.Questions = await _unitOfWork.Questions.GetAllAsync(q => q.ExamId == examId);

                return new GetExamDto
                {
                    Content = exam.Content,
                    Questions = exam.Questions.ToList(),
                    Title = exam.Title
                };
            }
            return null;
        }
    }
}
