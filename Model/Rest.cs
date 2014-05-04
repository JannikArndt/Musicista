
namespace Model
{
    public class Rest : Symbol
    {
        public override string ToString()
        {
            return "Rest on " + Beat + " for " + Duration;
        }
    }
}
