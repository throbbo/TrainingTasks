using System;
using System.Collections.Generic;

namespace TrainingTasks2.DIP
{
    public interface IBirthdayService
    {
        List<IBirthday> GetAllBirthdays();
    }

    public class BirthdayService : IBirthdayService
    {
        public List<IBirthday> GetAllBirthdays()
        {
            return new List<IBirthday>()
                       {
                           new Birthday() {Name = "David", Date = new DateTime(1981, 2, 8)},
                           new Birthday() {Name = "Jeremy", Date = new DateTime(1965, 9, 23)},
                           new Birthday() {Name = "Matt", Date = new DateTime(1972, 11, 3)},
                           new Birthday() {Name = "Bill", Date = new DateTime(1991, 9, 23)}
                       };
        }
    }
}