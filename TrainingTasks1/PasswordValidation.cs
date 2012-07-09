using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TrainingTasks1
{

    class PasswordValidation : IPasswordValidation
    {
        private readonly IPasswordHandler _passwordHandler;

        public PasswordValidation(IPasswordHandler passwordHandler)
        {
            _passwordHandler = passwordHandler;
        }

        public PasswordValidationResult Validate(string password)
        {
            var res = new PasswordValidationResult() {IsValid = false, Message = "Password cannot be blank"};

            if(String.IsNullOrEmpty(password)) 
                return res;

            const int minLength = 10, minNumUpperChars = 1, minNumbers = 1;

            if(!_passwordHandler.HasEnoughUpperChars(password, minNumUpperChars))
            {
                res.Message = "Password must have one uppercase character";
                return res;
            }

            if(!_passwordHandler.HasEnoughNumbers(password, minNumbers))
            {
                res.Message = "Password must have at least one number";
                return res;
            }
            
            if(!_passwordHandler.IsAtLeastLength(password, minLength))
            {
                res.Message = string.Format("Password must be at least {0} characters long.", minLength);
                return res;
            }

            res.Message = "Password is valid";
            res.IsValid = true;

            return res;
        }
    }
}
