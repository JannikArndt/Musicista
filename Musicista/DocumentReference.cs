using System;

namespace Musicista
{
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