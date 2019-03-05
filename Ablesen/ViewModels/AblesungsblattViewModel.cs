using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using Ablesen.Model;

namespace Ablesen.ViewModels
{
    public class AblesungsblattViewModel : ViewModelBase
    {
        public AblesungsBlatt AblesungsBlatt { get; }

        public IList<ZaehlerViewModel> ZaehlerList { get; } = new List<ZaehlerViewModel>();

        public IList<Rauchmelder> RauchmelderList { get; } = new List<Rauchmelder>();

        public ZaehlerViewModel SelectedZaehler { get; set; }

        public AblesungsblattViewModel(AblesungsBlatt ablesungsBlatt)
        {
            AblesungsBlatt = ablesungsBlatt;
        }

        public AblesungsblattViewModel() :
            this(new AblesungsBlatt(new AblesungStammdaten(lsNutzer: "1121100042 - 0002",
                verwalter: "WEG 107 - Mainz, ....",
                strasse: "Baacchusstraße 2",
                ort: "55129 Mainz",
                nutzer1: "Bender",
                nutzer2: "006 - Egt. Bender",
                hvNummer: "107/03",
                zeitraum: "1.1.18 - 31.12.18",
                lage: "B2 links mitte")))
        {
            ZaehlerList = new List<ZaehlerViewModel>()
            {
                new ZaehlerViewModel( new Zaehler(1, "HVE", "BAD", "0900" , 1763)),
                new ZaehlerViewModel( new Zaehler(1, "WWZ", "KÜCHE", "4283" , 0.720)),

            };

        }

    }
}
