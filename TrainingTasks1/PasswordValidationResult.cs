namespace TrainingTasks1
{
    public class PasswordValidationResult
    {
        public PasswordValidationResult()
        {
            
        }

        public PasswordValidationResult(bool isValid, string message)
        {
            Message = message;
            IsValid = isValid;
        }

        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}