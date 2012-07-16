using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks2.DIP
{
    public interface IBirthdayCalculator
    {
        List<IBirthday> GetTodaysBirthdays();
    }

    public class BirthdayCalculator : IBirthdayCalculator
    {
        private readonly List<IBirthday> _birthdays;

        public BirthdayCalculator()
        {
            IBirthdayService birthdayService = new BirthdayService();
            _birthdays = birthdayService.GetAllBirthdays();
        }

        public List<IBirthday> Birthdays
        {
            get { return _birthdays; }
        }

        public List<IBirthday> GetTodaysBirthdays()
        {
            return _birthdays
                .Where(bd => bd.Date == DateTime.Now.Date)
                .ToList();
        }
    }
}
