

using FluentValidation.Results;

namespace Application.Common;

public class StudentException : Exception
{
    public StudentException(string message) : base(message)
    {
        
    }
    public StudentException(ValidationResult result) 
        : base(string.Join("\n", result.Errors.Select(x => x.ErrorMessage)))
    {
        
    }
}
