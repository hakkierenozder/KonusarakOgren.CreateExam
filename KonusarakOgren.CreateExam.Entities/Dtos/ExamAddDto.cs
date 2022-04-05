﻿using KonusarakOgren.CreateExam.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Entities.Dtos
{
    public class ExamAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public IList<Question> Questions { get; set; }
    }
}
