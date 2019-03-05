namespace Ablesen.Model
{
    public class GeraetBase
    {
        protected GeraetBase(int pos, string art, string raum)
        {
            Pos = pos;
            Art = art;
            Raum = raum;
        }

        public int Pos { get; }

        public string Art { get; }

        public string Raum { get; }
    }
}