using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TrainingTasks2.DIP;
using TrainingTasks2.LSP;
using TrainingTasks2.OCP;

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


        [Test]
        public void TesOcpEmpty()
         {
             IItemPercentageHandler percentageHandler = new ItemPercentageHandler();
             var res = percentageHandler.GetDiscountPercentage(0);
             Assert.AreEqual(0, res);
        }


        [Test]
        public void TesOcp3()
         {
             IItemPercentageHandler percentageHandler = new ItemPercentageHandler();
             var res = percentageHandler.GetDiscountPercentage(3);
             Assert.AreEqual(0, res);
        }

        [Test]
        public void TesOcp7()
         {
             IItemPercentageHandler percentageHandler = new ItemPercentageHandler();
             var res = percentageHandler.GetDiscountPercentage(7);
             Assert.AreEqual(10, res);
        }

        [Test]
        public void TesOcp12()
         {
             IItemPercentageHandler percentageHandler = new ItemPercentageHandler();
             var res = percentageHandler.GetDiscountPercentage(12);
             Assert.AreEqual(15, res);
        }
    
        [Test]
        public void TesOcp17()
         {
             IItemPercentageHandler percentageHandler = new ItemPercentageHandler();
             var res = percentageHandler.GetDiscountPercentage(17);
             Assert.AreEqual(25, res);
        }
    }
}
