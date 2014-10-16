
namespace Model.Sections.Notes
{
    /// <summary>
    /// represents a rest which is derived from the symbol class
    /// </summary>
    public class Rest : Symbol
    {
        public Rest() { }
        public override string ToString()
        {
            return "Rest on " + Beat + " for " + Duration;
        }
    }
}
