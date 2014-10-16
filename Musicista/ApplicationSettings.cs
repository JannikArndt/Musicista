using Model;
using Musicista.Collection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Musicista
{
    /// <summary>
    /// The class that handles most recently used files
    /// </summary>
    public class ApplicationSettings
    {
        public String FileName = "RecentlyUsed.xml";
        public List<DocumentReference> MostRecentlyUsed = new List<DocumentReference>();

        public ApplicationSettings()
        {
            MostRecentlyUsed = new List<DocumentReference>();
        }

        /// <summary>
        /// Saves the MostRecentlyUsed object to RecentlyUsed.xml
        /// </summary>
        public void Save()
        {
            var serializer = new XmlSerializer(typeof(ApplicationSettings));
            using (TextWriter writer = new StreamWriter(FileName))
            {
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>
        /// Add a file to the list of most recently used files.
        /// </summary>
        /// <param name="name">The title</param>
        /// <param name="filename">The filename</param>
        /// <param name="metaData">The piece's metadata object</param>
        public void AddToMostRecentlyUsedFiles(String name, String filename, MetaData metaData)
        {
            var document = MostRecentlyUsed.FirstOrDefault(item => item.Name == name && item.Filepath == filename);
            if (document != null)
            {
                MostRecentlyUsed.Remove(document);
                MostRecentlyUsed.Insert(0, document);
            }
            else
                MostRecentlyUsed.Insert(0, new DocumentReference(name, filename, metaData));

            Save();
        }
    }
}