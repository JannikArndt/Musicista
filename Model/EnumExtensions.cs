﻿using Model.Sections;
using System;
using System.ComponentModel;

namespace Model
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null) return null;

            var field = type.GetField(name);
            if (field == null) return null;

            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute != null ? attribute.Description : name;
        }

        public static Repetition ParseRepetition(string text)
        {
            if (text == null) return Repetition.None;

            text = text.RemoveWhitespace().ToLower().Replace(".", String.Empty);
            if (Enum.IsDefined(typeof(Repetition), text))
                return (Repetition)Enum.Parse(typeof(Repetition), text);

            return Repetition.None;
        }
    }
}
