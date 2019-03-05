namespace Ablesen.Model
{
    public class Zaehler : GeraetBase
    {
        public Zaehler(int pos, string art, string raum, string gNummer, double ablesungVorjahr)
            : base(pos, art, raum)
        {
            GNummer = gNummer;
            AblesungVorjahr = ablesungVorjahr;
        }

        public string GNummer { get; }

        public double AblesungVorjahr { get; }

        public double Zaehlerstand { get; set; }
    }

    public enum RachmelderStatus
    {
        None,
        InOrdnung,
        NichtInOrdnung,
        ExistiertNicht
    }
}