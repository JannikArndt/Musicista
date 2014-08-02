using Model;

namespace Musicista.Mappers
{
    public static class Mapper
    {
        public static Piece CreateEmptyPiece()
        {
            return new Piece(initialize: true);
        }
    }
}
