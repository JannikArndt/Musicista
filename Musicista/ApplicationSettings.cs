using Model;
using Musicista.Collection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Musicista
{
    public class ApplicationSettings
    {
        public String FileName = "ApplicationSettings.appsettings";
        public List<DocumentReference> MostRecentlyUsed = new List<DocumentReference>();

        public ApplicationSettings()
        {
            MostRecentlyUsed = new List<DocumentReference>();
        }

        public void Save()
        {
            var serializer = new XmlSerializer(typeof(ApplicationSettings));
            using (TextWriter writer = new StreamWriter(FileName))
            {
                serializer.Serialize(writer, this);
            }
        }

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