using System;
using ReportPortal.Client.Extension;

namespace ReportPortal.Client.Converter
{
    public static class EnumConverter
    {
        public static T ConvertTo<T>(string value)
        {
            T res = default(T);
            foreach (T enumValue in Enum.GetValues(typeof(T)))
            {
                if (enumValue.GetDescriptionAttribute() == value)
                {
                    res =  enumValue;
                }
            }
            return res;
        }

        public static string ConvertFrom(Enum enumValue)
        {
            return enumValue.GetDescriptionAttribute();
        }
    }
}
