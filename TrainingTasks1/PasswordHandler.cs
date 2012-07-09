using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks1
{
    public interface IPasswordHandler
    {
        bool HasEnoughUpperChars(string password, int minUpperChars);
        bool HasEnoughNumbers(string password, int minUpperChars);
        bool IsAtLeastLength(string password, int minLen);
    }

    public class PasswordHandler : IPasswordHandler
    {
        public bool HasEnoughUpperChars(string password, int minUpperChars)
        {
            int cntUpperChars = password.ToCharArray().Count(char.IsUpper);

            return cntUpperChars>=minUpperChars;
        }

        public bool HasEnoughNumbers(string password, int minUpperChars)
        {
            int cntUpperChars = password.ToCharArray().Count(char.IsDigit);

            return cntUpperChars>=minUpperChars;
        }

        
        public bool IsAtLeastLength(string password, int minLen)
        {
            return (password.Length >= minLen);
        }
    }
}
