using Model;
using Model.Sections;
using System.Collections.Generic;

namespace Algorithms
{
    /// <summary>
    /// A general interface for Algorithms
    /// </summary>
    public interface IMusicistaAlgorithm
    {
        object Run(Piece piece);
        object Run(Passage passage);
        object Run(List<Piece> pieces);
        object Run(List<Passage> passages);
    }
}
