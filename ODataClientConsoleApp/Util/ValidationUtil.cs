using System.ComponentModel.DataAnnotations;

namespace ODataClientConsoleApp.Util
{
    public static class ValidationUtil
    {
        public static bool IsValidEmail(string email)
        {
            var emailAddressAttribute = new EmailAddressAttribute();
            return emailAddressAttribute.IsValid(email);
        }
    }
}
