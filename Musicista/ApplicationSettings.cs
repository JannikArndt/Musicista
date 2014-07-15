using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Musicista
{
    public class ApplicationSettings
    {
        public List<DocumentReference> MostRecentlyUsed = new List<DocumentReference>();
        public String FileName = "ApplicationSettings.appsettings";
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
    }

    [Serializable]
    public class DocumentReference
    {
        public String Name { get; set; }
        public String Filepath { get; set; }

        public DocumentReference(string name, string filepath)
        {
            Name = name;
            Filepath = filepath;
        }

        public DocumentReference() { }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Name))
                return Filepath;
            return Name + " (" + Filepath + ")";
        }
    }
}
