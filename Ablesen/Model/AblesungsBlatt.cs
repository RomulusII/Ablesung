using System.Collections.Generic;

namespace Ablesen.Model
{
    public class AblesungsBlatt
    {
        public AblesungsBlatt(AblesungStammdaten stammdaten)
        {
            Stammdaten = stammdaten;
        }

        public AblesungStammdaten Stammdaten { get; }

        public IList<GeraetBase> Postionen { get; } = new List<GeraetBase>();
    }
}