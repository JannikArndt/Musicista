using Model.Instruments;
using Model.Sections.Attributes;
using System;
using System.ComponentModel;

namespace Model.Extensions
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

        public static BraceType ParseBrace(string text)
        {
            if (text == null) return BraceType.None;

            switch (text)
            {
                case "none": return BraceType.None;
                case "brace": return BraceType.Brace;
                case "line": return BraceType.Line;
                case "bracket": return BraceType.Bracket;
                case "sqaure": return BraceType.Square;
                default: return BraceType.None;
            }
        }
    }
}
