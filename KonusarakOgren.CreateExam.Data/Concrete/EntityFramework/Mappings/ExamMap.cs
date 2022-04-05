using KonusarakOgren.CreateExam.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.Data.Concrete.EntityFramework.Mappings
{
    public class ExamMap : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Date).IsRequired();

            builder.HasOne<User>(e=>e.User).WithMany(u=>u.Exams).HasForeignKey(e => e.UserId);

            builder.ToTable("Exams");
        }
    }
}
