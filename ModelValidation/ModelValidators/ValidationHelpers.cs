using System.Linq;

namespace ModelValidation.ModelValidators
{
    public class ValidationHelpers
    {
        public static bool IsValidName(string name)
        {
            name = name.Replace(" ", "").Replace("-", "");
            return name.All(char.IsLetter);
        }
    }
}
