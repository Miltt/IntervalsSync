using System.ComponentModel;
using System.Text;

namespace Sync.Utilities
{
    public static class Helper
    {
        public static string ConvertToBase64String(string plainText)
        {
            if (plainText is null)
                throw new ArgumentNullException(nameof(plainText));

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }

        public static string GetDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            return field != null && (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                ? attribute.Description
                : enumValue.ToString();
        }
    }
}