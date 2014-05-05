
namespace Model
{
    public class Instrument
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Instrument(string name = "", int id = 0)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return ID + ": " + Name;
        }
    }
}
