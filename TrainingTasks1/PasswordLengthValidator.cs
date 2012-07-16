using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks1
{
    public class PasswordLengthValidator : IPasswordValidator
    {
        public PasswordLengthValidator()
        {
            _message = "Password Length must be greater than 9."; 
        }

        private readonly string  _message;
        public bool IsValid
        {
            get { return  (_message ?? "").Length > 9; }
        }

        public string Message
        {
            get { return _message; }
        }
    }
}
