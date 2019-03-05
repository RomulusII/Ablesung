namespace Ablesen.Model
{
    public class Rauchmelder : GeraetBase
    {
        public RachmelderStatus Status { get; }

        public Rauchmelder(int pos, string art, string raum) : base(pos, art, raum)
        {
        }
    }
}