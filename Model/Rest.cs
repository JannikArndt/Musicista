
namespace Model
{
    public class Rest : Symbol
    {
        public Rest() { }
        public override string ToString()
        {
            return "Rest on " + Beat + " for " + Duration;
        }
    }
}
