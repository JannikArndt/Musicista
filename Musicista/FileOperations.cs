using Ionic.Zip;
using Microsoft.Win32;
using Model;
using MuseScoreAPI.RESTObjects;
using Musicista.Mappers;
using Musicista.Sidebar;
using MusicXML;
using System;
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

        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_fileName))
                SaveAs(sender, e);
            else
                SaveFile(_fileName, CurrentPiece);
        }

        private void SaveAs(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".musicista",
                Filter = "Musicista (*.musicista)|*.musicista",
                OverwritePrompt = true,
                FileName = CurrentPiece.Title
            };
            if (saveFileDialog.ShowDialog() != true)
                return;

            _fileName = saveFileDialog.FileName;
            SaveFile(_fileName, CurrentPiece);
        }

        public static void SaveFile(string filename, Piece piece)
        {
            var serializer = new XmlSerializer(typeof(Piece));
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, piece);
            }
            //ApplicationSettings.AddToMostRecentlyUsedFiles(piece.Title, filename);
        }

        #endregion

        #region Open

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

        public static void OpenFile(String filename, Score scoreInfo = null)
        {
            try
            {
                var piece = LoadFile(filename, scoreInfo);
                DrawPiece(piece);

                ApplicationSettings.AddToMostRecentlyUsedFiles(CurrentPiece.Title, filename);
                SidebarInformation.ShowPiece();
                UISidebar.Content = SidebarInformation;
                SetSidebarButtonPathFill(SidebarKind.Information);
                SidebarView.ShowPageSettings(PageList.First());
            }
            catch (IOException exception)
            {
                MessageBox.Show("Error while loading file: " + exception.Message, "Error");
            }
            catch (ZipException exception)
            {
                MessageBox.Show("Error while loading file: " + exception.Message, "Error");
            }
        }

        public static void CorrectParentConnectionsInMusicistaPiece(Piece piece)
        {
            foreach (var passage in piece.ListOfAllPassages)
                foreach (var measureGroup in passage.ListOfMeasureGroups)
                {
                    measureGroup.ParentPassage = passage;
                    foreach (var measure in measureGroup.Measures)
                    {
                        measure.ParentMeasureGroup = measureGroup;
                        foreach (var symbol in measure.Symbols)
                            symbol.ParentMeasure = measure;
                    }
                }
            // same for the Parts
            foreach (var part in piece.Parts)
                foreach (var measureGroup in part.Passage.ListOfMeasureGroups)
                {
                    measureGroup.ParentPassage = part.Passage;
                    foreach (var measure in measureGroup.Measures)
                    {
                        measure.ParentMeasureGroup = measureGroup;
                        foreach (var symbol in measure.Symbols)
                            symbol.ParentMeasure = measure;
                    }
                }
        }

        public static Piece LoadFile(string filename, Score scoreInfo)
        {
            switch (Path.GetExtension(filename))
            {
                case ".mxl":
                    // find the correct xml-file, unzip it and try to open that one again
                    var unzippedFilePath = UnzipMXL(filename, scoreInfo);
                    return LoadMusicXMLFile(unzippedFilePath, scoreInfo);

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
                        CorrectParentConnectionsInMusicistaPiece(piece);
                        _fileName = filename;
                        return piece;
                    }

                default:
                    MessageBox.Show(@"Cannot open filetype " + Path.GetExtension(filename), "Error");
                    return null;
            }
        }

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

        public static Piece LoadMusicXMLFile(string filename, Score scoreInfo = null)
        {
            // based upon http://stackoverflow.com/a/23663586/1507481
            var xdoc = XDocument.Load(filename);
            if (xdoc.Root != null)
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
                        MessageBox.Show(@"Cannot open file " + Path.GetExtension(filename) + " because it does not seem to be valid MusicXML.", "Error");
                        return null;
                }
            return null;
        }

        #endregion
    }
}