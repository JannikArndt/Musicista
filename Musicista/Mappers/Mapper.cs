using Model;
using System.Collections.Generic;

namespace Musicista.Mappers
{
    public static class Mapper
    {
        public static Piece CreateEmptyPiece()
        {
            return new Piece
            {
                ListOfComposers = new List<Composer>(),
                ListOfInstruments = new List<Instrument>(),
                ListOfSections =
                    new List<Section>
                    {
                        new Section
                        {
                            ListOfMovements =
                                new List<Movement>
                                {
                                    new Movement
                                    {
                                        ListOfSegments =
                                            new List<Segment>
                                            {
                                                new Segment
                                                {
                                                    ListOfPassages =
                                                        new List<Passage>
                                                        {
                                                            new Passage {ListOfMeasureGroups = new List<MeasureGroup>()}
                                                        }
                                                }
                                            }
                                    }
                                }
                        }
                    }
            };
        }
    }
}
