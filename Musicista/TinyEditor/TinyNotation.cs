using Model.Sections;
using Model.Sections.Attributes;
using Model.Sections.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Musicista.TinyEditor
{
    public static class TinyNotation
    {
        public static Passage ParseTinyNotation(string text)
        {

            var notes = new List<Symbol>();
            var snippets = text.Split(' ');
            var lastDuration = Duration.Quarter;
            var beat = 960;
            var measureCount = 1;
            var currentMeasure = new Measure { ParentMeasureGroup = new MeasureGroup { MeasureNumber = 1, KeySignature = new MusicalKey(Step.C, Gender.Major), TimeSignature = new TimeSignature(4, 4) }, Clef = Clef.Treble };
            foreach (var snippet in snippets)
            {
                if (string.IsNullOrWhiteSpace(snippet))
                    continue;
                var splittingpoint = snippet.IndexOfAny("0123456789".ToCharArray());
                splittingpoint = splittingpoint < 0 ? snippet.Length : splittingpoint;

                // Pitch
                var newNote = ParseTinyPitch(snippet.Substring(0, splittingpoint));
                // Duration
                newNote.Duration = ParseTinyDuration(snippet.Substring(splittingpoint)) ?? lastDuration;
                lastDuration = newNote.Duration;
                // Parent Measure
                newNote.ParentMeasure = currentMeasure;
                // Beat
                newNote.Beat = beat / 960.0;
                beat += (int)newNote.Duration;
                if (beat >= 4800)
                {
                    currentMeasure = new Measure
                    {
                        ParentMeasureGroup =
                            new MeasureGroup
                            {
                                MeasureNumber = ++measureCount,
                                KeySignature = new MusicalKey(Step.C, Gender.Major),
                                TimeSignature = new TimeSignature(4, 4)
                            },
                        Clef = Clef.Treble
                    };
                    beat = 960;
                }
                notes.Add(newNote);
            }

            return new Passage(notes);
        }

        public static List<Symbol> ParseTinyNotation(string text, Measure measure)
        {

            var notes = new List<Symbol>();
            var snippets = text.Split(' ');
            var lastDuration = Duration.Quarter;
            var beat = 960;
            foreach (var snippet in snippets)
            {
                if (string.IsNullOrWhiteSpace(snippet))
                    continue;
                var splittingpoint = snippet.IndexOfAny("0123456789".ToCharArray());
                splittingpoint = splittingpoint < 0 ? snippet.Length : splittingpoint;

                // Pitch
                var newNote = ParseTinyPitch(snippet.Substring(0, splittingpoint));
                // Duration
                newNote.Duration = ParseTinyDuration(snippet.Substring(splittingpoint)) ?? lastDuration;
                lastDuration = newNote.Duration;
                // Parent Measure
                newNote.ParentMeasure = measure;
                // Beat
                newNote.Beat = beat / 960.0;
                beat += (int)newNote.Duration;
                if (beat > 4800)
                    continue;
                notes.Add(newNote);
            }

            return notes;
        }

        public static Duration? ParseTinyDuration(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;

            var number = int.Parse(Regex.Match(text, @"\d+").Value);
            if (number == 0) return null;

            var dotted = text.Contains('.');
            switch (number)
            {
                case 1:
                    return dotted ? Duration.WholeDotted : Duration.Whole;
                case 2:
                    return dotted ? Duration.HalfDotted : Duration.Half;
                case 4:
                    return dotted ? Duration.QuarterDotted : Duration.Quarter;
                case 8:
                    return dotted ? Duration.EigthDotted : Duration.Eigth;
                case 16:
                    return dotted ? Duration.SixteenthDotted : Duration.Sixteenth;
                case 32:
                    return dotted ? Duration.ThirtysecondDotted : Duration.Thirtysecond;
                default: return Duration.Quarter;
            }
        }

        public static Symbol ParseTinyPitch(string text)
        {
            if (text == "r" || string.IsNullOrWhiteSpace(text))
                return new Rest();
            var newNote = new Note();

            var sharp = false;
            var flat = false;

            if (text.Contains("#"))
                sharp = true;
            if (text.Contains("-"))
                flat = true;

            // Regex.Replace(text, "[#-]", string.Empty);

            text = text.Replace(@"[^A-Ga-g]+", "");

            switch (text.ToLower()[0])
            {
                case 'a':
                    newNote.Step = sharp ? Step.ASharp : flat ? Step.AFlat : Step.A; break;
                case 'b':
                    newNote.Step = sharp ? Step.BSharp : flat ? Step.BFlat : Step.B; break;
                case 'h':
                    newNote.Step = sharp ? Step.BSharp : flat ? Step.BFlat : Step.B; break;
                case 'c':
                    newNote.Step = sharp ? Step.CSharp : flat ? Step.CFlat : Step.C; break;
                case 'd':
                    newNote.Step = sharp ? Step.DSharp : flat ? Step.DFlat : Step.D; break;
                case 'e':
                    newNote.Step = sharp ? Step.ESharp : flat ? Step.EFlat : Step.E; break;
                case 'f':
                    newNote.Step = sharp ? Step.FSharp : flat ? Step.FFlat : Step.F; break;
                case 'g':
                    newNote.Step = sharp ? Step.GSharp : flat ? Step.GFlat : Step.G; break;
                default:
                    newNote.Step = sharp ? Step.CSharp : flat ? Step.CFlat : Step.C; break;

            }

            if (new Regex("A{3}|B{3}|C{3}|D{3}|E{3}|F{3}|G{3}").IsMatch(text))
                newNote.Octave = 1;
            else if (new Regex("A{2}|B{2}|C{2}|D{2}|E{2}|F{2}|G{2}").IsMatch(text))
                newNote.Octave = 2;
            else if (new Regex("[A-G]").IsMatch(text))
                newNote.Octave = 3;
            else if (new Regex("a{4}|b{4}|c{4}|d{4}|e{4}|f{4}|g{4}|[a-g]'{3}").IsMatch(text))
                newNote.Octave = 7;
            else if (new Regex("a{3}|b{3}|c{3}|d{3}|e{3}|f{3}|g{3}|[a-g]'{2}").IsMatch(text))
                newNote.Octave = 6;
            else if (new Regex("a{2}|b{2}|c{2}|d{2}|e{2}|f{2}|g{2}|[a-g]'").IsMatch(text))
                newNote.Octave = 5;
            else if (new Regex("[a-g]").IsMatch(text))
                newNote.Octave = 4;




            return newNote;
        }

        public static string CreateTinyNotation(Measure measure)
        {
            var result = "";

            foreach (var symbol in measure.Symbols)
            {
                if (symbol.GetType() == typeof(Rest))
                    result += "r" + 3840.0 / (double)symbol.Duration + " ";
                else if (symbol.GetType() == typeof(Note))
                    result += CreateTinyNotation((Note)symbol);
            }
            return result;
        }

        public static string CreateTinyNotation(Note note)
        {
            var result = "";

            // Step
            var step = "";
            var sharp = false;
            var flat = false;

            switch (note.Step)
            {
                case Step.A: step = "a"; break;
                case Step.B: step = "b"; break;
                case Step.C: step = "c"; break;
                case Step.D: step = "d"; break;
                case Step.E: step = "e"; break;
                case Step.F: step = "f"; break;
                case Step.G: step = "g"; break;
                case Step.ASharp: step = "a"; sharp = true; break;
                case Step.BSharp: step = "b"; sharp = true; break;
                case Step.CSharp: step = "c"; sharp = true; break;
                case Step.DSharp: step = "d"; sharp = true; break;
                case Step.ESharp: step = "e"; sharp = true; break;
                case Step.FSharp: step = "f"; sharp = true; break;
                case Step.GSharp: step = "g"; sharp = true; break;
                case Step.AFlat: step = "a"; flat = true; break;
                case Step.BFlat: step = "b"; flat = true; break;
                case Step.CFlat: step = "c"; flat = true; break;
                case Step.DFlat: step = "d"; flat = true; break;
                case Step.EFlat: step = "e"; flat = true; break;
                case Step.FFlat: step = "f"; flat = true; break;
                case Step.GFlat: step = "g"; flat = true; break;
            }
            switch (note.Octave)
            {
                case 1:
                    step = step.ToUpper() + step.ToUpper() + step.ToUpper(); break;
                case 2:
                    step = step.ToUpper() + step.ToUpper(); break;
                case 3:
                    step = step.ToUpper(); break;
                case 5:
                    step = step + step; break;
                case 6:
                    step = step + step + step; break;
                case 7:
                    step = step + step + step + step; break;
            }
            if (sharp)
                step = step + "#";
            if (flat)
                step = step + "-";

            result += step;

            // Duration
            var duration = 3840.0 / (double)note.Duration;
            if (Math.Abs(duration % 1) < 0.001)
                result += duration;
            else
                result += duration + ".";

            return result + " ";
        }
    }
}
