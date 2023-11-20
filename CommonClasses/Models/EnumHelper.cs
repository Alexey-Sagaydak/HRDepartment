using System;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using CommonClasses;

public static class EnumHelper
{
    public static string GetDescription(Enum value)
    {
        FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        if (fieldInfo != null)
        {
            DescriptionAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
        }

        return value.ToString();
    }

    public static T GetEnumValueFromDescription<T>(string description) where T : Enum
    {
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            if (GetDescription(value) == description)
            {
                return value;
            }
        }
        Console.WriteLine(description);
        Console.WriteLine(Gender.female.ToString());
        throw new ArgumentException("Description not found for the provided enum value.");
    }

    public static List<string> GetDescriptions<T>() where T : Enum
    {
        List<string> descriptions = new List<string>();
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            descriptions.Add(GetDescription(value));
        }
        return descriptions;
    }
}

