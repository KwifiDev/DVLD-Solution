using System.Linq;
using System.Text.RegularExpressions;

namespace DVLD_UI.Shared_Classes
{
    internal class ClsValidation
    {
        internal static bool ValidateEmail(string emailAddress)
        {
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }

        internal static bool IsValidPhone(string phone)
        {
            return phone.All(char.IsDigit);
        }

        internal static bool ValidateInteger(string number)
        {
            string pattern = @"^[0-9]*$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(number);
        }

        internal static bool ValidateFloat(string number)
        {
            string pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(number);
        }

        internal static bool IsNumber(string number)
        {
            return (ValidateInteger(number) || ValidateFloat(number));
        }
    }
}
