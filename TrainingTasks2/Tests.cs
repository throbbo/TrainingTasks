using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TrainingTasks2.DIP;
using TrainingTasks2.LSP;

namespace TrainingTasks2
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestDip()
        {
            IBirthdayService birthdayService = new BirthdayService();
            var bds = birthdayService.GetAllBirthdays();

            Assert.AreEqual(4, bds.Count);
        }
         [Test]
        public void TestDip2()
        {
            IBirthdayService birthdayService = new BirthdayService();
            IBirthdayCalculator birthdayCalculator = new BirthdayCalculator();

            var bds = birthdayService.GetAllBirthdays();
            bds[0].Date = DateTime.Now.Date;
            var todaysBds = birthdayCalculator.GetTodaysBirthdays();

            Assert.AreEqual(0, todaysBds.Count);
        }


         [Test]
        public void TesLsp1()
         {
             IFourSidedShape shape = new Rectangle();
             shape.Height = 5;
             shape.Width = 10;

             Assert.AreEqual(5, shape.Height);
        }

         [Test]
        public void TesLsp2()
         {
             IFourSidedShape shape = new Square();
             shape.Height = 5;
             shape.Width = 10;

             Assert.AreEqual(10, shape.Height);
        }
    }
}
