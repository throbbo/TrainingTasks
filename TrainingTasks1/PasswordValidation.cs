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
        private readonly int _minLength;
        private readonly int _minNumUpperChars;
        private readonly int _minNumbers;


        public PasswordValidation(IPasswordHandler passwordHandler)
        {
            _passwordHandler = passwordHandler;
            _minLength = 10;
            _minNumUpperChars = 1;
            _minNumbers = 1;
        }

        public PasswordValidationResult Validate(string password)
        {
            var res = new PasswordValidationResult(false, "Password cannot be blank");

            if(String.IsNullOrEmpty(password)) 
                return new PasswordValidationResult(false,  "Password cannot be blank");

            if(!_passwordHandler.HasEnoughUpperChars(password, _minNumUpperChars))
                return new PasswordValidationResult(false, "Password must have one uppercase character");

            if(!_passwordHandler.HasEnoughNumbers(password, _minNumbers))
                return new PasswordValidationResult(false, "Password must have at least one number") ;
            
            if(!_passwordHandler.IsAtLeastLength(password, _minLength))
                return new PasswordValidationResult(false, string.Format("Password must be at least {0} characters long.",_minLength));

            // Valid
            return new PasswordValidationResult() { IsValid = true };
        }
    }
}
