using System;
using System.ComponentModel;
using System.Linq;

namespace GeekFit
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Retrieves a descriptive attribute associated with the enum field using DescriptionAttribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            #region DescriptionAttribute

            var description = value.GetAttribute<DescriptionAttribute>();

            if (description != null)
            {
                return description.Description;
            }

            #endregion

            // default
            return value.ToString();
        }

        public static T GetAttribute<T>(this Enum value) where T : class
        {
            var member = value
                .GetType()
                .GetMember(value.ToString())
                .FirstOrDefault();

            return member != null
                ? member.GetCustomAttributes(typeof(T), false).FirstOrDefault() as T
                : default(T);
        }
    }
}
