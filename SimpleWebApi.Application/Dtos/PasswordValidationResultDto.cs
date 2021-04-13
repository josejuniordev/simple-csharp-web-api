namespace SimpleWebApi.Application.Dtos
{
    public class PasswordValidationResultDto
    {
        public PasswordValidationResultDto(bool passwordIsValid)
        {
            PasswordIsValid = passwordIsValid;
        }
        
        public bool PasswordIsValid { get; }
    }
}