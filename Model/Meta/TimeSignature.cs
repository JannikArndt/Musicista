using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 3/4: Beats = 3, BeatUnit = 4
    /// </summary>
    public class TimeSignature
    {
        public int Beats { get; set; }
        public int BeatUnit { get; set; }
        public bool IsCommon = false; // 4/4 = c
        public bool IsCutCommon = false; // 2/2 = </:

        public TimeSignature(int beats, int beatUnit)
        {
            Beats = beats;
            BeatUnit = beatUnit;
        }

        public TimeSignature(bool isCommon = false, bool isCutCommon = false)
        {
            if(isCommon)
            {
                IsCommon = true;
                Beats = 4;
                BeatUnit = 4;
            }

            if (isCutCommon)
            {
                IsCutCommon = true;
                Beats = 2;
                BeatUnit = 2;
            }
        }
    }
}
