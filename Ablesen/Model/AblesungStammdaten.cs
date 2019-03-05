namespace Ablesen.Model
{
    public class AblesungStammdaten
    {
        public AblesungStammdaten(string lsNutzer, string verwalter, string strasse, string ort, string nutzer1,
            string nutzer2, string hvNummer, string zeitraum, string lage)
        {
            LsNutzer = lsNutzer;
            Verwalter = verwalter;
            Strasse = strasse;
            Ort = ort;
            Nutzer1 = nutzer1;
            Nutzer2 = nutzer2;
            HvNummer = hvNummer;
            Zeitraum = zeitraum;
            Lage = lage;
        }

        public string LsNutzer { get; }
        public string Verwalter { get; }
        public string Strasse { get; }
        public string Ort { get; }
        public string Nutzer1 { get; }
        public string Nutzer2 { get; }
        public string HvNummer { get; }
        public string Zeitraum { get; }
        public string Lage { get; }
    }
}