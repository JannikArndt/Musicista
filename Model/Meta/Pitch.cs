
using System;

namespace Model.Meta
{
    public enum Pitch
    {
        C,
        CSharp,
        DFlat,
        D,
        DSharp,
        EFlat,
        E,
        ESharp,
        FFlat,
        F,
        FSharp,
        GFlat,
        G,
        GSharp,
        AFlat,
        A,
        ASharp,
        BFlat,
        B,
        BSharp,
        CFlat,
        Unknown
    }

    public static class PitchExtensions
    {
        public static PitchForSums ToPitchForSums(this Pitch pitch)
        {
            if (pitch == Pitch.C || pitch == Pitch.D || pitch == Pitch.E || pitch == Pitch.F || pitch == Pitch.G || pitch == Pitch.A || pitch == Pitch.B
                || pitch == Pitch.CSharp || pitch == Pitch.DSharp || pitch == Pitch.FSharp || pitch == Pitch.GSharp || pitch == Pitch.ASharp)
                return (PitchForSums)Enum.Parse(typeof(PitchForSums), pitch.ToString());

            switch (pitch)
            {
                case Pitch.DFlat:
                    return PitchForSums.CSharp;
                case Pitch.EFlat:
                    return PitchForSums.DSharp;
                case Pitch.ESharp:
                    return PitchForSums.F;
                case Pitch.FFlat:
                    return PitchForSums.E;
                case Pitch.GFlat:
                    return PitchForSums.FSharp;
                case Pitch.AFlat:
                    return PitchForSums.GSharp;
                case Pitch.BFlat:
                    return PitchForSums.ASharp;
                case Pitch.BSharp:
                    return PitchForSums.C;
                case Pitch.CFlat:
                    return PitchForSums.B;
            }
            return PitchForSums.Unknown;
        }
    }

    public enum PitchForSums
    {
        C = 1,
        CSharp = 2,
        D = 3,
        DSharp = 4,
        E = 5,
        F = 6,
        FSharp = 7,
        G = 8,
        GSharp = 9,
        A = 10,
        ASharp = 11,
        B = 12,
        Unknown = 0
    }
}
