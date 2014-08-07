using Model;
using Model.Meta;
using Model.Meta.People;
using System;
using System.Collections.Generic;
using Model.Sections.Attributes;

namespace ModelTests
{
    public static class FilledPiece
    {
        public static Piece GetPiece()
        {
            var piece = new Piece(initialize: true)
            {
                Meta = new MetaData
                {
                    Title = "Title",
                    Subtitle = "Subtitle",
                    People = new People
                    {
                        Composers = new List<Composer>
                        {
                            new Composer{FirstName = "Gustav", LastName = "Mahler", Born = new DateTime(1860, 7, 7), Died = new DateTime(1911, 5, 18)},
                            new Composer{FirstName = "Johann", MiddleName = "Sebastian", LastName = "Bach", Born = new DateTime(1685, 3, 31), Died = new DateTime(1750, 7, 28)}
                        },
                        Lyricists = new List<Person>
                        {
                            new Person{FirstName = "Friedrich", LastName = "Nietzsche"}
                        }
                    },
                    Collection = "Collection",
                    Opus = new OpusNumber(10, 2, false),
                    Epoch = Epoch.Romantic,
                    Form = Form.Concerto,
                    Dates = new Dates
                    {
                        DateOfComposition = new DateEvent(1930, 3, 6, "Wien", "Fake"),
                        Engraving = new Engraving("Jannik Arndt", 2014, 7, 31, "Oldenburg"),
                        Publications = new List<Publication> { new Publication("Bärenreiter", 2015, 2, 3, "Wien") }
                    },
                    Key = new MusicalKey(Step.C, Gender.Major),
                    Copyright = "CC-3.0",
                    Weblink = "http://www.musicistaapp.de",
                    Software = "Musicista"
                }
            };

            return piece;
        }
    }
}
