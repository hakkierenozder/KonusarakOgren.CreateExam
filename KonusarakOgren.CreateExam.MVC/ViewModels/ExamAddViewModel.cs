using KonusarakOgren.CreateExam.Entities.Concrete;

namespace KonusarakOgren.CreateExam.MVC.ViewModels
{
    public class ExamAddViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Question Question1 { get; set; }
        public Question Question2 { get; set; }
        public Question Question3 { get; set; }
        public Question Question4 { get; set; }
    }
}
