using System;

namespace Model.Sections.Notes.Articulation
{
    public class Mute
    {
        public MuteType MuteType { get; set; }
        public String MuteText
        {
            get { return MuteType.GetDescription(); }
            set { Parse(value); }
        }

        public bool Parse(string parseString)
        {
            parseString = parseString.RemoveWhitespace().ToLower().Replace(".", String.Empty);

            if (Enum.IsDefined(typeof(MuteType), parseString))
            {
                MuteType = (MuteType)Enum.Parse(typeof(MuteType), parseString);
                return true;
            }
            Console.WriteLine("Could not parse mute string " + parseString);
            return false;
        }

    }


}
