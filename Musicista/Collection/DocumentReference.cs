using Model;
using System;

namespace Musicista.Collection
{
    /// <summary>
    /// Logical structure to store a reference to a file with additional meta data
    /// </summary>
    [Serializable]
    public class DocumentReference
    {
        public String Name { get; set; }
        public String Filepath { get; set; }
        public MetaData MetaData { get; set; }

        public string TitleString { get { return MetaData.Title; } }
        public string ComposerString { get { return MetaData.People.ComposersAsString; } }
        public string OpusString { get { return MetaData.Opus.OpusString; } }

        public DocumentReference(string name, string filepath, MetaData metaData = null)
        {
            Name = name;
            Filepath = filepath;
            MetaData = metaData;
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