using System.ComponentModel.DataAnnotations;

namespace Day6.Custom_Annotation
{
    public class NoPastDate: ValidationAttribute
    {
        public NoPastDate()
        {
            
        }

        public override bool IsValid(object? value)
        {
            if (value is DateOnly dateValue)
            {
                if(dateValue >= DateOnly.FromDateTime(DateTime.Now))
                {
                    return true;
                }
                return false;
            }
            else  return false; 
        }
    }
}
