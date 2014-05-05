using System.Text.RegularExpressions;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Musicista
{
    public static class Mapper
    {
        public static Piece MapMusicXMLPartwiseToMusicistaPiece(scorepartwise mxml)
        {
            var piece = new Piece
            {
                Title = mxml.work.worktitle,
                ListOfComposers = new List<Composer>(),
                ListOfInstruments = new List<Instrument>()
            };

            foreach (var creator in mxml.identification.creator.Where(creator => creator.type == "composer"))
                piece.ListOfComposers.Add(new Composer { FullName = creator.Value });


            // Partlist.scorepart = first <score-part/>, partlist.items except last one = other <score-parts/>
            piece.ListOfInstruments.Add(new Instrument(mxml.partlist.scorepart.partname.Value, int.Parse(Regex.Match(mxml.partlist.scorepart.id, @"\d+").Value)));

            foreach (scorepart scorepart in mxml.partlist.Items.Where(item => item.GetType() == typeof(scorepart)))
                piece.ListOfInstruments.Add(new Instrument(scorepart.partname.Value, int.Parse(Regex.Match(scorepart.id, @"\d+").Value)));

            return piece;

        }
    }
}
