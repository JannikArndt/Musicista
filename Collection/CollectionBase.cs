using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Collection
{
    [XmlRoot("Collection")]
    public class CollectionBase
    {
        [XmlElement("Composer")]
        public List<CollectionComposer> Composers { get; set; }
        [XmlIgnore]
        public String FileName = "Collection.appsettings";

        public CollectionBase()
        {
            Composers = new List<CollectionComposer>();
        }

        public void Save()
        {
            var serializer = new XmlSerializer(typeof(CollectionBase));
            using (TextWriter writer = new StreamWriter(FileName))
            {
                serializer.Serialize(writer, this);
            }
        }

        public void CreateExample()
        {
            Composers = new List<CollectionComposer>
            {
                new CollectionComposer{Name = "Bach", Born = 1685, Died = 1750, Image = "images/Bach.jpg", Categories = new List<CollectionCategory>
                {
                    new CollectionCategory{CategoryName = "Fugen", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Fuge Nr. 1"}
                    }},
                    new CollectionCategory{CategoryName = "Concertos", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Brandenburgische Konzerte"}
                    }}
                }},
                new CollectionComposer{Name = "Beethoven", Born = 1770, Died = 1827, Image = "images/Beethoven.jpg", Categories = new List<CollectionCategory>
                {
                    new CollectionCategory{CategoryName = "Sinfonien", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Sinfonie Nr. 1"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 2"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 3"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 4"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 5"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 6"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 7"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 8"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 9"}

                    }},
                    new CollectionCategory{CategoryName = "Sonaten", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Sonate Nr. 1"},
                        new CategoryWork {WorkName = "Sonate Nr. 2"},
                        new CategoryWork {WorkName = "Sonate Nr. 17"},
                        new CategoryWork {WorkName = "Sonate Nr. 18"},
                        new CategoryWork {WorkName = "Sonate Nr. 24"},
                    }}
                }},
                new CollectionComposer{Name = "Mozart", Born = 1756, Died = 1791, Image = "images/Mozart.jpg", Categories = new List<CollectionCategory>
                {
                    new CollectionCategory{CategoryName = "Sinfonien", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Sinfonie Nr. 39"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 40"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 41"}

                    }},
                    new CollectionCategory{CategoryName = "Opern", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Figaro"},
                        new CategoryWork {WorkName = "Zauberflöte"},
                        new CategoryWork {WorkName = "Don Giovanni"}
                    }}
                }}
            };
        }
    }
}
