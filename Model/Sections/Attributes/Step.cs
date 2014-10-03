
using System;

namespace Model.Sections.Attributes
{
    public enum Step
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

    public static class StepExtensions
    {
        public static StepForSums ToStepForSums(this Step step)
        {
            if (step == Step.C || step == Step.D || step == Step.E || step == Step.F || step == Step.G || step == Step.A || step == Step.B
                || step == Step.CSharp || step == Step.DSharp || step == Step.FSharp || step == Step.GSharp || step == Step.ASharp)
                return (StepForSums)Enum.Parse(typeof(StepForSums), step.ToString());

            switch (step)
            {
                case Step.DFlat:
                    return StepForSums.CSharp;
                case Step.EFlat:
                    return StepForSums.DSharp;
                case Step.ESharp:
                    return StepForSums.F;
                case Step.FFlat:
                    return StepForSums.E;
                case Step.GFlat:
                    return StepForSums.FSharp;
                case Step.AFlat:
                    return StepForSums.GSharp;
                case Step.BFlat:
                    return StepForSums.ASharp;
                case Step.BSharp:
                    return StepForSums.C;
                case Step.CFlat:
                    return StepForSums.B;
            }
            return StepForSums.Unknown;
        }

        public static int ToFifths(this Step step)
        {
            switch (step)
            {
                case Step.C: return 0;
                case Step.G: return 1;
                case Step.D: return 2;
                case Step.A: return 3;
                case Step.E: return 4;
                case Step.B: return 5;
                case Step.FSharp: return 6;
                case Step.CSharp: return 7;
                case Step.GSharp: return 8;
                case Step.DSharp: return 9;
                case Step.ASharp: return 10;
                case Step.F: return -1;
                case Step.BFlat: return -2;
                case Step.EFlat: return -3;
                case Step.AFlat: return -4;
                case Step.DFlat: return -5;
                case Step.GFlat: return -6;
                case Step.CFlat: return -7;
                case Step.FFlat: return -8;
                default: return 0;
            }
        }
    }

    public enum StepForSums
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
