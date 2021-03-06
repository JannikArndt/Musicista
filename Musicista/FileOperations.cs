﻿using Ionic.Zip;
using Microsoft.Win32;
using Model;
using MuseScoreAPI.RESTObjects;
using Musicista.Mappers;
using Musicista.Properties;
using Musicista.Sidebar;
using MusicXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Musicista
{
    public partial class MainWindow
    {
        private static string _fileName = "";

        #region Save

        /// <summary>
        /// Save command, automatically chooses between "Save" and "Save as" if no filename is defined.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_fileName))
                SaveAs(sender, e);
            else
                SaveFile(_fileName, CurrentPiece);
        }

        /// <summary>
        /// Opens the "Save as" dialog to let the user choose a filename.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAs(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".musicista",
                Filter = "Musicista (*.musicista)|*.musicista",
                OverwritePrompt = true,
                FileName = CurrentPiece.Meta.Title
            };
            if (saveFileDialog.ShowDialog() != true)
                return;

            _fileName = saveFileDialog.FileName;
            SaveFile(_fileName, CurrentPiece);
        }

        /// <summary>
        /// Serializes the given piece.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="piece"></param>
        public static void SaveFile(string filename, Piece piece)
        {
            if (String.IsNullOrEmpty(filename))
                return;
            var serializer = new XmlSerializer(typeof(Piece));
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, piece);
            }
        }

        /// <summary>
        /// Opens the "Save as" dialog with MusicXML as an option.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Export(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".xml",
                Filter = "MusicXML (*.xml)|*.xml",
                OverwritePrompt = true,
                FileName = CurrentPiece.Meta.Title
            };
            if (saveFileDialog.ShowDialog() != true)
                return;

            ExportToMusicXML(saveFileDialog.FileName, CurrentPiece);
        }

        /// <summary>
        /// Converts a piece to a MusicXML ScorePartwise and serializes that.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="piece"></param>
        public static void ExportToMusicXML(string filename, Piece piece)
        {
            var mxmlPiece = MusicXMLMapper.MapMusicistaToMusicXML(piece);
            var serializer = new XmlSerializer(typeof(ScorePartwise));
            var streamWriter = new StreamWriter(filename);
            using (var writer = XmlWriter.Create(streamWriter))
            {
                writer.WriteDocType("score-partwise", "-//Recordare//DTD MusicXML 3.0 Partwise//EN", "http://www.musicxml.org/dtds/partwise.dtd", null);
                serializer.Serialize(writer, mxmlPiece);
            }
        }

        #endregion

        #region Open

        /// <summary>
        /// Shows the "Open" dialog for musicista, MusicXML and Midi files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter =
                    "Supported Files|*.xml;*.musicista;*.mxl|Musicista (*.musicista)|*.musicista|MusicXML (*.xml)|*.xml|Compressed MusicXML (*.mxl)|*.mxl|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() != true)
                return;
            OpenFile(openFileDialog.FileName);
        }

        /// <summary>
        /// Opens a file (see LoadFile) and displays it.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="scoreInfo">An optional MuseScore-API-object for additional meta data</param>
        public static void OpenFile(String filename, Score scoreInfo = null)
        {
            if (!string.IsNullOrEmpty(_fileName) && CurrentPiece != null)
                SaveFile(_fileName, CurrentPiece);

            if (Tracker != null)
                Tracker.Track("Open File", new Dictionary<string, object> { { "Username", Settings.Default.Username }, { "Filename", filename } });
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                CurrentPiece = LoadFile(filename, scoreInfo);
                DrawCurrentPiece();

                ApplicationSettings.AddToMostRecentlyUsedFiles(CurrentPiece.Meta.Title, _fileName, CurrentPiece.Meta);
                SidebarInformation.ShowPiece();
                UISidebar.Content = SidebarInformation;
                SetSidebarButtonPathFill(SidebarKind.Information);
                SidebarView.ShowPageSettings(PageList.First());
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show(@"Cannot find file " + exception.Message, "Error");
            }
            catch (FileLoadException exception)
            {
                MessageBox.Show(@"Cannot open filetype " + exception.Message, "Error");
            }
            catch (IOException exception)
            {
                MessageBox.Show("Error while loading file: " + exception.Message, "Error");
            }
            catch (ZipException exception)
            {
                MessageBox.Show("Error while unzipping file: " + exception.Message, "Error");
            }
            catch (InvalidOperationException exception)
            {
                var exceptionMessage = "";
                Exception currentEx = exception;
                while (currentEx != null)
                {
                    exceptionMessage += "\n" + currentEx.Message;
                    currentEx = currentEx.InnerException;
                }

                MessageBox.Show(
                    "Error loading musicista-file. The file might be damaged or an older version, which is not supported anymore (I'm sorry!) \n\n" +
                    exceptionMessage, "Error");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error opening file \n\n" + e.Message, "Error");
                if (Tracker != null)
                    Tracker.Track("Crash", new Dictionary<string, object>
            {
                { "Username", Settings.Default.Username },
                { "Message", e.Message },
                { "Type", e.GetType().ToString() },
                { "Data", e.Data.ToString() },
                { "StackTrace", e.StackTrace },
                { "Source", e.Source },
                { "OS", Environment.OSVersion.VersionString },
                { "Current Piece", CurrentPiece != null ? CurrentPiece.Meta.Title : "" },
                { "URL", CurrentPiece != null && CurrentPiece.Meta.Weblink != null ? CurrentPiece.Meta.Weblink : "" }
            });
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Loads the file with the given filename. Can handle musicista, xml and mxl files.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="scoreInfo"></param>
        /// <returns></returns>
        public static Piece LoadFile(string filename, Score scoreInfo)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException(filename);

            switch (Path.GetExtension(filename))
            {
                case ".mxl":
                    // find the correct xml-file, unzip it and try to open that one again
                    var unzippedFilePath = UnzipMXL(filename, scoreInfo);
                    var convertedFile = LoadMusicXMLFile(unzippedFilePath, scoreInfo);
                    _fileName = "Collection/" + Path.GetFileNameWithoutExtension(unzippedFilePath) + ".musicista";
                    SaveFile(_fileName, convertedFile);
                    return convertedFile;

                case ".xml":
                    var loadedPiece = LoadMusicXMLFile(filename, scoreInfo);
                    _fileName = "Collection/" + Path.GetFileNameWithoutExtension(filename) + ".musicista";
                    SaveFile(_fileName, loadedPiece);
                    return loadedPiece;

                case ".musicista":
                    using (var fileStream = new FileStream(filename, FileMode.Open))
                    {
                        var musicistaSerializer = new XmlSerializer(typeof(Piece));
                        var piece = (Piece)musicistaSerializer.Deserialize(fileStream);
                        piece.CorrectParentConnections();
                        _fileName = filename;
                        return piece;
                    }

                default:
                    throw new FileLoadException(Path.GetExtension(filename));
            }
        }

        /// <summary>
        /// Usel XSLT to convert a Timewise MusicXML piece to a Partwise piece.
        /// </summary>
        /// <param name="xdoc"></param>
        /// <returns></returns>
        public static ScorePartwise ConvertTimewiseToPartwise(XDocument xdoc)
        {
            var xslCompiledTransform = new XslCompiledTransform(); // XSLT Transformation
            var stream = new MemoryStream(); // Temporary memorystream
            var outputXmlTextWriter = XmlWriter.Create(stream);
            xslCompiledTransform.Load("Properties/timepart.xsl"); // Load the XSLT 
            xslCompiledTransform.Transform(xdoc.CreateNavigator(), null, outputXmlTextWriter); // Transform the timewise-document into a partwise-document

            stream.Position = 0; // reset stream to beginning

            var xmlSerializer = new XmlSerializer(typeof(ScorePartwise));
            return (ScorePartwise)xmlSerializer.Deserialize(XmlReader.Create(stream)); // deserialize the transformed stream
        }

        /// <summary>
        /// Unzip .xml files to .xml files and stores them in the temp-folder
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="scoreInfo"></param>
        /// <returns></returns>
        public static string UnzipMXL(string filename, Score scoreInfo = null)
        {
            foreach (
                var zipEntry in
                    ZipFile.Read(filename).Where(zipEntry => Path.GetExtension(zipEntry.FileName) == ".xml" && zipEntry.FileName != "META-INF/container.xml"))
            {
                if (filename == "tempDownloadMuseScore.mxl" && scoreInfo != null)
                    zipEntry.FileName = scoreInfo.Title + ".xml";
                else
                    zipEntry.FileName = Path.GetFileNameWithoutExtension(filename) + ".xml";
                foreach (var character in Path.GetInvalidFileNameChars())
                    zipEntry.FileName = zipEntry.FileName.Replace(character, ' ');

                zipEntry.Extract("Collection/temp", ExtractExistingFileAction.OverwriteSilently);

                return "Collection/temp/" + zipEntry.FileName;
            }
            return null;
        }

        /// <summary>
        /// Load ANY MusicXML file (timewise or partwise) and look at the root, which on it is. timewise files are than tranformed.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="scoreInfo"></param>
        /// <returns>A musicista piece</returns>
        public static Piece LoadMusicXMLFile(string filename, Score scoreInfo = null)
        {
            // based upon http://stackoverflow.com/a/23663586/1507481
            var xdoc = XDocument.Load(filename);
            if (xdoc.Root == null) throw new IOException(@"Cannot open file " + Path.GetExtension(filename) + " because it does not seem to be valid MusicXML.");
            switch (xdoc.Root.Name.LocalName)
            {
                case "score-partwise":
                    {
                        var xmlSerializer = new XmlSerializer(typeof(ScorePartwise));
                        var result = (ScorePartwise)xmlSerializer.Deserialize(xdoc.CreateReader());
                        return MusicXMLMapper.MapMusicXMLToMusicista(result, filename, scoreInfo);
                    }
                case "score-timewise":
                    {
                        var result = ConvertTimewiseToPartwise(xdoc);
                        return MusicXMLMapper.MapMusicXMLToMusicista(result, filename, scoreInfo);
                    }
                default:
                    throw new IOException(@"Cannot open file " + Path.GetExtension(filename) + " because it does not seem to be valid MusicXML.");
            }
        }

        #endregion
    }
}