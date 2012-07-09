using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrainingTasks1
{
    [TestFixture]
    public class PasswordValidatorTests
    {
        private readonly IPasswordValidation _passwordValidation;

        public PasswordValidatorTests()
        {
            _passwordValidation = new PasswordValidation(new PasswordHandler());
        }

        // 1. Should implement 3 rules (must have a number, must have an uppercase letter, must be min of 10 in length). More may be needed later.
        // 2. A Blank password is not valid (First test stub below)
        // 3. If a password is invalid the reason it is invalid should be in the ValidationResult 
        //
        // Notes: Tests should cover all functionality
        //        C# conventions should be followed

        [Test]
        public void A_Blank_Password_Is_Not_Valid()
        {
            var result = _passwordValidation.Validate("");

            Assert.False(result.IsValid);
            Assert.AreEqual(result.Message, "Password cannot be blank");
        }

        [Test]
        public void A_Password_With_Zero_UpperCase_Letters_Is_Not_Valid()
        {
            var result = _passwordValidation.Validate("aaaaaaa111");

            Assert.False(result.IsValid);
            Assert.AreEqual(result.Message, "Password must have one uppercase character");
        }

        [Test]
        public void A_Password_With_One_UpperCase_Letter_No_Number_Is_InValid()
        {
            var result = _passwordValidation.Validate("aaAaaaaaaa");

            Assert.False(result.IsValid);
            Assert.AreEqual(result.Message, "Password must have at least one number");
        }

        [Test]
        public void A_Password_With_Two_UpperCase_Letters_No_Number_Is_InValid()
        {
            var result = _passwordValidation.Validate("aaAaBaaccc");

            Assert.False(result.IsValid);
            Assert.AreEqual(result.Message, "Password must have at least one number");
        }

        
        [Test]
        public void A_Password_With_One_UpperCase_Letter_And_One_Number_Less_Than_10_Chars_Is_Invalid()
        {
            var result = _passwordValidation.Validate("aaAaaaaa1");

            Assert.False(result.IsValid);
            Assert.AreEqual(result.Message, string.Format("Password must be at least 10 characters long."));
        }
        
        [Test]
        public void A_Password_With_One_UpperCase_Letter_And_One_Number_With_10_Chars_Is_Valid()
        {
            var result = _passwordValidation.Validate("aaAaaaeaa1");

            Assert.True(result.IsValid);
        }


        [Test]
        public void String_With_5_Upper_Chars_That_Requires_5_Isvalid()
        {
            var pwh = new PasswordHandler();
            var result = pwh.HasEnoughUpperChars("aaaAAAbbCdDeee111", 5);

            Assert.True(result);
        }
        
        [Test]
        public void String_With_5_Upper_Chars_That_Requires_6_IsNoValid()
        {
            var pwh = new PasswordHandler();
            var result = pwh.HasEnoughUpperChars("aaaAAAbbCdDeee111", 6);

            Assert.False(result);
        }

    }


}
