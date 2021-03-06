﻿using Model.Extensions;
using Model.Sections;
using Model.Sections.Attributes;
using Model.Sections.Notes;
using Model.Sections.Notes.Articulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Musicista.TinyEditor
{
    /// <summary>
    /// Static class to provide conversion between measures and TinyNotation (see http://www.musicistaapp.de/application/tinynotation/)
    /// </summary>
    public static class TinyNotation
    {
        /// <summary>
        /// Turns a TinyNotation string into a list of Symbols, with the given Measure as their parent Measure.
        /// </summary>
        /// <param name="text">A string containing TinyNotation</param>
        /// <param name="measure">The parent of the created symbols</param>
        /// <returns>A list of symbols</returns>
        public static List<Symbol> ParseTinyNotation(string text, Measure measure = null)
        {

            var notes = new List<Symbol>();
            // Allow for spaces in lyrics
            text = new Regex(@"\s(?=[\w|\s]*\])").Replace(text, "§§§");
            var snippets = text.Split(' ');
            var lastDuration = Duration.Quarter;
            var beat = 960;
            var chordMode = false;
            foreach (var snippet in snippets)
            {
                switch (snippet)
                {
                    case "":
                        continue;
                    case "{":
                        chordMode = true;
                        break;
                    case "}":
                        chordMode = false;
                        beat += (int)notes.Last().Duration;
                        break;
                    default:
                        var splittingpoint = snippet.IndexOfAny("0123456789".ToCharArray());
                        splittingpoint = splittingpoint < 0 ? snippet.Length : splittingpoint;

                        // Pitch
                        var newNote = ParseTinyPitch(snippet.Substring(0, splittingpoint));
                        // Duration
                        newNote.Duration = ParseTinyDuration(snippet.Substring(splittingpoint)) ?? lastDuration;
                        lastDuration = newNote.Duration;
                        // Articulation
                        if (new Regex(@"\(.*\)").IsMatch(snippet))
                            newNote.Articulations = ParseTinyArticulation(snippet);
                        // Lyrics
                        if (new Regex(@"\[.*\]").IsMatch(snippet))
                            newNote.Lyrics = ParseTinyLyrics(snippet.Replace("§§§", " "));
                        // Parent Measure
                        newNote.ParentMeasure = measure;
                        // Beat
                        newNote.Beat = beat / 960.0;
                        if (!chordMode)
                            beat += (int)newNote.Duration;
                        if (beat > 4800)
                            continue;
                        notes.Add(newNote);
                        break;
                }
            }

            if (notes.IsNullOrEmpty())
                notes.Add(new Rest { Beat = 1.0, Duration = Duration.Whole, ParentMeasure = measure });

            return notes;
        }

        /// <summary>
        /// Grabs the [...] element from the string and turns it into a list of Lyrics
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<Lyric> ParseTinyLyrics(string text)
        {
            var arguments = Regex.Match(text, @"\[.*\]").Value;
            arguments = arguments.Substring(1, arguments.Length - 2);
            var lyrics = arguments.Split(',');
            return lyrics.Select((t, line) => new Lyric { Text = t, Line = line }).ToList();
        }

        /// <summary>
        /// Grabs the (...) element from the string and turns it into an Articulation object
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Articulation ParseTinyArticulation(string text)
        {
            var newArticulation = new Articulation();

            var arguments = Regex.Match(text, @"\(.*\)").Value;
            arguments = arguments.Substring(1, arguments.Length - 2);
            var articulations = arguments.Split(',');
            foreach (var articulation in articulations)
            {
                switch (articulation.ToUpperInvariant())
                {
                    case "P": newArticulation.Dynamics = Dynamics.p; break;
                    case "PP": newArticulation.Dynamics = Dynamics.pp; break;
                    case "PPP": newArticulation.Dynamics = Dynamics.ppp; break;
                    case "PPPP": newArticulation.Dynamics = Dynamics.pppp; break;
                    case "PPPPP": newArticulation.Dynamics = Dynamics.ppppp; break;
                    case "PPPPPP": newArticulation.Dynamics = Dynamics.pppppp; break;
                    case "F": newArticulation.Dynamics = Dynamics.f; break;
                    case "FF": newArticulation.Dynamics = Dynamics.ff; break;
                    case "FFF": newArticulation.Dynamics = Dynamics.fff; break;
                    case "FFFF": newArticulation.Dynamics = Dynamics.ffff; break;
                    case "FFFFF": newArticulation.Dynamics = Dynamics.fffff; break;
                    case "FFFFFF": newArticulation.Dynamics = Dynamics.ffffff; break;
                    case "FP": newArticulation.Dynamics = Dynamics.fp; break;
                    case "FZ": newArticulation.Dynamics = Dynamics.fz; break;
                    case "MF": newArticulation.Dynamics = Dynamics.mf; break;
                    case "MP": newArticulation.Dynamics = Dynamics.mp; break;
                    case "RF": newArticulation.Dynamics = Dynamics.rf; break;
                    case "RFZ": newArticulation.Dynamics = Dynamics.rfz; break;
                    case "SF": newArticulation.Dynamics = Dynamics.sf; break;
                    case "SFZ": newArticulation.Dynamics = Dynamics.sfz; break;
                    case "SFFZ": newArticulation.Dynamics = Dynamics.sffz; break;
                    case "SFP": newArticulation.Dynamics = Dynamics.sfp; break;
                    case "SFPP": newArticulation.Dynamics = Dynamics.sfpp; break;
                    case "MARCATO": newArticulation.Accent = Accent.Marcato; break;
                    case "STACCATO": newArticulation.Accent = Accent.Staccato; break;
                    case "STACCATISSIMO": newArticulation.Accent = Accent.Staccatissimo; break;
                    case "ACCENT": newArticulation.Accent = Accent.Standard; break;
                    case "TENUTO": newArticulation.Accent = Accent.Tenuto; break;
                    case "PORTATO": newArticulation.Accent = Accent.Portato; break;
                    case "LEGATO": newArticulation.Legato = true; break;
                    case "ARPEGGIATE": newArticulation.Arpeggiate = true; break;
                    case "CAESURA": newArticulation.Caesura = true; break;
                    case "DAMPING": newArticulation.Damping = true; break;
                    case "DOLCE": newArticulation.Dolce = true; break;
                    case "ESPRESSIVO": newArticulation.Espressivo = true; break;
                    case "TREMOLO": newArticulation.Tremolo = true; break;
                    case "TRILL": newArticulation.Trill = true; break;
                    case "{": newArticulation.Slur = Slur.Start; break;
                    case "_": newArticulation.Slur = Slur.Middle; break;
                    case "}": newArticulation.Slur = Slur.End; break;
                    case "MORDENT": newArticulation.Ornament = Ornament.Mordent; break;
                    case "INVMORDENT": newArticulation.Ornament = Ornament.InvertedMordent; break;
                    case "TURN": newArticulation.Ornament = Ornament.Turn; break;
                    case "INVTURN": newArticulation.Ornament = Ornament.InvertedTurn; break;
                    case "DELTURN": newArticulation.Ornament = Ornament.DelayedTurn; break;
                    case "DELINVTURN": newArticulation.Ornament = Ornament.DelayedInvertedTurn; break;
                    case "VERTICALTURN": newArticulation.Ornament = Ornament.VerticalTurn; break;
                    case "SCHLEIFER": newArticulation.Ornament = Ornament.Schleifer; break;
                    case "SHAKE": newArticulation.Ornament = Ornament.Shake; break;
                    case "WAVYLINE": newArticulation.Ornament = Ornament.WavyLine; break;
                }
            }
            return newArticulation;
        }

        /// <summary>
        /// Grabs the number from the string and turns it into a Duration
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
                case 13:
                    return Duration.WholeTriplet;
                case 23:
                    return Duration.HalfTriplet;
                case 43:
                    return Duration.QuarterTriplet;
                case 83:
                    return Duration.EigthTriplet;
                case 163:
                    return Duration.SixteenthTriplet;
                case 324:
                    return Duration.ThirtysecondTriplet;
                default: return Duration.Quarter;
            }
        }

        /// <summary>
        /// Grabs the first letters from the string and turns them into a Pitch
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
            if (text.Contains("("))
                text = text.Substring(0, text.IndexOf('('));
            if (text.Contains("["))
                text = text.Substring(0, text.IndexOf('['));
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

            if (new Regex("A{3}|B{3}|C{3}|D{3}|E{3}|F{3}|G{3}|H{3}").IsMatch(text))
                newNote.Octave = 1;
            else if (new Regex("A{2}|B{2}|C{2}|D{2}|E{2}|F{2}|G{2}|H{2}").IsMatch(text))
                newNote.Octave = 2;
            else if (new Regex("[A-H]").IsMatch(text))
                newNote.Octave = 3;
            else if (new Regex("a{4}|b{4}|c{4}|d{4}|e{4}|f{4}|g{4}|h{4}|[a-h]'{3}").IsMatch(text))
                newNote.Octave = 7;
            else if (new Regex("a{3}|b{3}|c{3}|d{3}|e{3}|f{3}|g{3}|h{3}|[a-h]'{2}").IsMatch(text))
                newNote.Octave = 6;
            else if (new Regex("a{2}|b{2}|c{2}|d{2}|e{2}|f{2}|g{2}|h{2}|[a-h]'").IsMatch(text))
                newNote.Octave = 5;
            else if (new Regex("[a-h]").IsMatch(text))
                newNote.Octave = 4;

            return newNote;
        }

        /// <summary>
        /// Turns a Measure into a string of TinyNotation
        /// </summary>
        /// <param name="measure">The original measure</param>
        /// <returns>The TinyNotation version of the measure</returns>
        public static string CreateTinyNotation(Measure measure)
        {
            var result = "";
            var previousDuration = Duration.Quarter;
            var chordMode = false;
            var chordBeat = 0.0;
            foreach (var symbol in measure.Symbols)
            {
                // chords
                if (measure.Symbols.Count(item => Math.Abs(item.Beat - symbol.Beat) < 0.01) > 1) // if there is more than one note
                {
                    if (!chordMode) // Start chord mode
                    {
                        result += "{ ";
                        chordMode = true;
                        chordBeat = symbol.Beat;
                    }
                    else if (Math.Abs(chordBeat - symbol.Beat) > 0.01) // new chord
                    {
                        result += "} { ";
                        chordBeat = symbol.Beat;
                    }
                }
                else
                {
                    if (chordMode) // exit chord mode
                    {
                        result += "} ";
                        chordMode = false;
                    }
                }

                var duration = "";
                if (symbol.Duration != previousDuration)
                {
                    duration = CreateTinyDuration(symbol);
                    previousDuration = symbol.Duration;
                }

                if (symbol.GetType() == typeof(Rest))
                    result += "r" + duration + CreateTinyArticulation(symbol) + CreateTinyLyrics(symbol) + " ";
                else if (symbol.GetType() == typeof(Note))
                    result += CreateTinyStep((Note)symbol) + duration + CreateTinyArticulation(symbol) + CreateTinyLyrics(symbol) + " ";
            }
            return result;
        }

        /// <summary>
        /// Turns the Articulation part of a Symbol into a TinyNotation string
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static string CreateTinyArticulation(Symbol symbol)
        {
            if (symbol.Articulations == null)
                return "";
            var articulations = new List<String>();
            switch (symbol.Articulations.Dynamics)
            {
                case Dynamics.p: articulations.Add("p"); break;
                case Dynamics.pp: articulations.Add("pp"); break;
                case Dynamics.ppp: articulations.Add("ppp"); break;
                case Dynamics.pppp: articulations.Add("pppp"); break;
                case Dynamics.ppppp: articulations.Add("ppppp"); break;
                case Dynamics.pppppp: articulations.Add("pppppp"); break;
                case Dynamics.f: articulations.Add("f"); break;
                case Dynamics.ff: articulations.Add("ff"); break;
                case Dynamics.fff: articulations.Add("fff"); break;
                case Dynamics.ffff: articulations.Add("ffff"); break;
                case Dynamics.fffff: articulations.Add("fffff"); break;
                case Dynamics.ffffff: articulations.Add("ffffff"); break;
                case Dynamics.fp: articulations.Add("fp"); break;
                case Dynamics.fz: articulations.Add("fz"); break;
                case Dynamics.mf: articulations.Add("mf"); break;
                case Dynamics.mp: articulations.Add("mp"); break;
                case Dynamics.rf: articulations.Add("rf"); break;
                case Dynamics.rfz: articulations.Add("rfz"); break;
                case Dynamics.sf: articulations.Add("sf"); break;
                case Dynamics.sffz: articulations.Add("sffz"); break;
                case Dynamics.sfp: articulations.Add("sfp"); break;
                case Dynamics.sfpp: articulations.Add("sfpp"); break;
            }

            switch (symbol.Articulations.Accent)
            {
                case Accent.Marcato: articulations.Add("Marcato"); break;
                case Accent.Staccato: articulations.Add("Staccato"); break;
                case Accent.Staccatissimo: articulations.Add("Staccatissimo"); break;
                case Accent.Standard: articulations.Add("Accent"); break;
                case Accent.Tenuto: articulations.Add("Tenuto"); break;
                case Accent.Portato: articulations.Add("Portato"); break;
            }

            if (symbol.Articulations.Legato)
                articulations.Add("Legato");

            if (symbol.Articulations.Arpeggiate)
                articulations.Add("Arpeggiate");

            if (symbol.Articulations.Damping)
                articulations.Add("Damping");

            if (symbol.Articulations.Dolce)
                articulations.Add("Dolce");

            if (symbol.Articulations.Espressivo)
                articulations.Add("Espressivo");

            if (symbol.Articulations.Tremolo)
                articulations.Add("Tremolo");

            if (symbol.Articulations.Trill)
                articulations.Add("Trill");

            switch (symbol.Articulations.Slur)
            {
                case Slur.Start: articulations.Add("{"); break;
                case Slur.Middle: articulations.Add("_"); break;
                case Slur.End: articulations.Add("}"); break;
            }

            switch (symbol.Articulations.Ornament)
            {
                case Ornament.Mordent: articulations.Add("Mordent"); break;
                case Ornament.InvertedMordent: articulations.Add("InvMordent"); break;
                case Ornament.Turn: articulations.Add("Turn"); break;
                case Ornament.InvertedTurn: articulations.Add("InvTurn"); break;
                case Ornament.DelayedTurn: articulations.Add("DelTurn"); break;
                case Ornament.DelayedInvertedTurn: articulations.Add("DelInvTurn"); break;
                case Ornament.VerticalTurn: articulations.Add("VerticalTurn"); break;
                case Ornament.Schleifer: articulations.Add("Schleifer"); break;
                case Ornament.Shake: articulations.Add("Shake"); break;
                case Ornament.WavyLine: articulations.Add("WavyLine"); break;
            }

            if (articulations.Count > 0)
                return "(" + string.Join(",", articulations) + ")";
            return "";
        }

        /// <summary>
        /// Turns the lyrics of a symbol into a TinyNotation string
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static string CreateTinyLyrics(Symbol symbol)
        {
            if (symbol.Lyrics.Count > 0)
                return "[" + string.Join(",", symbol.Lyrics.Select(l => l.Text)) + "]";
            return "";
        }

        /// <summary>
        /// Turns the Step of a symbol into a TinyNotation string
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public static string CreateTinyStep(Note note)
        {
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

            return step;
        }

        /// <summary>
        /// Turns the duration of a symbol into a TinyNotation string
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static string CreateTinyDuration(Symbol symbol)
        {
            switch (symbol.Duration)
            {
                case Duration.Thirtysecond: return "32";
                case Duration.ThirtysecondDotted: return "32.";
                case Duration.ThirtysecondTriplet: return "323";
                case Duration.Sixteenth: return "16";
                case Duration.SixteenthDotted: return "16.";
                case Duration.SixteenthTriplet: return "163";
                case Duration.SixteenthDoubleDotted: return "16..";
                case Duration.Eigth: return "8";
                case Duration.EigthDotted: return "8.";
                case Duration.EigthDoubleDotted: return "8..";
                case Duration.EigthTriplet: return "83";
                case Duration.Quarter: return "4";
                case Duration.QuarterDotted: return "4.";
                case Duration.QuarterDoubleDotted: return "4..";
                case Duration.QuarterTriplet: return "43";
                case Duration.Half: return "2";
                case Duration.HalfDotted: return "2.";
                case Duration.HalfDoubleDotted: return "2..";
                case Duration.HalfTriplet: return "23";
                case Duration.Whole: return "1";
                case Duration.WholeTriplet: return "13";
                default: return "";
            }
        }
    }
}
