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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired();

            builder.ToTable("Users");

            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Hakkı Eren",
                    LastName = "Özder",
                    UserName = "hakkieren",
                    Password = "123456"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Ahmet",
                    LastName = "Aydın",
                    UserName = "ahmetaydin",
                    Password = "a12345"
                }
                );
        }
    }
}
