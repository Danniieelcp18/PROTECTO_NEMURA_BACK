using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PROYECTO_NEMURA.Enums;
public static class EnumExtensions
{
    public static string GetDescription(this Enum enumValue)
    {
        var field = enumValue.GetType().GetField(enumValue.ToString());
        var attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
        return attribute == null ? enumValue.ToString() : attribute.Description;
    }
}